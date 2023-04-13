using AleatorikUI.Services.DTO.sys;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.sys;

public class MenuDao : IMenuDao
{
    public MenuDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MenuInfo> GetAll(string systemId)
    {
        return Mapper.QueryForList<MenuInfo>("Menu.SelectMenus", systemId);
    }

    public IEnumerable<MenuInfo> GetAll(UserInfo userInfo)
    {
        return Mapper.QueryForList<MenuInfo>("Menu.SelectMenusForUser", userInfo);
    }

    public MenuInfo GetById(MenuInfo menuInfo)
    {
        return Mapper.QueryForObject<MenuInfo>("Menu.SelectMenu", menuInfo.MenuId);
    }

    public int Save(List<MenuInfo> menuInfos)
    {
        var transaction = Mapper.BeginTransaction();
        try
        {
            var affectedRow = 0;
            foreach (var menuInfo in menuInfos)
            {
                if (menuInfo.State == "removed")
                {
                    affectedRow += transaction.SqlMapper.Update("Menu.DeleteMenu", menuInfo);
                    affectedRow += transaction.SqlMapper.Update("Menu.DeleteMenuMap", menuInfo);
                }
                else
                {
                    affectedRow += transaction.SqlMapper.Update("Menu.MergeMenu", menuInfo);

                    if (menuInfo.State == "added")
                    {
                        var adminMapInfo = new MenuMapInfo
                        {
                            MenuMapId = Guid.NewGuid().ToString(),
                            SystemId = menuInfo.SystemId,
                            MenuId = menuInfo.MenuId,
                            GroupId = "admin",
                            IsRead = true,
                            IsWrite = true
                        };
                        affectedRow += transaction.SqlMapper.Update("Menu.InsertMenuMap", adminMapInfo);
                        var defaultMapInfo = new MenuMapInfo
                        {
                            MenuMapId = Guid.NewGuid().ToString(),
                            SystemId = menuInfo.SystemId,
                            MenuId = menuInfo.MenuId,
                            GroupId = "default",
                            IsRead = true,
                            IsWrite = false
                        };
                        affectedRow += transaction.SqlMapper.Update("Menu.InsertMenuMap", defaultMapInfo);
                    }
                    else
                    {
                        affectedRow += transaction.SqlMapper.Update("Menu.UpdateMenuMap", menuInfo);
                    }
                }
            }
            transaction.CommitTransaction();
            return affectedRow;
        }
        catch (Exception e)
        {
            transaction.RollBackTransaction();
            throw e;
        }
        return 0;
    }
}