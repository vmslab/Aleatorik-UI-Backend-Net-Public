namespace MozartUI.Services.Template.DTO;

public class ResourceGantInfos
{
    public string? NoduleKey { get; set; }
    public string? ResourceId { get; set; }
    public int PlanSeq { get; set; }
    public string? StageId { get; set; }
    public int Phase { get; set; }
    public int Level { get; set; }
    public string? AllocationKey { get; set; }
    public string? SoId { get; set; }
    public string? MoId { get; set; }
    public string? LotId { get; set; }
    public string? BomId { get; set; }
    public string? AllocType { get; set; }
    public string? SoItemId { get; set; }
    public string? SoSiteId { get; set; }
    public string? SoBufferId { get; set; }
    public DateTime? SoDueDate { get; set; }
    public int Priority { get; set; }
    public string? LotGroupKey { get; set; }
    public string? ItemId { get; set; }
    public string? ItemType { get; set; }
    public string? StieId { get; set; }
    public string? BufferId { get; set; }
    public string? RoutingId { get; set; }
    public string? OperationId { get; set; }
    public int Yield { get; set; }
    public int BChgRatio { get; set; }
    public int TotalTat { get; set; }
    public int PlanQty { get; set; }
    public int PlanUnitQty { get; set; }
    public DateTime? ArrivalTime { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public DateTime? ResEndTime { get; set; }
    public string? CreationType { get; set; }
    public string? WipType { get; set; }
    public string? PlanDate { get; set; }
    public string? PlanWeek { get; set; }
    public string? PlanMonth { get; set; }
    public DateTime? TargetDateTime { get; set; }
    public string? TargetDate { get; set; }
    public string? TargetWeek { get; set; }
    public string? TargetMonth { get; set; }
    public int LpstGapDay { get; set; }
    public int MaxLatenessDays { get; set; }
    public DateTime? ExtendedSoDueDate { get; set; }
    public DateTime? ExtendedTargetDate { get; set; }
    public int RetryCount { get; set; }
    public int Load { get; set; }
    public int UsagePer { get; set; }
    public string? OrgLotId { get; set; }

}