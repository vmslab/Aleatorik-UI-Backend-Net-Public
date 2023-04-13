using AleatorikUI.Services.DTO.mdm;
namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmCodeGroupDao
    {
        public IEnumerable<MdmCodeGroup> GetAll();
        public void Insert(MdmCodeGroup mdmCodeGroup);
        public int Update(MdmCodeGroup mdmCodeGroup);
        public int Delete(MdmCodeGroup mdmCodeGroup);
    }
}