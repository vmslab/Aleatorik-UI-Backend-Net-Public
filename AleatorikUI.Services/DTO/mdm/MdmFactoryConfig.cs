namespace AleatorikUI.Services.DTO.mdm;

public class MdmFactoryConfig
{
    public int factoryStartHour { get; set; }
    public string? startDayOfWeek { get; set; }
    public DateTime? createDatetime { get; set; }
    public string? createUser { get; set; }
    public DateTime? updateDatetime { get; set; }
    public string? updateUser { get; set; }
}