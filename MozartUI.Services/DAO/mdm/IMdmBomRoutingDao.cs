using MozartUI.Services.DTO.sys;

namespace MozartUI.Services.DAO.mdm;

public interface IMdmBomRoutingDao
{
    public IEnumerable<MenuInfo> GetAll(string systemId);
    public IEnumerable<MenuInfo> GetAll(UserInfo userInfo);
    public MenuInfo GetById(MenuInfo menuInfo);
    public int Save(List<MenuInfo> menuInfos);
}
