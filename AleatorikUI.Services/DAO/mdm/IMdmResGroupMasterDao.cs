using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmResGroupMasterDao
    {
        public IEnumerable<MdmResGroupMaster> GetAll();
        public void Insert(MdmResGroupMaster mdmResGroupMaster);
        public int Update(MdmResGroupMaster mdmResGroupMaster);
        public int Delete(MdmResGroupMaster mdmResGroupMaster);
    }
}