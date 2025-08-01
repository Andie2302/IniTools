using System;
using System.Collections;
using System.Collections.Generic;
using IniTools.Base.Interfaces;
using IniTools.Collections.Enums;
using IniTools.Collections.Interfaces;

namespace IniTools.Collections.Classes;

public class IniSectionList ( string sectionName ) : IIniSectionList
{
    private readonly List< IIniSection > _sections = [ ];
    public string SectionName { get; } = sectionName?.Trim() ?? string.Empty;
    public bool IsGlobal => SectionName == string.Empty;

    public bool IsValidItem ( IIniSection? item , out IniCheckItemErrors error )
    {
        if ( item == null ) {
            error = IniCheckItemErrors.ItemIsNull;

            return false;
        }

        if ( !IsGlobal && !string.Equals ( item.Name , SectionName , StringComparison.OrdinalIgnoreCase ) ) {
            error = IniCheckItemErrors.NameNotMatching;

            return false;
        }

        error = IniCheckItemErrors.Success;

        return true;
    }

    #region IList Implementation (mit Korrekturen)
    public bool Add ( IIniSection item , out IniCheckItemErrors error )
    {
        if ( !IsValidItem ( item , out error ) ) { return false; }

        _sections.Add ( item );

        return true;
    }

    void ICollection< IIniSection >.Add ( IIniSection item ) { Add ( item , out _ ); }

    public bool Insert ( int index , IIniSection item , out IniCheckItemErrors error )
    {
        if ( !IsValidItem ( item , out error ) ) { return false; }

        _sections.Insert ( index , item );

        return true;
    }

    public IIniSection this [ int index ]
    {
        get => _sections[index];
        set => TrySetItem ( index , value , out _ );
    }

    public bool TrySetItem ( int index , IIniSection value , out IniCheckItemErrors error )
    {
        if ( !IsValidItem ( value , out error ) ) { return false; }

        _sections[index] = value;

        return true;
    }

    public IEnumerator< IIniSection > GetEnumerator() => _sections.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public void Clear() { _sections.Clear(); }
    public bool Contains ( IIniSection item ) => _sections.Contains ( item );
    public void CopyTo ( IIniSection[] array , int arrayIndex ) { _sections.CopyTo ( array , arrayIndex ); }
    public bool Remove ( IIniSection item ) => _sections.Remove ( item );
    public int Count => _sections.Count;
    public bool IsReadOnly => ( (ICollection< IIniSection >) _sections ).IsReadOnly;
    public int IndexOf ( IIniSection item ) => _sections.IndexOf ( item );
    void IList< IIniSection >.Insert ( int index , IIniSection item ) { Insert ( index , item , out _ ); }
    public void RemoveAt ( int index ) { _sections.RemoveAt ( index ); }
    #endregion
}
