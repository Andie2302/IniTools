namespace IniTools.Base.Interfaces;

public interface IIniUnknownLine : IIniLine< IIniUnknownLine > , IIniSectionAddAble
{
    string Line { get; set; }
}
