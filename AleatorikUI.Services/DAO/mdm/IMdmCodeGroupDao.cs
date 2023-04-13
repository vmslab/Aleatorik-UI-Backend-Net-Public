using AleatorikUI.Services.DTO.mdm;
namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmCodeGroupDao
    {
        public IEnumerable<MdmCodeGroup> GetAll();
        public void Insert(MdmCodeGroup mdmCodeGroup);
        public int Update(MdmCodeGroup mdmCodeGroup);
        public int Delete(MdmCodeGroup mdmCodeGroup);

        public  IEnumerable<MdmCodeGroupSub1> GetAllDetail(String categoryID);
        public void InsertDetail(MdmCodeGroupSub1 mdmCodeGroupSub1);
        public int UpdateDetail(MdmCodeGroupSub1 mdmCodeGroupSub1);
        public int DeleteDetail(MdmCodeGroupSub1 mdmCodeGroupSub1);
    }
}