using System;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniComment ( string comment ) : IIniComment
{
    public string Comment { get; set; } = comment;
    public int CompareTo ( IIniComment? other ) { return other is null ? 1 : string.Compare ( Comment , other.Comment , StringComparison.OrdinalIgnoreCase ); }
    public bool Equals ( IIniComment? other ) { return other is not null && ( ReferenceEquals ( this , other ) || string.Equals ( Comment , other.Comment , StringComparison.OrdinalIgnoreCase ) ); }
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniComment ); }
    public override int GetHashCode() { return StringComparer.OrdinalIgnoreCase.GetHashCode ( Comment ?? "" ); }
    public static bool operator == ( IniComment? left , IniComment? right ) { return left is null ? right is null : left.Equals ( right ); }
    public static bool operator != ( IniComment? left , IniComment? right ) => !( left == right );
}
