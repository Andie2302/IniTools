using System.Collections.Generic;
using IniTools.Base.Interfaces;
using IniTools.Collections.Enums;

namespace IniTools.Collections.Interfaces;

public interface IIniSectionList : IList< IIniSection >
{
    string SectionName { get; }
    bool IsGlobal { get; }
    int Count { get; }
    bool IsReadOnly { get; }
    IIniSection this [ int index ] { get; set; }
    bool IsValidItem ( IIniSection? item , out IniCheckItemErrors error );
    bool Add ( IIniSection item , out IniCheckItemErrors error );
    bool Insert ( int index , IIniSection item , out IniCheckItemErrors error );
    bool TrySetItem ( int index , IIniSection value , out IniCheckItemErrors error );
    IEnumerator< IIniSection > GetEnumerator();
    void Clear();
    bool Contains ( IIniSection item );
    void CopyTo ( IIniSection[] array , int arrayIndex );
    bool Remove ( IIniSection item );
    int IndexOf ( IIniSection item );
    void RemoveAt ( int index );
}
