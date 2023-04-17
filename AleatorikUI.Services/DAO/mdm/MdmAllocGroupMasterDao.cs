using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmAllocGroupMasterDao : IMdmAllocGroupMasterDao
{
    public MdmAllocGroupMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmAllocGroupMaster> GetAll()
    {
        return Mapper.QueryForList<MdmAllocGroupMaster>("MdmAllocGroupMaster.Select", null);
    }

    public void Insert(MdmAllocGroupMaster mdmAllocGroupMaster)
    {
        Mapper.Insert("MdmAllocGroupMaster.Insert", mdmAllocGroupMaster);
    }

    public int Update(MdmAllocGroupMaster mdmAllocGroupMaster)
    {
        return Mapper.Update("MdmAllocGroupMaster.Update", mdmAllocGroupMaster);
    }

    public int Delete(MdmAllocGroupMaster mdmAllocGroupMaster)
    {
        return Mapper.Delete("MdmAllocGroupMaster.Delete", mdmAllocGroupMaster);
    }
}