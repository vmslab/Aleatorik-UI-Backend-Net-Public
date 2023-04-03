using MozartUI.Services.Template.DTO;

namespace MozartUI.Services.Template.DAO
{
    public interface IMenuMapDao
    {
        public IEnumerable<MenuMapInfo> GetAll(MenuMapInfo menuMapInfo);
        public MenuMapInfo GetById(string menuMapId);
        public int Save(List<MenuMapInfo> menuMapInfos);
    }
}
