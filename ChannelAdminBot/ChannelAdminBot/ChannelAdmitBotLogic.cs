﻿using Discord;
//using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private ChannelAdminBotLog m_Log;

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

            try
            {
                m_Log = new ChannelAdminBotLog();
                m_Log.StartLogging();
                //m_Client.Log += Log;
                token = Environment.GetEnvironmentVariable("ChannelAdminBotToken", EnvironmentVariableTarget.User);
                await Client.LoginAsync(Discord.TokenType.Bot, token);
                await Client.StartAsync();
                Client.Ready += Client_Ready;
                Client.Disconnected += Client_Disconnected;
                await handleBotKeepAlive();
            }
            catch (Discord.Net.HttpException he)
            {
                string message =
                    @"Invalid bot token exists,
Please reinstall Discord Mute Controller with the valid token!
or update the 'ChannelAdminBotToken' environment variable with the valid token";

                m_Log.LogLoginFailed(he);
                MessageBox.Show(message, "Login Failed");
            }
        }

        private async Task Client_Disconnected(Exception arg)
        {
            m_Log.LogClientDisconnected();
            MessageBox.Show("The connection between discord and the application ended", "Client Disconnected");
            await Client.StopAsync();
            m_Controller.Close();
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
                m_Log.LogProgramEnded();
                await Client.StopAsync();
            }
        }

        private Task Client_Ready()
        {
            initializeController();
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(m_Controller);
            m_Source.Cancel();

            return Task.CompletedTask;
        }

        private void initializeController()
        {
            m_Controller = new ChannelAdminController();
            m_Log.AttachController(m_Controller);
            setGuildsComboBoxValues();
            setChannelsComboBoxValues();
            setUsersListBoxValues();
            m_Controller.MuteAllPressed += setMuteStateToAllUsers;
            m_Controller.UnMuteAllPressed += setMuteStateToAllUsers;
            m_Controller.MuteSelectedPressed += setMuteStateToSelectedUsers;
            m_Controller.UnMuteSelectedPressed += setMuteStateToSelectedUsers;
            m_Controller.GuildPicked += setChannelsComboBoxValues;
            m_Controller.GuildPicked += setUsersListBoxValues;
            m_Controller.ChannelPicked += setUsersListBoxValues;
            m_Client.UserVoiceStateUpdated += M_Client_UserVoiceStateUpdated;
            m_Client.GuildMemberUpdated += M_Client_GuildMemberUpdated;
        }

        private Task M_Client_GuildMemberUpdated(SocketUser arg1, SocketUser arg2)
        {
            string oldNickname, newNickname;
            bool nickNameDeleted, nickNameCreated, nickNameChanged;

            oldNickname = (arg1 as IGuildUser).Nickname;
            newNickname = (arg2 as IGuildUser).Nickname;
            nickNameDeleted = oldNickname != null && newNickname == null;
            nickNameCreated = oldNickname == null && newNickname != null;
            nickNameChanged = oldNickname != null && !oldNickname.Equals(newNickname);
            if (nickNameDeleted || nickNameCreated || nickNameChanged)
            {
                setUsersListBoxValues();
            }

            return Task.CompletedTask;
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

        private async Task<IReadOnlyCollection<IGuild>> getGuilds()
        {
            IReadOnlyCollection<IGuild> guilds;

            guilds = await (Client as IDiscordClient).GetGuildsAsync();

            return guilds;
        }

        private async Task<IReadOnlyCollection<IGuildChannel>> getGuildChannels(string i_GuildName)
        {
            IReadOnlyCollection<IGuild> guilds;
            IReadOnlyCollection<IGuildChannel> guildChannels = null;

            guilds = await getGuilds();
            foreach (IGuild guild in guilds)
            {
                if (guild.Name.Equals(i_GuildName))
                {
                    guildChannels = await guild.GetChannelsAsync();
                    break;
                }
            }

            return guildChannels;
        }

        private async Task<IAsyncEnumerable<IReadOnlyCollection<IGuildUser>>> getGuildChannelUsers(string i_GuildName, string i_ChannelName)
        {
            IReadOnlyCollection<IGuildChannel> guildChannels;
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;

            guildChannels = await getGuildChannels(i_GuildName);
            if (guildChannels != null)
            {
                foreach (IGuildChannel channel in guildChannels)
                {
                    if (channel.Name.Equals(m_Controller.PickedChannel))
                    {
                        guildUsers = channel.GetUsersAsync();
                    }
                }
            }

            return guildUsers;
        }

        private async void setGuildsComboBoxValues()
        {
            IReadOnlyCollection<IGuild> guilds;
            List<string> comboBoxValues = new List<string>();

            guilds = await getGuilds();
            foreach (IGuild guild in guilds)
            {
                comboBoxValues.Add(guild.Name);
            }

            m_Controller.SetGuildsComboBoxValues(comboBoxValues);
            m_Log.LogGuildsLoaded();
        }

        private async void setChannelsComboBoxValues()
        {
            IReadOnlyCollection<IGuildChannel> guildChannels;
            List<string> comboBoxValues = new List<string>();

            guildChannels = await getGuildChannels(m_Controller.PickedGuild);
            if (guildChannels != null)
            {
                foreach (IGuildChannel channel in guildChannels)
                {
                    if (channel is IVoiceChannel)
                    {
                        comboBoxValues.Add(channel.Name);
                    }
                }
            }

            m_Controller.SetChannelsComboBoxValues(comboBoxValues);
            m_Log.LogChannelsLoaded();
        }

        private async void setUsersListBoxValues()
        {
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;
            List<string> listBoxValues = new List<string>();
            IReadOnlyCollection<IGuildUser> users;
            string userNickName;

            guildUsers = await getGuildChannelUsers(m_Controller.PickedGuild, m_Controller.PickedChannel);
            if (guildUsers != null)
            {
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
            }

            m_Controller.SetCheckedListBoxValues(listBoxValues);
            m_Log.LogUsersLoaded();
        }

        private async void setMuteStateToUserIfNeeded(IGuildUser i_User, bool i_MuteState)
        {
            bool taskCompleted;
            IGuildUser userUpdatedState;

            if (i_User.IsMuted != i_MuteState)
            {
                m_Log.LogUserMuteStateAttempted(i_User, i_MuteState);
                await i_User.ModifyAsync(props => props.Mute = i_MuteState);
                userUpdatedState = await i_User.VoiceChannel.GetUserAsync(i_User.Id);
                taskCompleted = userUpdatedState.IsMuted == i_MuteState;
                m_Log.LogUserMuteStateResult(i_User, i_MuteState, taskCompleted);
            }
            else
            {
                m_Log.LogUserMuteStateAlreadyExists(i_User, i_MuteState);
            }
        }

        private async void setMuteStateToAllUsers(string i_GuildName, string i_ChannelName, bool i_MuteState)
        {
            const bool k_AllUsers = true;
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;

            m_Log.LogMassiveMuteStateAttempted(i_GuildName, i_ChannelName, i_MuteState, k_AllUsers);
            guildUsers = await getGuildChannelUsers(i_GuildName, i_ChannelName);
            if (guildUsers != null)
            {
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
        }

        private async void setMuteStateToSelectedUsers(string i_GuildName, string i_ChannelName, List<string> i_Users, bool i_MuteState)
        {
            bool k_AllUsers = false;
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;
            string userNickName;

            m_Log.LogMassiveMuteStateAttempted(i_GuildName, i_ChannelName, i_MuteState, k_AllUsers);
            guildUsers = await getGuildChannelUsers(i_GuildName, i_ChannelName);
            if (guildUsers != null)
            {
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
}
