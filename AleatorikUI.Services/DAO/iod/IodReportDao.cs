using AleatorikUI.Services.DTO.iod;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.iod;

public class RarBomMapViewDao : IRarBomMapViewDao
{
    public RarBomMapViewDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<RarBomMapView> GetAll()
    {
        return Mapper.QueryForList<RarBomMapView>("IodReport.Select", null);
    }

    public void Insert(RarBomMapView mdmIodReport)
    {
        Mapper.Insert("IodReport.Insert", mdmIodReport);
    }

    public int Update(RarBomMapView mdmIodReport)
    {
        return Mapper.Update("IodReport.Update", mdmIodReport);
    }

    public int Delete(RarBomMapView mdmIodReport)
    {
        return Mapper.Delete("IodReport.Delete", mdmIodReport);
    }
}