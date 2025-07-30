namespace IniTools.Scratch;

public class IniSection : IKeyedObject< string >
{
    public string Key
    {
        get => Name;
        set => Name = value;
    }
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public override string ToString() => $"{Name} = {Content}";
}