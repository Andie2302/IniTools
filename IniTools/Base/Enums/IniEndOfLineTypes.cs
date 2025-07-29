namespace IniTools.Base.Enums;

/// <summary>
/// Represents the Unix-style end-of-line type, which uses '\n' (LF) as the line terminator.
/// Commonly used in Unix-based and Linux-based operating systems.
/// </summary>
public enum IniEndOfLineTypes
{
    /// <summary>
    /// Represents an end-of
    None,
    /// <summary>
    /// Represents the Windows-style end-of-line sequence, typically consisting of a carriage return
    /// followed by a line feed (CR+LF).
    /// </summary>
    Windows,
    /// <summary>
    /// Represents
    Unix,
    /// <summary>
    /// Represents the Mac (Classic Mac OS) style end-of-line type,
    /// which uses the Carriage Return (CR) character ('\r') as its line terminator.
    /// </summary>
    Mac
}