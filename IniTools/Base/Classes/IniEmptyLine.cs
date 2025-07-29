using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniEmptyLine : IIniEmptyLine
{
    public bool Equals ( IIniEmptyLine other ) => throw new System.NotImplementedException();

    public int CompareTo ( IIniEmptyLine other ) => throw new System.NotImplementedException();
}