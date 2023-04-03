using System;
using MozartUI.Gantt;

namespace MozartUI.Services.Template.Model
{
    public class ProductionGanttRow : GanttRow
    {
        public string? SiteId { get; set; }
        public string? BufferId { get; set; }
        public string? ItemId { get; set; }
    }
}
