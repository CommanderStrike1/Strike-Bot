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
    class TestProgram1
    {
        /// <summary>
        /// Creates a new DiscordClient object to be used
        /// </summary>
        private DiscordClient _client;

        /// <summary>
        /// Initalizing the program, running the Start() function
        /// </summary>
        /// <param name="args"></param>
        //static void Main(string[] args) => new TestProgram1().Start();

        /// <summary>
        /// Runs on bot startup
        /// </summary>
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
                _client.MessageReceived += Bot_MessageRecieved;

                Console.WriteLine("TestProgram: 1.0.0");

                // Forces the program to wait until the bot is fully connected
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

        private void Bot_MessageRecieved(object sender, MessageEventArgs e)
        {
            if (e.Message.IsAuthor) return;

            if (e.Message.Text.ToLower() == "!Greetings")
            {
                e.Channel.SendMessage("Suck my ass <3");
            }

            if (e.Message.Text.ToLower() == "!Test")
            {
                e.Channel.SendMessage(e.User.Mention + " " + "I am your boss ;-)");
            }

        }
    }
}
