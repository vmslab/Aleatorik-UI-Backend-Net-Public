using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmAllocGroupDao : IMdmAllocGroupDao
{
    public MdmAllocGroupDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmAllocGroup> GetAll()
    {
        return Mapper.QueryForList<MdmAllocGroup>("MdmAllocGroup.Select", null);
    }

    public void Insert(MdmAllocGroup mdmAllocGroup)
    {
        Mapper.Insert("MdmAllocGroup.Insert", mdmAllocGroup);
    }

    public int Update(MdmAllocGroup mdmAllocGroup)
    {
        return Mapper.Update("MdmAllocGroup.Update", mdmAllocGroup);
    }

    public int Delete(MdmAllocGroup mdmAllocGroup)
    {
        return Mapper.Delete("MdmAllocGroup.Delete", mdmAllocGroup);
    }
}