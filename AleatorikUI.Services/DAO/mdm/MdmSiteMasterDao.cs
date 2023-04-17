using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmSiteMasterDao : IMdmSiteMasterDao
{
    public MdmSiteMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmSiteMaster> GetAll()
    {
        return Mapper.QueryForList<MdmSiteMaster>("MdmSiteMaster.Select", null);
    }

    public void Insert(MdmSiteMaster mdmSiteMaster)
    {
        Mapper.Insert("MdmSiteMaster.Insert", mdmSiteMaster);
    }

    public int Update(MdmSiteMaster mdmSiteMaster)
    {
        return Mapper.Update("MdmSiteMaster.Update", mdmSiteMaster);
    }

    public int Delete(MdmSiteMaster mdmSiteMaster)
    {
        return Mapper.Delete("MdmSiteMaster.Delete", mdmSiteMaster);
    }
}