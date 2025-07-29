namespace IniTools.Base.Interfaces;

/// <summary>
/// Represents an empty line within an INI configuration.
/// This interface is used to define and manage the behavior of empty lines
/// that appear in INI files, typically for formatting or organizational purposes.
/// </summary>
/// <remarks>
/// IIniEmptyLine extends the functionality from IIniLine and IIniSectionAddAble
/// to provide behavior specific to empty lines in the context of INI structures.
/// </remarks>
public interface IIniEmptyLine : IIniLine<IIniEmptyLine>, IIniSectionAddAble;