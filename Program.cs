using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public static DiscordClient Discord { get; private set; }

        public Task Status(DiscordClient c, HeartbeatEventArgs e)
        {
            var x = new DiscordActivity(name: "", type: ActivityType.Custom);
            Discord.UpdateStatusAsync(x);
            return Task.CompletedTask;
        }
        public async Task MainAsync()
        {

            Discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "",
                TokenType = TokenType.Bot,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,
                LogTimestampFormat = "MMM dd yyyy - hh:mm:ss tt",
                Intents = DiscordIntents.All
            });

            Discord.Heartbeated += Status;

            var commandsConfig = new SlashCommandsConfiguration { }; // Currently blank idk if i will ever need it
            var slash = Discord.UseSlashCommands(commandsConfig);

            slash.RegisterCommands<ConsoleApp1.Commands.SlashCommands>(); // Registers all commands in ConsoleApp1 > Commands > SlashCommands

            await Discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}