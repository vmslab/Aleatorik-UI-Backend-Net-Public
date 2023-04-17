using AleatorikUI.Services.DTO.iod;
using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmDemandDao : IMdmDemandDao
{
    public MdmDemandDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmDemand> GetAll()
    {
        return Mapper.QueryForList<MdmDemand>("MdmDemand.Select", null);
    }

    public void Insert(MdmDemand mdmDemand)
    {
        Mapper.Insert("MdmDemand.Insert", mdmDemand);
    }

    public int Update(MdmDemand mdmDemand)
    {
        return Mapper.Update("MdmDemand.Update", mdmDemand);
    }

    public int Delete(MdmDemand mdmDemand)
    {
        return Mapper.Delete("MdmDemand.Delete", mdmDemand);
    }
}