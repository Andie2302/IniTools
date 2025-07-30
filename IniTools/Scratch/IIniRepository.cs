namespace IniTools.Scratch;

public interface IIniRepository < in TKey , TValue > where TValue : IKeyedObject< TKey >?
{
    bool TryGetValue ( TKey key , out TValue? value );
    bool TryAdd ( TValue? value , out IniStoreError error );
    bool TryRemove ( TKey key , out IniStoreError error );
    bool TryUpdateKey ( TKey oldKey , TKey newKey , out IniStoreError error );
    void Clear();
    int Count { get; }
}