using MozartUI.Services.DTO.sys;

namespace MozartUI.Services.DAO.mdm;

public interface IMdmBomRoutingSub1Dao
{
    public IEnumerable<MenuInfo> GetAll(string systemId);
    public IEnumerable<MenuInfo> GetAll(UserInfo userInfo);
    public MenuInfo GetById(MenuInfo menuInfo);
    public int Save(List<MenuInfo> menuInfos);
}
