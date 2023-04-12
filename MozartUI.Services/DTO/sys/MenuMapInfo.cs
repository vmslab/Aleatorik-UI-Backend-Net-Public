namespace MozartUI.Services.DTO.sys;

public class MenuMapInfo
{
    public string? MenuMapId { get; set; }
    public string? SystemId { get; set; }
    public string? MenuId { get; set; }
    public string? GroupId { get; set; }
    public string? CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Path { get; set; }
    public int Sequence { get; set; }
    public bool? Separator { get; set; }
    public bool? IsRead { get; set; }
    public bool? IsWrite { get; set; }
}