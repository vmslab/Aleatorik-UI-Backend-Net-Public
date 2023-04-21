namespace AleatorikUI.Services.DTO.mdm;

/// <summary>
/// DTO �� ���� �����Դϴ�.
/// </summary>
public class MdmAllocGroupMaster
{
    public string? projectID { get; set; }
    public string? allocationGroupID { get; set; }
    public int? allocationGroupSeq { get; set; }
    public string? allocationType { get; set; }
    public DateTime? stageID { get; set; }
    public string? description { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}