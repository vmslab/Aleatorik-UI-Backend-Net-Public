using MozartUI.Services.DTO.exp;

namespace MozartUI.Services.DAO.exp;

public interface IGanttDao
{
    public GetResourceGanttInfo GetResourceGanttInfo();
    public IEnumerable<GetResourceGanttData> GetResourceGanttData();
    public GetProductionGanttInfo GetProductionGanttInfo();
}