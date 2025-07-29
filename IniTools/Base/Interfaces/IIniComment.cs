namespace IniTools.Base.Interfaces;

public interface IIniComment : IIniLine<IIniComment>, IIniSectionAddAble
{
    string? Comment { get; set; }
}