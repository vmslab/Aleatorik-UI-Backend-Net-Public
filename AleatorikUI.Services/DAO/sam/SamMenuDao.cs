using AleatorikUI.Services.DTO.sam;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.sam;

public class SamMenuDao : ISamMenuDao
{
    public SamMenuDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<SamMenuInfo> GetAll(string systemId)
    {
        return Mapper.QueryForList<SamMenuInfo>("Menu.SelectMenus", systemId);
    }

    public IEnumerable<SamMenuInfo> GetAll(SamUserInfo samUserInfo)
    {
        return Mapper.QueryForList<SamMenuInfo>("Menu.SelectMenusForUser", samUserInfo);
    }

    public SamMenuInfo GetById(SamMenuInfo samMenuInfo)
    {
        return Mapper.QueryForObject<SamMenuInfo>("Menu.SelectMenu", samMenuInfo.MenuId);
    }

    public int Save(List<SamMenuInfo> samMenuInfos)
    {
        var transaction = Mapper.BeginTransaction();
        try
        {
            var affectedRow = 0;
            foreach (var samMenuInfo in samMenuInfos)
            {
                if (samMenuInfo.State == "removed")
                {
                    transaction.SqlMapper.Delete("Menu.DeleteMenu", samMenuInfo);
                    transaction.SqlMapper.Delete("Menu.DeleteMenuMap", samMenuInfo);
                    affectedRow++;
                }
                else
                {
                    affectedRow += transaction.SqlMapper.Update("Menu.MergeMenu", samMenuInfo);

                    if (samMenuInfo.State == "added")
                    {
                        var adminMapInfo = new SamMenuMapInfo
                        {
                            MenuMapId = Guid.NewGuid().ToString(),
                            SystemId = samMenuInfo.SystemId,
                            MenuId = samMenuInfo.MenuId,
                            GroupId = "admin",
                            IsRead = true,
                            IsWrite = true
                        };
                        transaction.SqlMapper.Insert("Menu.InsertMenuMap", adminMapInfo);
                        var defaultMapInfo = new SamMenuMapInfo
                        {
                            MenuMapId = Guid.NewGuid().ToString(),
                            SystemId = samMenuInfo.SystemId,
                            MenuId = samMenuInfo.MenuId,
                            GroupId = "default",
                            IsRead = true,
                            IsWrite = false
                        };
                        transaction.SqlMapper.Insert("Menu.InsertMenuMap", defaultMapInfo);
                        affectedRow++;
                    }
                    else
                    {
                        affectedRow += transaction.SqlMapper.Update("Menu.UpdateMenuMap", samMenuInfo);
                    }
                }
            }
            transaction.CommitTransaction();
            return affectedRow;
        }
        catch
        {
            transaction.RollBackTransaction();
            return 0;
        }
    }
}