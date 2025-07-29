using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniKeyValue(string? key, string? value) : IIniKeyValue
{
    public string? Key { get; set; } = key;
    public string? Value { get; set; } = value;
    public bool Equals ( IIniKeyValue other ) => throw new System.NotImplementedException();

    public int CompareTo ( IIniKeyValue other ) => throw new System.NotImplementedException();
}