namespace AleatorikUI.Services.DTO.mdm;

public class MdmBuffer
{
    public string? stageID { get; set; }
    public string? bufferID { get; set; }
    public int sequence { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}