using MozartUI.Services.DTO;

namespace MozartUI.Services.DAO;

public interface IMenuMapDao
{
    public IEnumerable<MenuMapInfo> GetAll(MenuMapInfo menuMapInfo);
    public MenuMapInfo GetById(string menuMapId);
    public int Save(List<MenuMapInfo> menuMapInfos);
}
