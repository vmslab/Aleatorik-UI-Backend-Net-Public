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

    public IEnumerable<TrEmployee> GetAll(TrEmployee trEmployee)
    {
        return Mapper.QueryForList<TrEmployee>("TrEmployee.Select", trEmployee);
    }

    public void Insert(TrEmployee trEmployee)
    {
        Mapper.Insert("TrEmployee.Insert", trEmployee);
    }

    public int Update(TrEmployee trEmployee)
    {
        return Mapper.Update("TrEmployee.Update", trEmployee);
    }

    public int Delete(TrEmployee trEmployee)
    {
        return Mapper.Delete("TrEmployee.Delete", trEmployee);
    }
}