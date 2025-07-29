namespace IniTools.Base.Interfaces;

public interface IIniKeyValue : IIniLine<IIniKeyValue>, IIniSectionAddAble
{
    string? Key { get; set; }
    string? Value { get; set; }
}