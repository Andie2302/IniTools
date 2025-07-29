using System;

namespace IniTools.Base.Interfaces;

/// <summary>
/// Represents a sortable interface for INI-related elements.
/// </summary>
/// <typeparam name="T">The type to be compared or equated.</typeparam>
/// <remarks>
/// This interface provides sorting functionality for INI elements. It combines comparability and equatability,
/// enabling objects implementing this interface to define custom sorting logic and equality checks.
/// Typical use cases include ordering and organizing elements within an INI structure based on custom or predefined criteria.
/// </remarks>
public interface IIniSortAble < T > : IEquatable< T > , IComparable< T > { }