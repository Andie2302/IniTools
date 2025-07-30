using System.Collections.Generic;

namespace IniTools.Scratch;

public class IniDictionaryRepository < TKey , TValue > ( IDictionary< TKey , TValue? > store ) : IIniRepository< TKey , TValue > where TKey : notnull where TValue : IKeyedObject< TKey >?
{
    public int Count => store.Count;
    public bool TryGetValue ( TKey key , out TValue? value ) { return store.TryGetValue ( key , out value ); }

    public bool TryAdd ( TValue? value , out IniStoreError error )
    {
        if ( value != null && store.ContainsKey ( value.Key ) ) {
            error = IniStoreError.DuplicateKey;

            return false;
        }

        if ( value != null ) { store.Add ( value.Key , value ); }

        error = IniStoreError.None;

        return true;
    }

    public bool TryRemove ( TKey key , out IniStoreError error )
    {
        if ( !store.Remove ( key ) ) {
            error = IniStoreError.KeyNotFound;

            return false;
        }

        error = IniStoreError.None;

        return true;
    }

    public void Clear() { store.Clear(); }

    public bool TryUpdateKey ( TKey oldKey , TKey newKey , out IniStoreError error )
    {
        if ( !store.TryGetValue ( oldKey , out var value ) ) {
            error = IniStoreError.KeyNotFound;

            return false;
        }

        store.Remove ( oldKey );

        if ( store.ContainsKey ( newKey ) ) {
            store.Add ( oldKey , value );
            error = IniStoreError.DuplicateKey;

            return false;
        }

        if ( value != null ) {
            value.Key = newKey;
            store.Add ( newKey , value );
        }

        error = IniStoreError.None;

        return true;
    }
}
