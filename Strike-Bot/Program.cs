using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Strike_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        private DiscordClient _client;

        public void Start()
        {
            _client = new DiscordClient(x =>
            {
                x.AppName = "Strike-Bot";
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            _client.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
                x.HelpMode = HelpMode.Public;
            });

            var token = "placeholder";

            CreateCommands();

            _client.ExecuteAndWait(async () =>
            {
                await _client.Connect(token);
            });
        }

        public void CreateCommands()
        {
            var cService = _client.GetService<CommandService>();

            cService.CreateCommand("ping")
                .Description("returns 'pong'")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("pong");
                });

            cService.CreateCommand("hello")
                .Description("says hello to a user")
                .Parameter("user", ParameterType.Unparsed)
                .Do(async (e) =>
                {
                    var toReturn = $"Hello {e.GetArg("user")}";
                    await e.Channel.SendMessage(toReturn);
                });

            cService.CreateCommand("greetings")
                .Description("mentions and messages a user with a message")
                .Do(async (e) =>
                {
                    List<string> responsesList = new List<string>() { "Suck my ass", "Try me", "Bbbb...Baka!", "Quack" };
                    Random randomizer = new Random();
                    await e.Channel.SendMessage(e.User.Mention + " " + responsesList[randomizer.Next(3)]);
                });
        }
        
        public void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] [{e.Source}] {e.Message}");
        }
    }
}
