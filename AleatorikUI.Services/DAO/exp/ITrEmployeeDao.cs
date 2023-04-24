using AleatorikUI.Services.DTO.exp;

namespace AleatorikUI.Services.DAO.exp
{
    public interface ITrEmployeeDao
    {
        public IEnumerable<TrEmployee> GetAll(TrEmployee mdmSiteMaster);
        public void Insert(TrEmployee mdmSiteMaster);
        public int Update(TrEmployee mdmSiteMaster);
        public int Delete(TrEmployee mdmSiteMaster);
    }
}