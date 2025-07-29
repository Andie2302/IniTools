namespace IniTools.Base.Interfaces;

/// <summary>
/// Represents an interface for elements that can be added to an INI section.
/// </summary>
/// <remarks>
/// This interface is implemented by various INI file components, such as comments,
/// empty lines, key-value pairs, and unknown lines, to allow their inclusion
/// within an INI section. It provides a common base for all these elements,
/// enabling uniform handling within the INI structure.
/// </remarks>
public interface IIniSectionAddAble;