using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmPropMasterDao : IMdmPropMasterDao
{
    public MdmPropMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmPropMaster> GetAll()
    {
        return Mapper.QueryForList<MdmPropMaster>("MdmPropMaster.Select", null);
    }

    public void Insert(MdmPropMaster mdmPropMaster)
    {
        Mapper.Insert("MdmPropMaster.Insert", mdmPropMaster);
    }

    public int Update(MdmPropMaster mdmPropMaster)
    {
        return Mapper.Update("MdmPropMaster.Update", mdmPropMaster);
    }

    public int Delete(MdmPropMaster mdmPropMaster)
    {
        return Mapper.Delete("MdmPropMaster.Delete", mdmPropMaster);
    }
}