namespace IniTools.Base.Interfaces;

public interface IIniUnknownLine : IIniLine, IIniListAble
{
    string? Line { get; set; }
}