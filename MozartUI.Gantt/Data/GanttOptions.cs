namespace AleatorikUI.Gantt.Data
{
    public class GanttOptions
    {
        public string? FileName { get; set; }
        public string[]? Columns { get; set; }
        public double widthRate { get; set; }
        public GanttHeader[]? Headers { get; set; }
        public double RowHeight { get; set; }
        public bool IsFillCell { get; set; }
        public int DayStartTime { get; set; }
    }
}
