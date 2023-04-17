using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmPmPlanDao : IMdmPmPlanDao
{
    public MdmPmPlanDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmPmPlan> GetAll()
    {
        return Mapper.QueryForList<MdmPmPlan>("MdmPmPlan.Select", null);
    }

    public void Insert(MdmPmPlan mdmPmPlan)
    {
        Mapper.Insert("MdmPmPlan.Insert", mdmPmPlan);
    }

    public int Update(MdmPmPlan mdmPmPlan)
    {
        return Mapper.Update("MdmPmPlan.Update", mdmPmPlan);
    }

    public int Delete(MdmPmPlan mdmPmPlan)
    {
        return Mapper.Delete("MdmPmPlan.Delete", mdmPmPlan);
    }
}