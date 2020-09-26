using System;

namespace ChannelAdminBot
{
    //TODO LIST: 1. organize code, 2. guild picker, 3. keyboard shortcuts
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
