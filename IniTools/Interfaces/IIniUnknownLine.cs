namespace IniTools.Interfaces;

public interface IIniUnknownLine : IIniLine, IIniListAble
{
    string Line { get; set; }
}