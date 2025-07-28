namespace IniTools.Interfaces;

public interface IIniSection : IIniElement
{
    IIniSectionName? Name { get; }
    List<IIniListAble> Elements { get; }
}