using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChannelAdminBot
{
    public class Program
    {
        private DiscordSocketClient m_Client;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            m_Client = new DiscordSocketClient();
            //m_Client.Log += Log;

            string token = Environment.GetEnvironmentVariable("ChannelAdminBotToken", EnvironmentVariableTarget.User);

            await m_Client.LoginAsync(Discord.TokenType.Bot, token);
            await m_Client.StartAsync();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ChannelAdminController());

            //IMessageChannel i = (IMessageChannel) m_Client.GetChannel((ulong) 11);
            //await i.SendMessageAsync("Test Message");

            await Task.Delay(-1);
        }
    }
}
