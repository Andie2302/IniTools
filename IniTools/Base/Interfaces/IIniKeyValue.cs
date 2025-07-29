namespace IniTools.Base.Interfaces;

/// <summary>
/// Represents a key-value pair in an INI configuration.
/// This interface is used to define a structure where each key is associated
/// with a corresponding value within an INI section.
/// </summary>
public interface IIniKeyValue : IIniLine< IIniKeyValue > , IIniSectionAddAble
{
    /// <summary>
    /// Gets or sets the key of the INI key-value pair.
    /// </summary>
    /// <remarks>
    /// The <c>Key</c> property represents the unique identifier or name for a specific
    /// value within a section of an INI configuration file. It is used in conjunction
    /// with the <c>Value</c> property to store and retrieve configuration data.
    /// </remarks>
    string Key { get; set; }
    /// Gets or sets the value associated with the key in an INI file.
    /// This property represents the string value assigned to a specific key
    /// in a key-value pair within an INI configuration format.
    string Value { get; set; }
}
