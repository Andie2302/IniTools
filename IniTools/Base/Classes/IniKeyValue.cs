using System;
using IniTools.Base.Interfaces;

namespace IniTools.Base.Classes;

/// <summary>
/// The <c>IniKeyValue</c> class represents a key-value pair in an INI file.
/// </summary>
/// <remarks>
/// This class implements the <c>IIniKeyValue</c> interface and provides comparison and equality logic
/// for key-value pairs. It is designed to handle case-insensitive operations for both keys and values.
/// </remarks>
/// <example>
/// The <c>IniKeyValue</c> class can be used to model entries in INI configuration files,
/// where each entry consists of a key and a value.
/// </example>
public sealed class IniKeyValue ( string key , string value ) : IIniKeyValue
{
    /// <summary>
    /// Gets or sets the key of the key-value pair in an INI configuration.
    /// Represents the identifying name that maps to a corresponding value.
    /// The key is expected to be unique within the associated INI section.
    /// </summary>
    public string Key { get; set; } = key;
    /// <summary>
    /// Gets or sets the value associated with a key in an INI configuration file.
    /// This property represents the data linked to a specific key within a
    /// key-value pair structure.
    /// </summary>
    public string Value { get; set; } = value;

    /// <summary>
    /// Compares the current <see cref="IniKeyValue"/> instance to another <see cref="IIniKeyValue"/> instance
    /// and determines their relative order based on their keys and values, ignoring case.
    /// </summary>
    /// <param name="other">The other <see cref="IIniKeyValue"/> instance to compare with the current instance.</param>
    /// <returns>
    /// A value indicating the relative order of the instances:
    /// - A negative value if this instance is less than <paramref name="other"/>.
    /// - Zero if this instance is equal to <paramref name="other"/>.
    /// - A positive value if this instance is greater than <paramref name="other"/>.
    /// </returns>
    public int CompareTo ( IIniKeyValue? other )
    {
        if ( other is null ) { return 1; }

        var keyCompare = string.Compare ( Key , other.Key , StringComparison.OrdinalIgnoreCase );

        return keyCompare != 0 ? keyCompare : string.Compare ( Value , other.Value , StringComparison.OrdinalIgnoreCase );
    }

    /// <summary>
    /// Determines whether the specified IIniKeyValue object is equal to the current instance
    /// based on their key and value properties using a case-insensitive comparison.
    /// </summary>
    /// <param name="other">The IIniKeyValue object to compare with the current instance.</param>
    /// <returns>
    /// true if the specified IIniKeyValue is equal to the current instance; otherwise, false.
    /// Returns false if the specified IIniKeyValue object is null.
    /// </returns>
    public bool Equals ( IIniKeyValue? other ) { return other is not null && ( ReferenceEquals ( this , other ) || string.Equals ( Key , other.Key , StringComparison.OrdinalIgnoreCase ) && string.Equals ( Value , other.Value , StringComparison.OrdinalIgnoreCase ) ); }

    /// <summary>
    /// Determines whether the specified object is equal to the current instance.
    /// This implementation compares the key and value of the object to the key and value of the current instance
    /// using a case-insensitive comparison.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>
    /// true if the specified object is equal to the current instance; otherwise, false.
    /// If <paramref name="obj"/> is not an IIniKeyValue or is null, the method returns false.
    /// </returns>
    public override bool Equals ( object? obj ) { return Equals ( obj as IIniKeyValue ); }

    /// <summary>
    /// Returns a hash code for the current object.
    /// </summary>
    /// <returns>
    /// A 32-bit signed integer hash code consistent with the key and value of the object.
    /// </returns>
    public override int GetHashCode()
    {
        unchecked {
            var hash = 17;
            hash = hash * 23 + ( Key?.ToLowerInvariant() ?? "" ).GetHashCode();
            hash = hash * 23 + ( Value?.ToLowerInvariant() ?? "" ).GetHashCode();

            return hash;
        }
    }

    /// <summary>
    /// Represents an equality comparison operator for instances of the IniKeyValue class.
    /// Determines whether two IniKeyValue objects are considered equal based on their
    /// Key and Value properties.
    /// </summary>
    /// <param name="left">The first IniKeyValue instance to compare.</param>
    /// <param name="right">The second IniKeyValue instance to compare.</param>
    /// <returns>
    /// Returns true if both IniKeyValue instances are equal; otherwise, false.
    /// Two instances are considered equal if both their Key and Value properties
    /// match, ignoring case.
    /// </returns>
    /// <remarks>
    /// If both instances are null, the result is true. If only one instance is null,
    /// the result is false.
    /// </remarks>
    public static bool operator == ( IniKeyValue? left , IniKeyValue? right ) { return left is null ? right is null : left.Equals ( right ); }

    /// <summary>
    /// Represents the inequality operator for the <see cref="IniKeyValue"/> class.
    /// Checks whether two <see cref="IniKeyValue"/> objects are not equal based on their keys and values.
    /// </summary>
    /// <param name="left">The first <see cref="IniKeyValue"/> instance to compare.</param>
    /// <param name="right">The second <see cref="IniKeyValue"/> instance to compare.</param>
    /// <returns>
    /// True if the two <see cref="IniKeyValue"/> instances are not equal;
    /// otherwise, false.
    /// </returns>
    public static bool operator != ( IniKeyValue? left , IniKeyValue? right ) => !( left == right );
}
