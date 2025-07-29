namespace IniTools.Base.Interfaces;

public interface IIniComment : IIniLine, IIniSectionAddAble
{
    string? Comment { get; set; }
}