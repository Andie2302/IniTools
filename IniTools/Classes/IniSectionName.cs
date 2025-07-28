using IniTools.Interfaces;

namespace IniTools.Classes;

public sealed class IniSectionName(string? name) : IIniSectionName
{
    public string? Name { get; set; } = name;
}