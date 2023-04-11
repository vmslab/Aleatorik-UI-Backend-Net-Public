using MozartUI.Services.DTO;

namespace MozartUI.Services.DAO;

public interface ICfgSiteMasterDao
{
    public IEnumerable<CfgSiteMaster> GetAll();
    public CfgSiteMaster GetById(String todoInfo);
    public void Insert(CfgSiteMaster todoInfo);
    public int Update(CfgSiteMaster todoInfo);
    public int Delete(CfgSiteMaster todoInfo);
}
