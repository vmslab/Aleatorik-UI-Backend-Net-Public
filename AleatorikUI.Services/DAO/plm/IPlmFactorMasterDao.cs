using AleatorikUI.Services.DTO.plm;

namespace AleatorikUI.Services.DAO.plm
{
    public interface IPlmFactorMasterDao
    {
        public IEnumerable<PlmFactorMaster> GetAll(PlmFactorMaster plmFactorMaster);
        public void Insert(PlmFactorMaster plmFactorMaster);
        public int Update(PlmFactorMaster plmFactorMaster);
        public int Delete(PlmFactorMaster plmFactorMaster);
    }
}