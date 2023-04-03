namespace MozartUI.Services.Template.DTO
{
    public class GetProductionGanttData
    {
        public string? ItemId { get; set; }
        public string? SiteId { get; set; }
        public string? BufferId { get; set; }
        public string? SoId { get; set; }
        public string? ResourceId { get; set; }
        public int OutPlanUnitQty { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? TargetDateTime { get; set; }
    }
}