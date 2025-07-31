using System;
using System.Collections;
using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Scratch;

public class IniSectionList : IList< IIniSection >
{
    public string SectionName { get; }
    private readonly List< IIniSection > _sections = [ ];

    public IniSectionList ( string sectionName )
    {
        if ( string.IsNullOrWhiteSpace ( sectionName ) ) { throw new ArgumentException ( "Der Name der Sektions-Liste darf nicht leer sein." , nameof ( sectionName ) ); }

        SectionName = sectionName;
    }

    private void CheckItem ( IIniSection item )
    {
        if ( item == null ) { throw new ArgumentNullException ( nameof ( item ) , "Es können keine 'null'-Sektionen hinzugefügt werden." ); }

        if ( !string.Equals ( item.Name , SectionName , StringComparison.OrdinalIgnoreCase ) ) { throw new ArgumentException ( $"Diese Liste akzeptiert nur Sektionen mit dem Namen '{SectionName}'. Die übergebene Sektion hat den Namen '{item.Name}'." , nameof ( item ) ); }
    }

    public void Add ( IIniSection item )
    {
        CheckItem ( item );
        _sections.Add ( item );
    }

    public void Insert ( int index , IIniSection item )
    {
        CheckItem ( item );
        _sections.Insert ( index , item );
    }

    public IIniSection this [ int index ]
    {
        get => _sections[index];
        set
        {
            CheckItem ( value );
            _sections[index] = value;
        }
    }
    public IEnumerator< IIniSection > GetEnumerator() => _sections.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public void Clear() { _sections.Clear(); }

    public bool Contains ( IIniSection item )
    {
        if ( item == null || !string.Equals ( item.Name , SectionName , StringComparison.OrdinalIgnoreCase ) ) { return false; }

        return _sections.Contains ( item );
    }

    public void CopyTo ( IIniSection[] array , int arrayIndex ) { _sections.CopyTo ( array , arrayIndex ); }
    public bool Remove ( IIniSection item ) => _sections.Remove ( item );
    public int Count => _sections.Count;
    public bool IsReadOnly => ( (ICollection< IIniSection >) _sections ).IsReadOnly;
    public int IndexOf ( IIniSection item ) => _sections.IndexOf ( item );
    public void RemoveAt ( int index ) { _sections.RemoveAt ( index ); }
}