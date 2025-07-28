namespace IniTools.Interfaces;

public interface IIniComment : IIniLine, IIniListAble
{
    string Prefix { get; set; }
    string Separator { get; set; }
    string Comment { get; set; }
}