using AleatorikUI.Services.DTO.exp;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.exp;

public class GanttDao : IGanttDao
{
    public GanttDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public GetResourceGanttInfo GetResourceGanttInfo()
    {
        return Mapper.QueryForObject<GetResourceGanttInfo>("Gantt.GetResourceGanttInfo", null);
    }

    public IEnumerable<GetResourceGanttData> GetResourceGanttData()
    {
        return Mapper.QueryForList<GetResourceGanttData>("Gantt.GetResourceGanttData", null);
    }

    public GetProductionGanttInfo GetProductionGanttInfo()
    {
        return Mapper.QueryForObject<GetProductionGanttInfo>("Gantt.GetProductionGanttInfo", null);
    }

}
