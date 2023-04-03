using System;
using MozartUI.Gantt;

namespace MozartUI.Services.Template.Model
{
    public class ResourceGanttRow : GanttRow
    {
        public string? StageId { get; set; }
        public string? ResourceId { get; set; }
        public string? ResourceGroup { get; set; }
    }
}
