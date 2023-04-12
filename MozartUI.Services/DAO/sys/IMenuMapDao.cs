using MozartUI.Services.DTO.sys;

namespace MozartUI.Services.DAO.sys;

public interface IMenuMapDao
{
    public IEnumerable<MenuMapInfo> GetAll(MenuMapInfo menuMapInfo);
    public MenuMapInfo GetById(string menuMapId);
    public int Save(List<MenuMapInfo> menuMapInfos);
}
