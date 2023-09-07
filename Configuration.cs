using System.Collections.Generic;
namespace sallybot;

public class Configuration
{
    public ulong GuildId { get; set; }
    public string DiscordBotToken { get; set; }
    public string StableDiffusionUrl { get; set; }
    public string OobServerUrl { get; set; }
    public int OobServerPort { get; set; }
    public string BotName { get; set; }
    public ParamInfo ParamInfo { get; set; }
}
public class ParamInfo
{
    public List<string> BannedWords { get; set; } = new() { "p0rnography", "h3ntai" };
    public string BannedWordsExactRegex { get; set; } =
        @"\b(naked|boobs|explicit|nsfw|p0rn|pron|pr0n|butt|booty|s3x|n4ked|r34)\b";
    public string TakeAPicRegex { get; set; } =
        @"\b(take|post|paint|generate|make|draw|create|show|give|snap|capture|send|display|share|shoot|see|provide|another)\b.*(\S\s{0,10})?(image|picture|screenshot|screenie|painting|pic|photo|photograph|portrait|selfie)\b";
    public string PromptEndDetectionRegexStr { get; set; } =
        @"(?:\r\n?)|(\n\[|\n#|\[end|<end|]:|>:|<nooutput|<noinput|\[human|\[chat|\[sally|\[cc|<chat|<cc|\[@chat|\[@cc|bot\]:|<@chat|<@cc|\[.*]: |\[.*] : |\[[^\]]+\]\s*:)";
    public string PromptSpoofDetectionRegexStr { get; set; } = @"\[[^\]]+[\]:\\]\:|\:\]|\[^\]]";
    public string LinkDetectionRegexStr { get; set; } =
        @"[a-zA-Z0-9]((?i) dot |(?i) dotcom|(?i)dotcom|(?i)dotcom |\.|\. | \.| \. |\,)[a-zA-Z]*((?i) slash |(?i) slash|(?i)slash |(?i)slash|\/|\/ | \/| \/ ).+[a-zA-Z0-9]";
}
