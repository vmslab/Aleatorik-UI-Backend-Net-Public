namespace AleatorikUI.Services.DTO.mdm;

public class MdmDemand
{
    public string? demandID { get; set; }
    public string? itemID { get; set; }
    public string? siteID { get; set; }
    public string? bufferID { get; set; }
    public DateTime? dueDate { get; set; }
    public int demandQty { get; set; }
    public int demandPriority { get; set; }
    public string? custID { get; set; }
    public string? demandType { get; set; }
    public int maxLatenessDay { get; set; }
    public int maxEarlinessDay { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}