using System;
using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;






public sealed class IniSection ( string name ) : IIniSection
{
    
    private readonly List<IIniSectionAddAble> _elements = [];

    
    
    
    
    
    
    
    public string Name { get; } = name;

    
    
    
    
    
    
    
    
    
    public IReadOnlyList<IIniSectionAddAble> Elements => _elements;

    
    
    
    
    public void AddElement(IIniSectionAddAble element)
    {
        if (element is null)
        {
            throw new ArgumentNullException(nameof(element));
        }
        _elements.Add(element);
    }
    
    
    
    
    
    
    
    private static string ToSectionKey ( string? sectionName ) => sectionName?.Trim() ?? string.Empty;

    
    
    
    
    
    
    
    public int CompareTo ( IIniSection? other ) { return other is null ? 1 : string.Compare ( ToSectionKey ( Name ) , ToSectionKey ( other.Name ) , StringComparison.OrdinalIgnoreCase ); }

    
    
    
    
    
    
    
    public bool Equals ( IIniSection? other ) { return other is not null && ( ReferenceEquals ( this , other ) || string.Equals ( ToSectionKey ( Name ) , ToSectionKey ( other.Name ) , StringComparison.OrdinalIgnoreCase ) ); }

    
    
    
    
    
    
    
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniSection ); }

    
    
    
    
    
    
    
    public override int GetHashCode()
    {
        
        return StringComparer.OrdinalIgnoreCase.GetHashCode(ToSectionKey(Name));
    }

    
    
    
    
    
    
    
    
    public static bool operator == ( IniSection? left , IniSection? right ) { return left is null ? right is null : left.Equals ( right ); }

    
    
    
    
    
    
    
    
    public static bool operator != ( IniSection? left , IniSection? right ) => !( left == right );
}