namespace IniTools.Base;

public sealed class ParsingSettings
{
    public char[] CommentChars { get; init; } = [ ';' , '#' ];
    public char SectionStartChar { get; init; } = '[';
    public char SectionEndChar { get; init; } = ']';
    public char KeyValueSeparator { get; init; } = '=';
    public static ParsingSettings Default => new ParsingSettings();
}