using MozartUI.Services.Template.DTO;

namespace MozartUI.Services.Template.DAO
{
    public interface IGanttDao
    {
        public GetResourceGanttInfo GetResourceGanttInfo();
        public IEnumerable<GetResourceGanttData> GetResourceGanttData();
        public GetProductionGanttInfo GetProductionGanttInfo();
    }
}
