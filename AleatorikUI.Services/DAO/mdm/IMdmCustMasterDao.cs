using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmCustMasterDao
    {
        public IEnumerable<MdmCustMaster> GetAll();
        public void Insert(MdmCustMaster mdmCustMaster);
        public int Update(MdmCustMaster mdmCustMaster);
        public int Delete(MdmCustMaster mdmCustMaster);

        public IEnumerable<MdmCustProp> GetAllProp(String custID);
        public void InsertProp(MdmCustProp mdmCustProp);
        public int UpdateProp(MdmCustProp mdmCustProp);
        public int DeleteProp(MdmCustProp mdmCustProp);
    }
}