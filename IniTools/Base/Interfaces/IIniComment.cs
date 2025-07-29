namespace IniTools.Base.Interfaces;

public interface IIniComment : IIniLine, IIniListAble
{
    string? Comment { get; set; }
}