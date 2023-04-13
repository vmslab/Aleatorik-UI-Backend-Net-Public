using AleatorikUI.Services.DTO.sys;

namespace AleatorikUI.Services.DAO.mdm;

public interface IMdmRoutingOperSub1Dao
{
    public IEnumerable<MenuInfo> GetAll(string systemId);
    public IEnumerable<MenuInfo> GetAll(UserInfo userInfo);
    public MenuInfo GetById(MenuInfo menuInfo);
    public int Save(List<MenuInfo> menuInfos);
}
