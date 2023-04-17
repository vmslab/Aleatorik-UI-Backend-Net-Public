using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmPmPlanDao
    {
        public IEnumerable<MdmPmPlan> GetAll();
        public void Insert(MdmPmPlan mdmPmPlan);
        public int Update(MdmPmPlan mdmPmPlan);
        public int Delete(MdmPmPlan mdmPmPlan);
    }
}