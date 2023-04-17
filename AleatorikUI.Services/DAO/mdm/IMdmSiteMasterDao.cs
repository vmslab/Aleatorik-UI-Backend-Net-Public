using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmSiteMasterDao
    {
        public IEnumerable<MdmSiteMaster> GetAll();
        public void Insert(MdmSiteMaster mdmSiteMaster);
        public int Update(MdmSiteMaster mdmSiteMaster);
        public int Delete(MdmSiteMaster mdmSiteMaster);
    }
}