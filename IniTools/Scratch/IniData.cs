using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IniTools.Base.Classes;
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

    #region Verbesserte Hilfsmethoden
    public string? GetValue ( string sectionName , string key ) => TryGetValue ( sectionName , out var section ) ? section.Elements.OfType< IIniKeyValue >().FirstOrDefault ( kv => string.Equals ( kv.Key , key , StringComparison.OrdinalIgnoreCase ) )?.Value : null;

    public void SetValue ( string sectionName , string key , string value )
    {
        if ( !TryGetValue ( sectionName , out var section ) ) {
            section = new IniSection ( sectionName );
            Add ( section );
        }

        var keyValuePair = section.Elements.OfType< IIniKeyValue >().FirstOrDefault ( kv => string.Equals ( kv.Key , key , StringComparison.OrdinalIgnoreCase ) );

        if ( keyValuePair != null ) { keyValuePair.Value = value; }
        else { section.Elements.Add ( new IniKeyValue ( key , value ) ); }
    }
    #endregion

    #region Fluent API
    public IniSectionBuilder WithSection ( string sectionName )
    {
        if ( TryGetValue ( sectionName , out var section ) ) { return new IniSectionBuilder ( this , section ); }

        section = new IniSection ( sectionName );
        Add ( section );

        return new IniSectionBuilder ( this , section );
    }
    #endregion

    #region Indexer-Zugriff
    public string? this [ string sectionName , string key ]
    {
        get => GetValue ( sectionName , key );
        set { SetValue ( sectionName , key , value ?? string.Empty ); }
    }
    #endregion

    #region Typenkonvertierung
    public T? GetValue < T > ( string sectionName , string key )
    {
        var stringValue = GetValue ( sectionName , key );

        if ( stringValue is null ) { return default; }

        try {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter ( typeof ( T ) );

            return (T?) converter.ConvertFromString ( null , System.Globalization.CultureInfo.InvariantCulture , stringValue );
        }
        catch ( Exception ex ) { throw new FormatException ( $"Der Wert '{stringValue}' für den Schlüssel '{key}' in der Sektion '{sectionName}' konnte nicht in den Typ {typeof ( T ).Name} konvertiert werden." , ex ); }
    }

    public bool TryGetValue < T > ( string sectionName , string key , out T? value )
    {
        var stringValue = GetValue ( sectionName , key );

        if ( stringValue is null ) {
            value = default;

            return false;
        }

        try {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter ( typeof ( T ) );
            value = (T?) converter.ConvertFromString ( null , System.Globalization.CultureInfo.InvariantCulture , stringValue );

            return true;
        }
        catch {
            value = default;

            return false;
        }
    }
    #endregion
}
