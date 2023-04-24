using AleatorikUI.Services.DTO.exp;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.exp;

public class TrEmployeeDao : ITrEmployeeDao
{
    public TrEmployeeDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<TrEmployee> GetAll(TrEmployee mdmSiteMaster)
    {
        return Mapper.QueryForList<TrEmployee>("TrEmployee.Select", mdmSiteMaster);
    }

    public void Insert(TrEmployee mdmSiteMaster)
    {
        Mapper.Insert("TrEmployee.Insert", mdmSiteMaster);
    }

    public int Update(TrEmployee mdmSiteMaster)
    {
        return Mapper.Update("TrEmployee.Update", mdmSiteMaster);
    }

    public int Delete(TrEmployee mdmSiteMaster)
    {
        return Mapper.Delete("TrEmployee.Delete", mdmSiteMaster);
    }
}