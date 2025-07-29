namespace IniTools.Base.Interfaces;

public interface IIniKeyValue : IIniLine, IIniSectionAddAble
{
    string? Key { get; set; }
    string? Value { get; set; }
}