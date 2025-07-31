using System;
using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

public sealed class IniSection ( string name ) : IIniSection
{
    private const StringComparison SectionNameComparison = StringComparison.OrdinalIgnoreCase;
    private static readonly StringComparer SectionNameComparer = StringComparer.OrdinalIgnoreCase;
    public string Name { get; } = name?.Trim() ?? string.Empty;
    private readonly List< IIniSectionAddAble > _elements = [ ];
    public IReadOnlyList< IIniSectionAddAble > Elements => _elements;

    public bool AddElement ( IIniSectionAddAble? element )
    {
        if ( element is null ) { return false; }

        _elements.Add ( element );

        return true;
    }

    public int CompareTo ( IIniSection? other ) => string.Compare ( Name , other?.Name , SectionNameComparison );
    public bool Equals ( IIniSection? other ) => other is not null && ( ReferenceEquals ( this , other ) || SectionNameComparer.Equals ( Name , other.Name ) );
    public override bool Equals ( object? obj ) => Equals ( obj as IIniSection );
    public override int GetHashCode() => SectionNameComparer.GetHashCode ( Name );
    public static bool operator == ( IniSection? left , IniSection? right ) => left?.Equals ( right ) ?? right is null;
    public static bool operator != ( IniSection? left , IniSection? right ) => !( left == right );
    public override string ToString() => $"[{Name}] ({Elements.Count} elements)";
}
