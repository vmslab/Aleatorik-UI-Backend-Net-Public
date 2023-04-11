namespace MozartUI.Services.DTO;

public class TodoInfo
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Contents { get; set; }
    public bool? IsFinished { get; set; }
    public DateTime? FinishedDate { get; set; }
    public DateTime? ExpectedDate { get; set; }
    public int Priority { get; set; }
}