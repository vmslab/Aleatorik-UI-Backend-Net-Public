using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmConstInfoDao : IMdmConstInfoDao
{
    public MdmConstInfoDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmConstInfo> GetAll()
    {
        return Mapper.QueryForList<MdmConstInfo>("MdmConstInfo.Select", null);
    }

    public void Insert(MdmConstInfo mdmConstInfo)
    {
        Mapper.Insert("MdmConstInfo.Insert", mdmConstInfo);
    }

    public int Update(MdmConstInfo mdmConstInfo)
    {
        return Mapper.Update("MdmConstInfo.Update", mdmConstInfo);
    }

    public int Delete(MdmConstInfo mdmConstInfo)
    {
        return Mapper.Delete("MdmConstInfo.Delete", mdmConstInfo);
    }
}