namespace IniTools.Base.Interfaces;

public interface IIniLine : IIniElement;
public interface IIniLine< T > : IIniLine, IIniSortAble< T >;