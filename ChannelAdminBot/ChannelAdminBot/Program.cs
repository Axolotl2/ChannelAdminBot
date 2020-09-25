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
    public class Program
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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            string token;

            //m_Client.Log += Log;
            token = Environment.GetEnvironmentVariable("ChannelAdminBotToken", EnvironmentVariableTarget.User);
            await Client.LoginAsync(Discord.TokenType.Bot, token);
            await Client.StartAsync();
            Client.Ready += Client_Ready;
            try
            {
                await Task.Delay(Timeout.Infinite, m_Source.Token);
            }
            catch (TaskCanceledException tce)
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

        private async void setChannelsComboBoxValues()
        {
            IReadOnlyCollection<IGuild> guilds;
            IReadOnlyCollection<IGuildChannel> guildChannels;
            List<string> comboBoxValues = new List<string>();

            guilds = await (Client as IDiscordClient).GetGuildsAsync();
            guildChannels = await guilds.ToArray()[0].GetChannelsAsync();
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
            IReadOnlyCollection<IGuild> guilds;
            IReadOnlyCollection<IGuildChannel> guildChannels;
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;
            List<string> listBoxValues = new List<string>();
            IReadOnlyCollection<IGuildUser> users;
            string userNickName;

            guilds = await (Client as IDiscordClient).GetGuildsAsync();
            guildChannels = await guilds.ToArray()[0].GetChannelsAsync();
            foreach (IGuildChannel channel in guildChannels)
            {
                if (channel.Name.Equals(m_Controller.PickedChannel))
                {
                    guildUsers = channel.GetUsersAsync();
                }
            }

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

        private async void setMuteStateToAllUsers(string i_ChannelName, bool i_MuteValue)
        {
            IReadOnlyCollection<IGuild> guilds;
            IReadOnlyCollection<IGuildChannel> guildChannels = null;
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;

            guilds = await (Client as IDiscordClient).GetGuildsAsync();
            guildChannels = await guilds.ToArray()[0].GetChannelsAsync();
            foreach (IGuildChannel channel in guildChannels)
            {
                if (channel.Name.Equals(i_ChannelName))
                {
                    guildUsers = channel.GetUsersAsync();
                }
            }

            IAsyncEnumerator<IReadOnlyCollection<IGuildUser>> e = guildUsers.GetAsyncEnumerator();
            try
            {
                while (await e.MoveNextAsync())
                {
                    IReadOnlyCollection<IGuildUser> users = e.Current;
                    foreach (IGuildUser user in users)
                    {
                        if (user.IsMuted != i_MuteValue)
                        {
                            user.ModifyAsync(props => props.Mute = i_MuteValue);
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

        private async void setMuteStateToSelectedUsers(string i_ChannelName, List<string> i_Users, bool i_MuteValue)
        {
            IReadOnlyCollection<IGuild> guilds;
            IReadOnlyCollection<IGuildChannel> guildChannels = null;
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;
            string userNickName;

            guilds = await (Client as IDiscordClient).GetGuildsAsync();
            guildChannels = await guilds.ToArray()[0].GetChannelsAsync();
            foreach (IGuildChannel channel in guildChannels)
            {
                if (channel.Name.Equals(i_ChannelName))
                {
                    guildUsers = channel.GetUsersAsync();
                }
            }

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
                            if (user.IsMuted != i_MuteValue)
                            {
                                user.ModifyAsync(props => props.Mute = i_MuteValue);
                            }
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
