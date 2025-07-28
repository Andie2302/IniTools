namespace IniTools.Interfaces;

public interface IIniComment : IIniLine, IIniListAble
{
    string? Comment { get; set; }
}