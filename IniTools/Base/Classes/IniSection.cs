using System;
using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniSection ( string name ) : IIniSection
{
    public string Name { get; } = name;
    public List< IIniSectionAddAble > Elements { get; } = [ ];
    private static string ToSectionKey ( string? sectionName ) => sectionName?.Trim() ?? string.Empty;
    public int CompareTo ( IIniSection? other ) { return other is null ? 1 : string.Compare ( ToSectionKey ( Name ) , ToSectionKey ( other.Name ) , StringComparison.OrdinalIgnoreCase ); }
    public bool Equals ( IIniSection? other ) { return other is not null && ( ReferenceEquals ( this , other ) || string.Equals ( ToSectionKey ( Name ) , ToSectionKey ( other.Name ) , StringComparison.OrdinalIgnoreCase ) ); }
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniSection ); }
    public override int GetHashCode() { return ToSectionKey ( Name ).GetHashCode(); }

    public static bool operator == ( IniSection? left , IniSection? right )
    {
        if ( left is null ) { return right is null; }
        return left.Equals ( right );
    }

    public static bool operator != ( IniSection? left , IniSection? right ) => !( left == right );
}
