using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
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

        public DiscordSocketClient Client
        {
            get
            {
                if(m_Client == null)
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
            //await Task.Delay(Timeout.Infinite);
            await Task.Delay(10000);
        }

        private async Task Client_Ready()
        {
            ChannelAdminController controller = new ChannelAdminController();
            controller.MutePressed += setMuteStateToAllUsers;
            controller.UnmutePressed += setMuteStateToAllUsers;
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(controller);
            await Client.StopAsync();
        }

        private async void setMuteStateToAllUsers(string i_ChannelName, bool i_MuteValue)
        {
            IReadOnlyCollection<IGuild> guilds;
            IReadOnlyCollection<IGuildChannel> guildChannels = null;
            IAsyncEnumerable<IReadOnlyCollection<IGuildUser>> guildUsers = null;

            guilds = await(Client as IDiscordClient).GetGuildsAsync();
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
                        await user.ModifyAsync(props => props.Mute = i_MuteValue);
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
