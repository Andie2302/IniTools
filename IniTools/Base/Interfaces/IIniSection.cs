using System.Collections.Generic;

namespace IniTools.Base.Interfaces;

/// <summary>
/// Represents a section in an INI configuration file. This interface defines
/// the structure and behavior of an INI section, including its name and the elements
/// contained within the section.
/// </summary>
public interface IIniSection : IIniSortAble< IIniSection > , IIniElement
{
    /// <summary>
    /// Gets the name of the INI section. The name is used as a unique identifier
    /// for the section within an INI file and is typically represented in square
    /// brackets ([SectionName]) in the INI format.
    /// </summary>
    string Name { get; }
    /// <summary>
    /// Gets the collection of elements within the section.
    /// These elements can include key-value pairs, comments, or empty lines.
    /// </summary>
    IReadOnlyList< IIniSectionAddAble > Elements { get; }
}
