using Discord;
//using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChannelAdminBot
{
    internal class ChannelAdmitBotLogic
    {
        private DiscordSocketClient m_Client;
        private ChannelAdminController m_Controller;
        private CancellationTokenSource m_Source = new CancellationTokenSource();

        public DiscordSocketClient Client
        {
            get
            {
                if (m_Client == null)
                {
                    m_Client = new DiscordSocketClient();
                }

                return m_Client;
            }
        }

        public async Task RunAsync()
        {
            string token;

            //m_Client.Log += Log;
            token = Environment.GetEnvironmentVariable("ChannelAdminBotToken", EnvironmentVariableTarget.User);
            await Client.LoginAsync(Discord.TokenType.Bot, token);
            await Client.StartAsync();
            Client.Ready += Client_Ready;
            await handleBotKeepAlive();
        }

        private async Task handleBotKeepAlive()
        {
            try
            {
                await Task.Delay(Timeout.Infinite, m_Source.Token);
            }
            catch (TaskCanceledException)
            {
            }
            finally
            {
                await Client.StopAsync();
            }
        }

        private async Task Client_Ready()
        {
            initializeController();
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(m_Controller);
            m_Source.Cancel();
        }

        private void initializeController()
        {
            m_Controller = new ChannelAdminController();
            setChannelsComboBoxValues();
            setUsersListBoxValues();
            m_Controller.MuteAllPressed += setMuteStateToAllUsers;
            m_Controller.UnMuteAllPressed += setMuteStateToAllUsers;
            m_Controller.MuteSelectedPressed += setMuteStateToSelectedUsers;
            m_Controller.UnMuteSelectedPressed += setMuteStateToSelectedUsers;
            m_Controller.ChannelPicked += setUsersListBoxValues;
            m_Client.UserVoiceStateUpdated += M_Client_UserVoiceStateUpdated;
        }

        private Task M_Client_UserVoiceStateUpdated(SocketUser arg1, SocketVoiceState arg2, SocketVoiceState arg3)
        {
            bool leftSelectedChannel, joinedSelectedChannel;

            leftSelectedChannel = arg2.VoiceChannel != null && arg2.VoiceChannel.Name.Equals(m_Controller.PickedChannel);
            joinedSelectedChannel = arg3.VoiceChannel != null && arg3.VoiceChannel.Name.Equals(m_Controller.PickedChannel);
            if (leftSelectedChannel || joinedSelectedChannel)
            {
                setUsersListBoxValues();
            }

            return Task.CompletedTask;
        }

        private async Task<IReadOnlyCollection<IGuildChannel>> getGuildChannels()
        {
            IReadOnlyCollection<IGuild> guilds;
            IReadOnlyCollection<IGuildChannel> guildChannels;
            //List<string> comboBoxValues = new List<string>();

            guilds = await (Client as IDiscordClient).GetGuildsAsync();
            guildChannels = await guilds.ToArray()[0].GetChannelsAsync();

            return guildChannels;
        }

        private async Task<IAsyncEnumerable<IReadOnlyCollection<IGuildUser>>> getGuildChannelUsers(string i_ChannelName)
        {
            IReadOnlyCollection<IGuildChannel> guildChannels;
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;

            guildChannels = await getGuildChannels();
            foreach (IGuildChannel channel in guildChannels)
            {
                if (channel.Name.Equals(m_Controller.PickedChannel))
                {
                    guildUsers = channel.GetUsersAsync();
                }
            }

            return guildUsers;
        }

        private async void setChannelsComboBoxValues()
        {
            IReadOnlyCollection<IGuildChannel> guildChannels;
            List<string> comboBoxValues = new List<string>();
            
            guildChannels = await getGuildChannels();
            foreach (IGuildChannel channel in guildChannels)
            {
                if (channel is IVoiceChannel)
                {
                    comboBoxValues.Add(channel.Name);
                }
            }

            m_Controller.SetComboBoxValues(comboBoxValues);
        }

        private async void setUsersListBoxValues()
        {
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;
            List<string> listBoxValues = new List<string>();
            IReadOnlyCollection<IGuildUser> users;
            string userNickName;

            guildUsers = await getGuildChannelUsers(m_Controller.PickedChannel);

            IAsyncEnumerator<IReadOnlyCollection<IGuildUser>> e = guildUsers.GetAsyncEnumerator();
            try
            {
                while (await e.MoveNextAsync())
                {
                    users = e.Current;
                    foreach (IGuildUser user in users)
                    {
                        userNickName = user.Nickname != null ? user.Nickname : user.Username;
                        listBoxValues.Add(userNickName);
                    }
                }
                //await foreach (IGuildUser user in guildUsers)
                //    (user as IGuildUser).ModifyAsync(props => props.Mute = true);
            }
            finally
            {
                if (e != null)
                {
                    await e.DisposeAsync();
                }
            }

            m_Controller.SetCheckedListBoxValues(listBoxValues);
        }

        private void setMuteStateToUserIfNeeded(IGuildUser i_User, bool i_MuteState)
        {
            if (i_User.IsMuted != i_MuteState)
            {
                i_User.ModifyAsync(props => props.Mute = i_MuteState);
            }
        }

        private async void setMuteStateToAllUsers(string i_ChannelName, bool i_MuteState)
        {
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;
            
            guildUsers = await getGuildChannelUsers(i_ChannelName);

            IAsyncEnumerator<IReadOnlyCollection<IGuildUser>> e = guildUsers.GetAsyncEnumerator();
            try
            {
                while (await e.MoveNextAsync())
                {
                    IReadOnlyCollection<IGuildUser> users = e.Current;
                    foreach (IGuildUser user in users)
                    {
                        setMuteStateToUserIfNeeded(user, i_MuteState);
                    }
                }
                //await foreach (IGuildUser user in guildUsers)
                //    (user as IGuildUser).ModifyAsync(props => props.Mute = true);
            }
            finally
            {
                if (e != null)
                {
                    await e.DisposeAsync();
                }
            }
        }

        private async void setMuteStateToSelectedUsers(string i_ChannelName, List<string> i_Users, bool i_MuteState)
        {
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;
            string userNickName;

            guildUsers = await getGuildChannelUsers(i_ChannelName);

            IAsyncEnumerator<IReadOnlyCollection<IGuildUser>> e = guildUsers.GetAsyncEnumerator();
            try
            {
                while (await e.MoveNextAsync())
                {
                    IReadOnlyCollection<IGuildUser> users = e.Current;
                    foreach (IGuildUser user in users)
                    {
                        userNickName = user.Nickname != null ? user.Nickname : user.Username;
                        if (i_Users.Contains(userNickName))
                        {
                            setMuteStateToUserIfNeeded(user, i_MuteState);
                        }
                    }
                }
                //await foreach (IGuildUser user in guildUsers)
                //    (user as IGuildUser).ModifyAsync(props => props.Mute = true);
            }
            finally
            {
                if (e != null)
                {
                    await e.DisposeAsync();
                }
            }
        }
    }
}
