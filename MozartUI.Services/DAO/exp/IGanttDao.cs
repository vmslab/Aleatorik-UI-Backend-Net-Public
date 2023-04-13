using AleatorikUI.Services.DTO.exp;

namespace AleatorikUI.Services.DAO.exp;

public interface IGanttDao
{
    public GetResourceGanttInfo GetResourceGanttInfo();
    public IEnumerable<GetResourceGanttData> GetResourceGanttData();
    public GetProductionGanttInfo GetProductionGanttInfo();
}