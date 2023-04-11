using MozartUI.Services.DTO;

namespace MozartUI.Services.DAO;

public interface IGanttDao
{
    public GetResourceGanttInfo GetResourceGanttInfo();
    public IEnumerable<GetResourceGanttData> GetResourceGanttData();
    public GetProductionGanttInfo GetProductionGanttInfo();
}