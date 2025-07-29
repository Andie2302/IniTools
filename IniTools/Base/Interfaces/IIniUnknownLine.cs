namespace IniTools.Base.Interfaces;

public interface IIniUnknownLine : IIniLine, IIniSectionAddAble
{
    string? Line { get; set; }
}