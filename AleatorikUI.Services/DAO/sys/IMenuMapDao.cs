using AleatorikUI.Services.DTO.sys;

namespace AleatorikUI.Services.DAO.sys;

public interface IMenuMapDao
{
    public IEnumerable<MenuMapInfo> GetAll(MenuMapInfo menuMapInfo);
    public MenuMapInfo GetById(string menuMapId);
    public int Save(List<MenuMapInfo> menuMapInfos);
}
