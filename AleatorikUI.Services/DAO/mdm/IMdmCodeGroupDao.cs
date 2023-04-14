using AleatorikUI.Services.DTO.mdm;
namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmCodeGroupDao
    {
        public IEnumerable<MdmCodeGroup> GetAll();
        public void Insert(MdmCodeGroup mdmCodeGroup);
        public int Update(MdmCodeGroup mdmCodeGroup);
        public int Delete(MdmCodeGroup mdmCodeGroup);

        public  IEnumerable<MdmCodeGroupSub1> GetAllSub1(String categoryID);
        public void InsertSub1(MdmCodeGroupSub1 mdmCodeGroupSub1);
        public int UpdateSub1(MdmCodeGroupSub1 mdmCodeGroupSub1);
        public int DeleteSub1(MdmCodeGroupSub1 mdmCodeGroupSub1);
    }
}