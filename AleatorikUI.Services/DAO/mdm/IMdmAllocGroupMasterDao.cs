using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmAllocGroupMasterDao
    {
        public IEnumerable<MdmAllocGroupMaster> GetAll(String projectID);
        public void Insert(MdmAllocGroupMaster mdmAllocGroupMaster);
        public int Update(MdmAllocGroupMaster mdmAllocGroupMaster);
        public int Delete(MdmAllocGroupMaster mdmAllocGroupMaster);
    }
}