using System;

namespace ChannelAdminBot
{
    public class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
            => new ChannelAdmitBotLogic().RunAsync().GetAwaiter().GetResult();
    }
}
