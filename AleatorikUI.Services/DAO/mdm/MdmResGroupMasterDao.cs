using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmResGroupMasterDao : IMdmResGroupMasterDao
{
    public MdmResGroupMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmResGroupMaster> GetAll()
    {
        return Mapper.QueryForList<MdmResGroupMaster>("MdmResGroupMaster.Select", null);
    }

    public void Insert(MdmResGroupMaster mdmResGroupMaster)
    {
        Mapper.Insert("MdmResGroupMaster.Insert", mdmResGroupMaster);
    }

    public int Update(MdmResGroupMaster mdmResGroupMaster)
    {
        return Mapper.Update("MdmResGroupMaster.Update", mdmResGroupMaster);
    }

    public int Delete(MdmResGroupMaster mdmResGroupMaster)
    {
        return Mapper.Delete("MdmResGroupMaster.Delete", mdmResGroupMaster);
    }
}