using IniTools.Interfaces;

namespace IniTools.Classes;

public sealed class IniUnknownLine(string? line) : IIniUnknownLine
{
    public string? Line { get; set; } = line;
}