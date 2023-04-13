using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmSiteDao : IMdmSiteDao
{
    public MdmSiteDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmSite> GetAll()
    {
        return Mapper.QueryForList<MdmSite>("MdmSite.Select", null);
    }

    public void Insert(MdmSite mdmSite)
    {
        Mapper.Insert("MdmSite.Insert", mdmSite);
    }

    public int Update(MdmSite mdmSite)
    {
        return Mapper.Update("MdmSite.Update", mdmSite);
    }

    public int Delete(MdmSite mdmSite)
    {
        return Mapper.Delete("MdmSite.Delete", mdmSite.siteID);
    }
}