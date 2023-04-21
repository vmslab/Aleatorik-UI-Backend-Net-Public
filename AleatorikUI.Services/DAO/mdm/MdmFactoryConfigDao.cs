using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmFactoryConfigDao : IMdmFactoryConfigDao
{
    public MdmFactoryConfigDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmFactoryConfig> GetAll()
    {
        return Mapper.QueryForList<MdmFactoryConfig>("MdmFactoryConfig.Select", null);
    }

    public void Insert(MdmFactoryConfig mdmFactoryConfig)
    {
        Mapper.Insert("MdmFactoryConfig.Insert", mdmFactoryConfig);
    }

    public int Update(MdmFactoryConfig mdmFactoryConfig)
    {
        return Mapper.Update("MdmFactoryConfig.Update", mdmFactoryConfig);
    }

    public int Delete(MdmFactoryConfig mdmFactoryConfig)
    {
        return Mapper.Delete("MdmFactoryConfig.Delete", mdmFactoryConfig);
    }
}