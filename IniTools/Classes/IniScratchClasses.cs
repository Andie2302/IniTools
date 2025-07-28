using IniTools.Interfaces;

namespace IniTools.Classes;

public class IniScratchClasses;

public sealed class IniEmptyLine : IIniEmptyLine;

public sealed class IniComment(string? prefix, string? separator, string? comment) : IIniComment
{
    public string? Comment { get; set; } = comment;
}
public sealed class IniKeyValue(string? key, string? value, string? separator) : IIniKeyValue
{
    public string? Key { get; set; } = key;
    public string? Value { get; set; } = value;
}
public sealed class IniUnknownLine(string? line) : IIniUnknownLine
{
    public string? Line { get; set; } = line;
}
public sealed class IniSectionName(string? name) : IIniSectionName
{
    public string? Name { get; set; } = name;
}