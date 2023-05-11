using DSharpPlus.SlashCommands;

namespace ConsoleApp1.Commands {
    public class SlashCommands : ApplicationCommandModule {
        [SlashCommand("Demo-Command", "This is a demo command.")]
        public async Task demo_command(InteractionContext ctx) {
            await ctx.CreateResponseAsync("Hello " + ctx.Member.Nickname + ". This is a demo command");
        }
        [SlashCommand("Repeat", "Repeat an inputted string.")]
        public async Task repeat(InteractionContext ctx, [Option("string", "The string you want to have repeated")] string inputString) {
            await ctx.CreateResponseAsync(inputString);
        }
    }
}
