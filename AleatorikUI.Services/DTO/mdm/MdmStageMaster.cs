namespace AleatorikUI.Services.DTO.mdm;

/// <summary>
/// CFG_STAGE_MASTER
/// </summary>
public class MdmStageMaster
{
    public string? stageID { get; set; }
    public string? description { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}