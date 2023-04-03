using System;

namespace MozartUI.Gantt
{
    public class GanttTask
    {
        public GanttTask()
        {
            Id = Guid.NewGuid().ToString().ToUpper();
        }

        public string? Id { get; set; }
        public string? Key { get; set; }
        public string? Text { get; set; }
        public string? Tooltip { get; set; }
        public object? Item { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Level { get; set; } = 1;
        public string? BackgroundColor { get; set; }
        public string? BorderColor { get; set; }
        public string? TextColor { get; set; }
    }
}
