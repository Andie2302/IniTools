using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Scratch;

public static class IniTools
{
    public static IniData CreateIniData() => new IniData();
    public static string ToValidSectionKey ( string? key ) => key?.Trim() ?? string.Empty;
    public static string GetSectionKey ( IIniSection section ) => ToValidSectionKey ( section?.Name?.Value );
}

public class IniData
{
    private readonly Dictionary< string , IIniSection > _sections = new Dictionary< string , IIniSection >();
    public void Add ( IIniSection section ) { _sections[IniTools.ToValidSectionKey ( section.Name?.Value?.Trim() )] = section; }
    public IIniSection? Get ( string name ) { return _sections.TryGetValue ( name , out var section ) ? section : null; }
    public bool Remove ( string name ) { return _sections.Remove ( name ); }
    public void Remove ( IIniSection section ) => _sections.Remove ( IniTools.GetSectionKey ( section ) );
    public void Clear() => _sections.Clear();
}
