using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmResMasterDao : IMdmResMasterDao
{
    public MdmResMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmResMaster> GetAll()
    {
        return Mapper.QueryForList<MdmResMaster>("MdmResMaster.Select", null);
    }

    public void Insert(MdmResMaster mdmResMaster)
    {
        Mapper.Insert("MdmResMaster.Insert", mdmResMaster);
    }

    public int Update(MdmResMaster mdmResMaster)
    {
        return Mapper.Update("MdmResMaster.Update", mdmResMaster);
    }

    public int Delete(MdmResMaster mdmResMaster)
    {
        return Mapper.Delete("MdmResMaster.Delete", mdmResMaster);
    }
}