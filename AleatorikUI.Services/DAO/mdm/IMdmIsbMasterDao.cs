using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmIsbMasterDao
    {
        public IEnumerable<MdmIsbMaster> GetAll();
        public void Insert(MdmIsbMaster mdmIsbMaster);
        public int Update(MdmIsbMaster mdmIsbMaster);
        public int Delete(MdmIsbMaster mdmIsbMaster);
    }
}