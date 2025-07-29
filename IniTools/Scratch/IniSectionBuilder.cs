using System;
using System.Linq;
using IniTools.Base.Classes;
using IniTools.Base.Interfaces;

namespace IniTools.Scratch;

public sealed class IniSectionBuilder
{
    private readonly IniData _iniData;
    private readonly IIniSection _section;

    internal IniSectionBuilder ( IniData iniData , IIniSection section )
    {
        _iniData = iniData;
        _section = section;
    }

    public IniSectionBuilder Set ( string key , string? value )
    {
        var kvp = _section.Elements.OfType< IIniKeyValue >().FirstOrDefault ( k => string.Equals ( k.Key , key , StringComparison.OrdinalIgnoreCase ) );

        if ( kvp != null ) { kvp.Value = value; }
        else { _section.Elements.Add ( new IniKeyValue ( key , value ) ); }

        return this;
    }

    public IniSectionBuilder WithComment ( string? comment )
    {
        _section.Elements.Add ( new IniComment ( comment ) );

        return this;
    }

    public IniSectionBuilder WithEmptyLine()
    {
        _section.Elements.Add ( new IniEmptyLine() );

        return this;
    }

    public IniSectionBuilder WithSection ( string sectionName ) { return _iniData.WithSection ( sectionName ); }
}