using AleatorikUI.Services.DTO.mdm;
namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmCodeGroupMasterDao
    {
        public IEnumerable<MdmCodeGroupMaster> GetAll();
        public void Insert(MdmCodeGroupMaster mdmCodeGroupMaster);
        public int Update(MdmCodeGroupMaster mdmCodeGroupMaster);
        public int Delete(MdmCodeGroupMaster mdmCodeGroupMaster);

        public  IEnumerable<MdmCodeGroupSub1> GetAllSub1(String categoryID);
        public void InsertSub1(MdmCodeGroupSub1 mdmCodeGroupSub1);
        public int UpdateSub1(MdmCodeGroupSub1 mdmCodeGroupSub1);
        public int DeleteSub1(MdmCodeGroupSub1 mdmCodeGroupSub1);
    }
}