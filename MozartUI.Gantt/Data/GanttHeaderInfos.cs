using System.Collections.Generic;

namespace MozartUI.Gantt.Data
{
    public class GanttHeaderInfos
    {
        public string? KeyFormat { get; set; }
        public Dictionary<string, GanttColumn>? Headers { get; set; }
        public Dictionary<string, GanttColumn>? EndHeaders { get; set; }
    }
}
