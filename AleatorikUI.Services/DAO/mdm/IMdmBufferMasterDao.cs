using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmBufferMasterDao
    {
        public IEnumerable<MdmBufferMaster> GetAll(MdmBufferMaster mdmBufferMaster);
        public void Insert(MdmBufferMaster mdmBufferMaster);
        public int Update(MdmBufferMaster mdmBufferMaster);
        public int Delete(MdmBufferMaster mdmBufferMaster);

        public IEnumerable<MdmBufferProp> GetAllProp(MdmBufferProp mdmBufferProp);
        public void InsertProp(MdmBufferProp mdmBufferProp);
        public int UpdateProp(MdmBufferProp mdmBufferProp);
        public int DeleteProp(MdmBufferProp mdmBufferProp);
    }
}