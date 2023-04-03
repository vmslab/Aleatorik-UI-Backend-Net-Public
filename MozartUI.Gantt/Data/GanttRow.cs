using System.Collections.Generic;

namespace MozartUI.Gantt
{
    public class GanttRow
    {
        public int MaxLevel { get; set; } = 1;
        public List<GanttTask> Tasks = new List<GanttTask>();
        public List<GanttMilestone> Milestones = new List<GanttMilestone>();
        public List<GanttLink> Links = new List<GanttLink>();
    }
}
