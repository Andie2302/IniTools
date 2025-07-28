namespace IniTools.Interfaces;

public interface IIniKeyValue : IIniLine, IIniListAble
{
    string? Key { get; set; }
    string? Value { get; set; }
}