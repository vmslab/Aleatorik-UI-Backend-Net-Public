namespace AleatorikUI.Services.DTO.aor;

public class AorBomMapInfo
{
    public int? ItemLevel { get; set; }
    public string? PlanVersion { get; set; }
    public string? SoItemID { get; set; }
    public string? SoSiteID { get; set; }
    public string? SoBufferID { get; set; }
    public string? BomID { get; set; }
    public string? RoutingID { get; set; }
    public string? BomType { get; set; }
    public string? ItemType { get; set; }
    public int? BomPriority { get; set; }
    public string? FromItemID { get; set; }
    public string? FromSiteID { get; set; }
    public string? FromBufferID { get; set; }
    public int? FromBufferSeq { get; set; }
    public long? FromQty { get; set; }
    public long? FromWipQty { get; set; }
    public long? FromSumWipQty { get; set; }
    public string? ToItemID { get; set; }
    public string? ToSiteID { get; set; }
    public string? ToBufferID { get; set; }
    public int? ToBufferSeq { get; set; }
    public long? ToQty { get; set; }
    public long? ToWipQty { get; set; }
    public long? ToSumWipQty { get; set; }
    public string? IsUsabledetail { get; set; }
    public string? IsUsablebom { get; set; }
    public string? ResourceIDs { get; set; }
    public string? AllResourceIDs { get; set; }
    public long? RoutingTat { get; set; }
    public long? MinCumTat { get; set; }
    public long? MaxCumTat { get; set; }
    public long? LateCumTat { get; set; }
    public long? MaxCumYield { get; set; }
    public string? PrevItemSiteBuffers { get; set; }
    public string? NextItemSiteBuffers { get; set; }
}