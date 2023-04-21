namespace AleatorikUI.Services.DTO.mdm;

public class MdmBomDetailAlt
{
    public string? projectID { get; set; }
    public string? bomID { get; set; }
    public string? itemID { get; set; }
    public string? siteID { get; set; }
    public string? bufferID { get; set; }
    public string? altItemID { get; set; }
    public string? altSiteID { get; set; }
    public string? altBufferID { get; set; }
    public int altPriority { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}