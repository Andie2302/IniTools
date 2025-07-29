namespace IniTools.Base.Interfaces;

/// <summary>
/// Represents a comment line within an INI file structure. This interface
/// inherits capabilities for sorting and equality checks, and allows seamless
/// integration into an INI section as an addable element.
/// </summary>
public interface IIniComment : IIniLine<IIniComment>, IIniSectionAddAble
{
    /// <summary>
    /// Represents a comment within an INI file.
    /// </summary>
    /// <remarks>
    /// This property holds the textual content of the comment. Comments are typically used to provide
    /// descriptive or explanatory information within an INI file. Lines within the file starting with
    /// a specific character (e.g., ';' or '#') are treated as comments, depending on the INI specification.
    /// </remarks>
    string Comment { get; set; }
}