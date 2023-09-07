using Discord.WebSocket;
using sallybot;

namespace SallyBot
{
    internal static class MainGlobal
    {
        internal static SocketGuild Server { get; set; }
        internal static DiscordSocketClient Client { get; set; }

        internal static string conS = DI.Resolve<Configuration>().DiscordBotToken;
        internal static ulong guildId = DI.Resolve<Configuration>().GuildId;
    }
}
