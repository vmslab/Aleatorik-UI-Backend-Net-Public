using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmFactoryMasterDao : IMdmFactoryMasterDao
{
    public MdmFactoryMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmFactoryMaster> GetAll()
    {
        return Mapper.QueryForList<MdmFactoryMaster>("MdmFactoryMaster.Select", null);
    }

    public void Insert(MdmFactoryMaster mdmFactoryMaster)
    {
        Mapper.Insert("MdmFactoryMaster.Insert", mdmFactoryMaster);
    }

    public int Update(MdmFactoryMaster mdmFactoryMaster)
    {
        return Mapper.Update("MdmFactoryMaster.Update", mdmFactoryMaster);
    }

    public int Delete(MdmFactoryMaster mdmFactoryMaster)
    {
        return Mapper.Delete("MdmFactoryMaster.Delete", mdmFactoryMaster);
    }
}