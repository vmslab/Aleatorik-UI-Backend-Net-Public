using MozartUI.Services.DTO;
using SqlBatis.DataMapper;

namespace MozartUI.Services.DAO;

public class CfgSiteMasterDao : ICfgSiteMasterDao
{
    public CfgSiteMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<CfgSiteMaster> GetAll()
    {
        return Mapper.QueryForList<CfgSiteMaster>("CfgSiteMaster.SelectList", null);
    }

    public CfgSiteMaster GetById(String siteMaster)
    {
        return Mapper.QueryForObject<CfgSiteMaster>("CfgSiteMaster.Select", siteMaster);
    }

    public void Insert(CfgSiteMaster siteMaster)
    {
        Mapper.Insert("CfgSiteMaster.Insert", siteMaster);
    }

    public int Update(CfgSiteMaster siteMaster)
    {
        return Mapper.Update("CfgSiteMaster.Update", siteMaster);
    }

    public int Delete(CfgSiteMaster siteMaster)
    {
        return Mapper.Delete("CfgSiteMaster.Delete", siteMaster.SiteId);
    }
}