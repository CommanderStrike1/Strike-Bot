using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace Strike_Bot
{
    /// <summary>
    /// The purpose of the TestProgram class is to run the first steps to using the Discord (unoffical) .Net wrapper by RogueException.
    ///     -First steps are listed in the Discord.Net documentation, which is displayed in the following link: 
    ///         http://rtd.discord.foxbot.me/en/legacy/getting_started.html#first-steps
    /// </summary>
    class TestProgram
    {
        private DiscordClient _client;

        static void Main(string[] args) => new TestProgram().Start();

        public void Start()
        {
            _client = new DiscordClient();

            // Strike-Bot Echo feature
            /*_client.MessageReceived += async (s, e) =>
            {
                if (!e.Message.IsAuthor)
                {
                    await e.Channel.SendMessage(e.Message.Text);
                }
            };*/

            _client.ExecuteAndWait(async () =>
            {
                Console.WriteLine("TestProgram, 1.0.0");

                await _client.Connect("MTk5OTEyODI0MTg3NjUwMDY0.Cl3X9g.X8MOiaO2QX8a4gmfExx3ZleAD_Q");

                Console.WriteLine("Connected to Discord\n");

                Console.WriteLine("I am in the following servers: ");
                foreach(var server in _client.Servers)
                {
                    Console.WriteLine("." + server.Name);
                }

                Console.WriteLine();
            });
        }
    }
}
