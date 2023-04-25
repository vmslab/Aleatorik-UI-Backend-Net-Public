using AleatorikUI.Services.DTO.exp;

namespace AleatorikUI.Services.DAO.exp;

public interface ITrEmployeeDao
{
    public IEnumerable<TrEmployee> GetAll(TrEmployee trEmployee);
    public void Insert(TrEmployee trEmployee);
    public int Update(TrEmployee trEmployee);
    public int Delete(TrEmployee trEmployee);
}
