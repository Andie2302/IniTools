using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

/// <summary>
/// Represents an empty line in an INI file structure.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IIniEmptyLine"/> interface and is used to handle scenarios
/// where an empty line is required in the context of an INI configuration file. It provides overrides
/// for comparison, equality, and hash code methods to ensure proper behavior when used in collections
/// or comparisons.
/// </remarks>
/// <seealso cref="IIniEmptyLine"/>
/// <seealso cref="IIniLine"/>
/// <seealso cref="IIniElement"/>
/// <seealso cref="IIniSortAble{T}"/>
/// <seealso cref="IIniSectionAddAble"/>
public sealed class IniEmptyLine : IIniEmptyLine
{
    /// <summary>
    /// Compares the current <see cref="IniEmptyLine"/> instance to another object
    /// that implements <see cref="IIniEmptyLine"/> to determine their relative order.
    /// </summary>
    /// <param name="other">
    /// An object that implements <see cref="IIniEmptyLine"/> to compare with the current instance.
    /// </param>
    /// <returns>
    /// A value indicating the relative order of the current object and the <paramref name="other"/> object.
    /// Returns 1 if <paramref name="other"/> is null; otherwise, returns 0.
    /// </returns>
    public int CompareTo ( IIniEmptyLine? other ) { return other is null ? 1 : 0; }

    /// <summary>
    /// Determines whether the specified <see cref="IIniEmptyLine"/> is equal to the current instance.
    /// </summary>
    /// <param name="other">
    /// The <see cref="IIniEmptyLine"/> to compare with the current instance.
    /// </param>
    /// <returns>
    /// <c>true</c> if the specified <see cref="IIniEmptyLine"/> is not <c>null</c>; otherwise, <c>false</c>.
    /// </returns>
    public bool Equals ( IIniEmptyLine? other ) { return other is not null; }

    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="IniEmptyLine"/> instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>True if the specified object is equal to the current instance; otherwise, false.</returns>
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniEmptyLine ); }

    /// <summary>
    /// Returns a hash code for the current instance of IniEmptyLine.
    /// </summary>
    /// <returns>
    /// An integer representing a consistent hash code for this instance.
    /// This implementation always returns 0, reflecting the immutability
    /// and equality of all IniEmptyLine instances.
    /// </returns>
    public override int GetHashCode() { return 0; }

    /// <summary>
    /// Defines the equality comparison operator for two <see cref="IniEmptyLine"/> instances.
    /// </summary>
    /// <param name="left">The first instance of <see cref="IniEmptyLine"/> to compare.</param>
    /// <param name="right">The second instance of <see cref="IniEmptyLine"/> to compare.</param>
    /// <returns>
    /// <see langword="true"/> if both instances are <see langword="null"/> or if the instances are equal;
    /// otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator == ( IniEmptyLine? left , IniEmptyLine? right ) { return left is null && right is null || left is not null && left.Equals ( right ); }

    /// <summary>
    /// Compares two <see cref="IniEmptyLine"/> objects for inequality.
    /// </summary>
    /// <param name="left">The first <see cref="IniEmptyLine"/> object to compare.</param>
    /// <param name="right">The second <see cref="IniEmptyLine"/> object to compare.</param>
    /// <returns>
    /// Returns <c>true</c> if the objects are not equal; otherwise, <c>false</c>.
    /// </returns>
    public static bool operator != ( IniEmptyLine? left , IniEmptyLine? right ) => !( left == right );
}
