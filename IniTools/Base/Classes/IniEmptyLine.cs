using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniEmptyLine : IIniEmptyLine
{
    public int CompareTo ( IIniEmptyLine? other ) { return other is null ? 1 : 0; }
    public bool Equals ( IIniEmptyLine? other ) { return other is not null; }
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniEmptyLine ); }
    public override int GetHashCode() { return 0; }
    public static bool operator == ( IniEmptyLine? left , IniEmptyLine? right ) { return left is null && right is null || left is not null && left.Equals ( right ); }
    public static bool operator != ( IniEmptyLine? left , IniEmptyLine? right ) => !( left == right );
}
