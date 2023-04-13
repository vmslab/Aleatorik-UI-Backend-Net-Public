using AleatorikUI.Services.DTO.sys;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.sys;

public class MenuMapDao : IMenuMapDao
{
    public MenuMapDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MenuMapInfo> GetAll(MenuMapInfo menuMapInfo)
    {
        return Mapper.QueryForList<MenuMapInfo>("MenuMap.SelectMenuMaps", menuMapInfo);
    }

    public MenuMapInfo GetById(string menuMapId)
    {
        return Mapper.QueryForObject<MenuMapInfo>("MenuMap.SelectMenuMap", menuMapId);
    }

    public int Save(List<MenuMapInfo> menuMapInfos)
    {
        var transaction = Mapper.BeginTransaction();
        try
        {
            var affectedRow = 0;
            foreach (var menuMapInfo in menuMapInfos)
            {
                affectedRow += transaction.SqlMapper.Update("MenuMap.MergeMenuMap", menuMapInfo);
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