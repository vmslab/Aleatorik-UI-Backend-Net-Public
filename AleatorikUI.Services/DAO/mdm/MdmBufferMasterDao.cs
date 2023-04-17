using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmBufferMasterDao : IMdmBufferMasterDao
{
    public MdmBufferMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmBufferMaster> GetAll()
    {
        return Mapper.QueryForList<MdmBufferMaster>("MdmBufferMaster.Select", null);
    }

    public void Insert(MdmBufferMaster mdmBufferMaster)
    {
        Mapper.Insert("MdmBufferMaster.Insert", mdmBufferMaster);
    }

    public int Update(MdmBufferMaster mdmBufferMaster)
    {
        return Mapper.Update("MdmBufferMaster.Update", mdmBufferMaster);
    }

    public int Delete(MdmBufferMaster mdmBufferMaster)
    {
        return Mapper.Delete("MdmBufferMaster.Delete", mdmBufferMaster);
    }
}