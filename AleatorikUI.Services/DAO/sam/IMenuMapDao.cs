using AleatorikUI.Services.DTO.sam;

namespace AleatorikUI.Services.DAO.sam;

public interface IMenuMapDao
{
    public IEnumerable<MenuMapInfo> GetAll(MenuMapInfo menuMapInfo);
    public MenuMapInfo GetById(string menuMapId);
    public int Save(List<MenuMapInfo> menuMapInfos);
}
