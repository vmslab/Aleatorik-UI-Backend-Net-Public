namespace AleatorikUI.Services.DTO.mdm;

public class MdmCustInfo
{
    public string? customerID { get; set; }
    public string? customerName { get; set; }
    public int priority { get; set; }
    public DateTime? createTime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateTime { get; set; }
    public string? updateUser { get; set; }
}