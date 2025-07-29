using System;
using System.Collections;
using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Scratch;

public class IniData : IDictionary< string , IIniSection >
{
    private readonly Dictionary< string , IIniSection > _sections = new Dictionary< string , IIniSection > ( StringComparer.OrdinalIgnoreCase );
    public IIniSection this [ string key ]
    {
        get => _sections[key];
        set => _sections[key] = value;
    }
    public bool ContainsKey ( string key ) => _sections.ContainsKey ( key );
    public bool TryGetValue ( string key , out IIniSection value ) => _sections.TryGetValue ( key , out value );
    public bool Remove ( string key ) => _sections.Remove ( key );

    public void Add ( IIniSection section )
    {
        if ( section.Name != null ) { _sections.Add ( section.Name , section ); }
    }

    #region IDictionary<string, IIniSection> Implementierung
    public ICollection< string > Keys => _sections.Keys;
    public ICollection< IIniSection > Values => _sections.Values;
    public int Count => _sections.Count;
    public bool IsReadOnly => ( (ICollection< KeyValuePair< string , IIniSection > >) _sections ).IsReadOnly;
    public void Add ( string key , IIniSection value ) => _sections.Add ( key , value );
    public void Add ( KeyValuePair< string , IIniSection > item ) => _sections.Add ( item.Key , item.Value );
    public bool Contains ( KeyValuePair< string , IIniSection > item ) => ( (ICollection< KeyValuePair< string , IIniSection > >) _sections ).Contains ( item );
    public void Clear() => _sections.Clear();
    public void CopyTo ( KeyValuePair< string , IIniSection >[] array , int arrayIndex ) => ( (ICollection< KeyValuePair< string , IIniSection > >) _sections ).CopyTo ( array , arrayIndex );
    public bool Remove ( KeyValuePair< string , IIniSection > item ) => ( (ICollection< KeyValuePair< string , IIniSection > >) _sections ).Remove ( item );
    public IEnumerator< KeyValuePair< string , IIniSection > > GetEnumerator() => _sections.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    #endregion
}
