using AleatorikUI.Services.DTO.plm;

namespace AleatorikUI.Services.DAO.plm;

public interface IPlmPlanExecuteDao
{
    public IEnumerable<PlmPlanExecuteInfo> GetPlan(PlmPlanExecuteInfo param);
    public bool AddPlan(PlmPlanExecuteInfo param);
    public bool UpdatePlan(PlmPlanExecuteInfo param);
    public object InboundPlan(PlmPlanExecuteInfo param);
    public object RemovePlan(PlmPlanExecuteInfo param);
}
