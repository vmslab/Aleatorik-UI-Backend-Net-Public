using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmBufferMasterDao
    {
        public IEnumerable<MdmBufferMaster> GetAll();
        public void Insert(MdmBufferMaster mdmBufferMaster);
        public int Update(MdmBufferMaster mdmBufferMaster);
        public int Delete(MdmBufferMaster mdmBufferMaster);
    }
}