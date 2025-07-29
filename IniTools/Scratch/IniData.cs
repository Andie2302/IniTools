using System.Collections.Generic;
using IniTools.Base.Interfaces;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using IniTools.Base.Classes;

namespace IniTools.Scratch;

public class IniData : IDictionary< IIniSectionName , IIniSection >
{
    private readonly Dictionary< IIniSectionName , IIniSection > _sections = new( new IniSectionNameComparer() );

    #region String-basierte Hilfsmethoden
    /// <summary>
    /// Ruft eine Sektion über ihren Namen ab oder legt sie fest.
    /// </summary>
    public IIniSection this [ string key ]
    {
        get => _sections[new IniSectionName ( key )];
        set => _sections[new IniSectionName ( key )] = value;
    }

    /// <summary>
    /// Prüft, ob eine Sektion mit dem gegebenen Namen existiert.
    /// </summary>
    public bool ContainsKey ( string key ) => _sections.ContainsKey ( new IniSectionName ( key ) );

    /// <summary>
    /// Versucht, eine Sektion sicher abzurufen.
    /// </summary>
    public bool TryGetValue ( string key , [ MaybeNullWhen ( false ) ] out IIniSection value ) { return _sections.TryGetValue ( new IniSectionName ( key ) , out value ); }

    /// <summary>
    /// Entfernt eine Sektion anhand ihres Namens.
    /// </summary>
    public bool Remove ( string key ) => _sections.Remove ( new IniSectionName ( key ) );
    #endregion

    #region IDictionary<IIniSectionName, IIniSection> Implementierung
    public IIniSection this [ IIniSectionName key ]
    {
        get => _sections[key];
        set => _sections[key] = value;
    }
    public ICollection< IIniSectionName > Keys => _sections.Keys;
    public ICollection< IIniSection > Values => _sections.Values;
    public int Count => _sections.Count;
    public bool IsReadOnly => ( (ICollection< KeyValuePair< IIniSectionName , IIniSection > >) _sections ).IsReadOnly;
    public void Add ( IIniSectionName key , IIniSection value ) => _sections.Add ( key , value );

    public void Add ( IIniSection section )
    {
        if ( section.Name != null ) { _sections.Add ( section.Name , section ); }
    }

    public void Add ( KeyValuePair< IIniSectionName , IIniSection > item ) => _sections.Add ( item.Key , item.Value );
    public bool ContainsKey ( IIniSectionName key ) => _sections.ContainsKey ( key );
    public bool TryGetValue ( IIniSectionName key , [ MaybeNullWhen ( false ) ] out IIniSection value ) => _sections.TryGetValue ( key , out value );
    public bool Remove ( IIniSectionName key ) => _sections.Remove ( key );
    public bool Remove ( KeyValuePair< IIniSectionName , IIniSection > item ) => ( (ICollection< KeyValuePair< IIniSectionName , IIniSection > >) _sections ).Remove ( item );
    public bool Contains ( KeyValuePair< IIniSectionName , IIniSection > item ) => ( (ICollection< KeyValuePair< IIniSectionName , IIniSection > >) _sections ).Contains ( item );
    public void Clear() => _sections.Clear();
    public void CopyTo ( KeyValuePair< IIniSectionName , IIniSection >[] array , int arrayIndex ) => ( (ICollection< KeyValuePair< IIniSectionName , IIniSection > >) _sections ).CopyTo ( array , arrayIndex );
    public IEnumerator< KeyValuePair< IIniSectionName , IIniSection > > GetEnumerator() => _sections.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _sections.GetEnumerator();
    #endregion
}