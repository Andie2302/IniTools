using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniUnknownLine(string? line) : IIniUnknownLine
{
    public string? Line { get; set; } = line;
    public bool Equals ( IIniUnknownLine other ) => throw new System.NotImplementedException();

    public int CompareTo ( IIniUnknownLine other ) => throw new System.NotImplementedException();
}