using System;
using System.Collections.ObjectModel;
using IniTools.Base.Interfaces;

namespace IniTools.Scratch;

public class IniSectionCollection : Collection< IIniSection >
{
    public string SectionName { get; }

    public IniSectionCollection ( string sectionName )
    {
        if ( string.IsNullOrWhiteSpace ( sectionName ) ) { throw new ArgumentException ( "Der Name der Sektions-Liste darf nicht leer sein." , nameof ( sectionName ) ); }

        SectionName = sectionName;
    }

    // Überschreibe nur die Methoden, die Elemente hinzufügen oder ändern.
    protected override void InsertItem ( int index , IIniSection item )
    {
        if ( item == null || !string.Equals ( item.Name , SectionName , StringComparison.OrdinalIgnoreCase ) ) { throw new ArgumentException ( $"Diese Liste akzeptiert nur Sektionen mit dem Namen '{SectionName}'." , nameof ( item ) ); }

        base.InsertItem ( index , item );
    }

    protected override void SetItem ( int index , IIniSection item )
    {
        if ( item == null || !string.Equals ( item.Name , SectionName , StringComparison.OrdinalIgnoreCase ) ) { throw new ArgumentException ( $"Diese Liste akzeptiert nur Sektionen mit dem Namen '{SectionName}'." , nameof ( item ) ); }

        base.SetItem ( index , item );
    }
}
