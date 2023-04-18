using AleatorikUI.Services.DTO.sam;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.sam;

public class SamMenuMapDao : ISamMenuMapDao
{
    public SamMenuMapDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<SamMenuMapInfo> GetAll(SamMenuMapInfo samMenuMapInfo)
    {
        return Mapper.QueryForList<SamMenuMapInfo>("MenuMap.SelectMenuMaps", samMenuMapInfo);
    }

    public SamMenuMapInfo GetById(string menuMapId)
    {
        return Mapper.QueryForObject<SamMenuMapInfo>("MenuMap.SelectMenuMap", menuMapId);
    }

    public int Save(List<SamMenuMapInfo> samMenuMapInfos)
    {
        var transaction = Mapper.BeginTransaction();
        try
        {
            var affectedRow = 0;
            foreach (var samMenuMapInfo in samMenuMapInfos)
            {
                affectedRow += transaction.SqlMapper.Update("MenuMap.MergeMenuMap", samMenuMapInfo);
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