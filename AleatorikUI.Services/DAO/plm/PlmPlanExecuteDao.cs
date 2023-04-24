using AleatorikUI.Services.DTO.plm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.plm;

public class PlmPlanExecuteDao : IPlmPlanExecuteDao
{
    public PlmPlanExecuteDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<PlmPlanExecuteInfo> GetPlan(PlmPlanExecuteInfo param)
    {
        return Mapper.QueryForList<PlmPlanExecuteInfo>("PlanExecute.Select", param);
    }

    public bool AddPlan(PlmPlanExecuteInfo param)
    {
        using (var transaction = Mapper.BeginTransaction())
        {
            try
            {
                transaction.SqlMapper.Insert("PlanExecute.InsertCfg", param);
                transaction.SqlMapper.Insert("PlanExecute.InsertCtrl", param);
                transaction.CommitTransaction();
                return true;
            }
            catch
            {
                transaction.RollBackTransaction();
                return false;
            }
        }
    }

    public bool UpdatePlan(PlmPlanExecuteInfo param)
    {
        return Mapper.Update("PlanExecute.Update", param) > 0;
    }

	public object InboundPlan(PlmPlanExecuteInfo param)
    {
        return Mapper.QueryForObject<Object>("PlanExecute.Inbound", param);
    }

	public object RemovePlan(PlmPlanExecuteInfo param)
    {
        return Mapper.QueryForObject<Object>("PlanExecute.Remove", param);
    }
}