namespace AleatorikUI.Services.DTO.mdm;

public class MdmSetupInfo
{
    public string? setupID { get; set; }
    public string? setupType { get; set; }
    public string? fromCondition { get; set; }
    public string? toCondition { get; set; }
    public int setupTime { get; set; }
    public string? timeUom { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
    public int setupIndex { get; set; }
    public int priority { get; set; }
    public string? setupResource { get; set; }
}