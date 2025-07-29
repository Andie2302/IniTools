using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniSectionName(string? name) : IIniSectionName
{
    public string? Value { get; set; } = name;
}