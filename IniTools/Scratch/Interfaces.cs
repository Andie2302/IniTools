namespace IniTools.Scratch;

public interface IIniSettings;
public sealed class IniParserSettings : IIniSettings
{
    public readonly List<string> CommentPrefixes = [];
    public readonly List<string> KeyValueSeparators = [];
    public IniParserSettings()
    {
        Init();
    }
    private void Init()
    {
        CommentPrefixes.Add(";");
        CommentPrefixes.Add("#");
        KeyValueSeparators.Add("=");
        KeyValueSeparators.Add(":");
    }
}