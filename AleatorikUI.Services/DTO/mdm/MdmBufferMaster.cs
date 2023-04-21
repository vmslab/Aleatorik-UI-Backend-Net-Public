namespace AleatorikUI.Services.DTO.mdm;

public class MdmBufferMaster
{
    public string? projectID { get; set; }
    public string? bufferID { get; set; }
    public int? bufferSeq { get; set; }
    public string? stageID { get; set; }
    public string? description { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}