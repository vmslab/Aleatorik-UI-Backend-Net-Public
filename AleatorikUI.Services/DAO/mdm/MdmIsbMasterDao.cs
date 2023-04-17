using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmIsbMasterDao : IMdmIsbMasterDao
{
    public MdmIsbMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmIsbMaster> GetAll()
    {
        return Mapper.QueryForList<MdmIsbMaster>("MdmIsbMaster.Select", null);
    }

    public void Insert(MdmIsbMaster mdmIsbMaster)
    {
        Mapper.Insert("MdmIsbMaster.Insert", mdmIsbMaster);
    }

    public int Update(MdmIsbMaster mdmIsbMaster)
    {
        return Mapper.Update("MdmIsbMaster.Update", mdmIsbMaster);
    }

    public int Delete(MdmIsbMaster mdmIsbMaster)
    {
        return Mapper.Delete("MdmIsbMaster.Delete", mdmIsbMaster);
    }
}