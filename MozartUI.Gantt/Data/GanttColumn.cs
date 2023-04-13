using System;

namespace AleatorikUI.Gantt.Data
{
    public class GanttColumn
    {
        public string? Key { get; set; }
        public string? EndKey { get; set; }
        public double Width { get; set; }
        public string? Text { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int ColNo { get; set; }
    }
}
