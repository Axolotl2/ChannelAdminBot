using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChannelAdminBot
{
    internal class ChannelAdminBotLog
    {
        private Timer r_LogTimer;
        private StringBuilder r_LogString;
        //private DiscordSocketClient r_Client;
        private ChannelAdminController m_Controller;

        public ChannelAdminBotLog()
        {
            r_LogString = new StringBuilder();
            r_LogTimer = new Timer();
            r_LogTimer.Tick += M_LogTimer_Tick;
            r_LogTimer.Interval = 20000;
        }

        public void AttachController(ChannelAdminController i_Controller)
        {
            m_Controller = i_Controller;
            m_Controller.MuteAllPressed += I_Controller_MuteAllPressed;
            m_Controller.UnMuteAllPressed += I_Controller_UnMuteAllPressed;
            m_Controller.MuteSelectedPressed += I_Controller_MuteSelectedPressed;
            m_Controller.UnMuteSelectedPressed += I_Controller_UnMuteSelectedPressed;
            m_Controller.GuildPicked += I_Controller_GuildPicked;
            m_Controller.ChannelPicked += I_Controller_ChannelPicked;
        }

        private void I_Controller_ChannelPicked()
        {
            string channelName = m_Controller.PickedChannel;

            r_LogString.AppendLine(string.Format("Channel {0} picked from the channel list", channelName));
        }

        private void I_Controller_GuildPicked()
        {
            string guildName = m_Controller.PickedGuild;

            r_LogString.AppendLine(string.Format("Guild {0} picked from the guild list", guildName));
        }

        private void I_Controller_UnMuteSelectedPressed(string arg1, string arg2, List<string> arg3, bool arg4)
        {
            r_LogString.AppendLine("UnMuteSelected button pressed");
        }

        private void I_Controller_MuteSelectedPressed(string arg1, string arg2, List<string> arg3, bool arg4)
        {
            r_LogString.AppendLine("MuteSelected button pressed");
        }

        private void I_Controller_UnMuteAllPressed(string arg1, string arg2, bool arg3)
        {
            r_LogString.AppendLine("UnMuteAll button pressed");
        }

        private void I_Controller_MuteAllPressed(string arg1, string arg2, bool arg3)
        {
            r_LogString.AppendLine("MuteAll button pressed");
        }

        public void StartLogging()
        {
            r_LogTimer.Start();
        }

        public void StopLogging()
        {
            r_LogTimer.Stop();
            writeLogStringToFile();
        }

        private void M_LogTimer_Tick(object sender, EventArgs e)
        {
            writeLogStringToFile();
        }

        private void writeLogStringToFile()
        {
            StringBuilder stringLog = new StringBuilder();

            if (r_LogString.Length > 0)
            {
                stringLog.AppendLine(string.Format("Log dump at: {0}", DateTime.Now.ToString()));
                stringLog.AppendLine(r_LogString.ToString());
                File.AppendAllText("log.txt", stringLog.ToString());
                r_LogString.Clear();
            }
        }

        public void LogLoginFailed(Discord.Net.HttpException i_HttpException)
        {
            r_LogString.AppendLine(i_HttpException.Message);
            r_LogString.AppendLine(i_HttpException.ToString());
            writeLogStringToFile();
        }

        public void LogProgramEnded()
        {
            r_LogString.AppendLine("Program has ended");
            StopLogging();
        }
        public void LogClientDisconnected()
        {
            r_LogString.AppendLine("The connection between discord and the application ended");
            StopLogging();
        }

        public void LogGuildsLoaded()
        {
            r_LogString.AppendLine("Guilds loaded");
        }

        public void LogChannelsLoaded()
        {
            r_LogString.AppendLine("Channels loaded");
        }

        public void LogUsersLoaded()
        {
            r_LogString.AppendLine("Users loaded");
        }

        public void LogUserMuteStateAttempted(IGuildUser i_User, bool i_MuteState)
        {
            string userNickName = i_User.Nickname != null ? i_User.Nickname : i_User.Username;

            r_LogString.AppendLine(string.Format("attempted to change mute state of user {0} to {1}", userNickName, i_MuteState.ToString()));
        }

        public void LogUserMuteStateResult(IGuildUser i_User, bool i_MuteState, bool i_TaskCompleted)
        {
            string userNickName = i_User.Nickname != null ? i_User.Nickname : i_User.Username;
            string resultString = i_TaskCompleted ? "succeeded" : "failed";

            r_LogString.AppendLine(string.Format("The attempt to change mute state of user {0} to {1} {2}", userNickName, i_MuteState.ToString(), resultString));
        }

        public void LogUserMuteStateAlreadyExists(IGuildUser i_User, bool i_MuteState)
        {
            string userNickName = i_User.Nickname != null ? i_User.Nickname : i_User.Username;

            r_LogString.AppendLine(string.Format("mute state of user {0} is already {1}, operation skipped", userNickName, i_MuteState.ToString()));
        }


        public void LogMassiveMuteStateAttempted(string i_GuildName, string i_ChannelName, bool i_MuteState, bool i_AllUsers)
        {
            string usersAmount = i_AllUsers ? "all" : "selected";

            r_LogString.AppendLine(string.Format("attempted to massivly change mute state of {0} users at guild {1} channel {2} to {3}", usersAmount, i_GuildName, i_ChannelName,i_MuteState.ToString()));
        }
    }
}
