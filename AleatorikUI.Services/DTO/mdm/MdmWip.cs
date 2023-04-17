namespace AleatorikUI.Services.DTO.mdm;

public class MdmWip
{
    public string? lotID { get; set; }
    public string? stageID { get; set; }
    public string? lotType { get; set; }
    public int lotQty { get; set; }
    public string? status { get; set; }
    public string? itemID { get; set; }
    public string? siteID { get; set; }
    public string? bufferID { get; set; }
    public string? routingID { get; set; }
    public string? operationID { get; set; }
    public string? resourceID { get; set; }
    public DateTime? availableTime { get; set; }
    public DateTime? trackInTime { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}