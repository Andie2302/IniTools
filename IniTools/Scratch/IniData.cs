using System.Collections.Generic;
using IniTools.Base.Interfaces;

namespace IniTools.Scratch;

public class IniData : IDictionary< IIniSectionName , IIniSection >
{
    private readonly Dictionary< IIniSectionName , IIniSection > _sections = new Dictionary< IIniSectionName , IIniSection >();

}


/*
   private readonly Dictionary< IIniSectionName , IIniSection > _sections = new Dictionary< IIniSectionName , IIniSection >();

   public IIniSection this [ string key ]
   {
       get => ContainsKey ( key ) ? _sections[ToSectionKey ( key )] : IniSection.Create ( ToSectionKey ( key ) );
       set => _sections[ToSectionKey ( key )] = value;
   }
   public void Add ( IIniSection section ) { Add ( ToSectionKey ( section.Name?.Value ) , section ); }
   public void Add ( string key , IIniSection value ) { _sections.Add ( ToSectionKey ( key ) , value ); }
   public bool Remove ( IIniSection section ) { return _sections.Remove ( ToSectionKey ( section.Name?.Value ) ); }

   #region IDictionary Implementation
   public ICollection< string > Keys => _sections.Keys;
   public ICollection< IIniSection > Values => _sections.Values;
   public int Count => _sections.Count;
   public bool IsReadOnly => false;
   public bool ContainsKey ( string key ) => _sections.ContainsKey ( ToSectionKey ( key ) );
   public bool TryGetValue ( string key , out IIniSection value ) { return ( value = _sections[ToSectionKey ( key )] ) != null; }
   public bool Remove ( string key ) => _sections.Remove ( ToSectionKey ( key ) );
   public void Clear() => _sections.Clear();
   public IEnumerator< KeyValuePair< string , IIniSection > > GetEnumerator() => _sections.GetEnumerator();
   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
   public void Add ( KeyValuePair< string , IIniSection > item ) => _sections.Add ( item.Key , item.Value );
   public bool Contains ( KeyValuePair< string , IIniSection > item ) => _sections.ContainsKey ( item.Key );
   public void CopyTo ( KeyValuePair< string , IIniSection >[] array , int arrayIndex ) => ( (ICollection< KeyValuePair< string , IIniSection > >) _sections ).CopyTo ( array , arrayIndex );
   public bool Remove ( KeyValuePair< string , IIniSection > item ) => _sections.Remove ( item.Key );
   #endregion
   //*/
