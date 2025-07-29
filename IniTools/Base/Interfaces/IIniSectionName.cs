namespace IniTools.Base.Interfaces;

public interface IIniSectionName : IIniLine
{
    string? Value { get; set; }
}