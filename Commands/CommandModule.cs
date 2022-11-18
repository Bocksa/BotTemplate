using DSharpPlus.SlashCommands;

namespace ConsoleApp1.Commands {
    public class SlashCommands : ApplicationCommandModule {
        [SlashCommand("Demo-Command", "This is a demo command.")]
        public async Task demo_command(InteractionContext ctx) {
            await ctx.CreateResponseAsync("Hello " + ctx.Member.Nickname + ". This is a demo command");
        }
    }
}
