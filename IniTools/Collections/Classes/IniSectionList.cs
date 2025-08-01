using System;
using System.Collections.Generic;
using IniTools.Base.Interfaces;
using IniTools.Collections.Enums;
using IniTools.Collections.Interfaces;

namespace IniTools.Collections.Classes;

public class IniSectionList ( string sectionName ) : IIniSectionList
{
    private readonly List< IIniSection > _sections = [ ];
    public string SectionName { get; } = sectionName?.Trim() ?? string.Empty;
    public IReadOnlyList< IIniSection > Sections => _sections.AsReadOnly();

    public bool TryAdd ( IIniSection item , out IniSetItemErrors error )
    {
        if ( item is null ) {
            error = IniSetItemErrors.SectionIsNull;

            return false;
        }

        if ( !string.Equals ( item.Name , SectionName , StringComparison.OrdinalIgnoreCase ) ) {
            error = IniSetItemErrors.NameMismatch;

            return false;
        }

        _sections.Add ( item );
        error = IniSetItemErrors.Success;

        return true;
    }
}
