using AleatorikUI.Services.DTO.mdm;
namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmCodeCategoryMasterDao
    {
        public IEnumerable<MdmCodeCategoryMaster> GetAll(MdmCodeCategoryMaster mdmCodeCategoryMaster);
        public void Insert(MdmCodeCategoryMaster mdmCodeCategoryMaster);
        public int Update(MdmCodeCategoryMaster mdmCodeCategoryMaster);
        public int Delete(MdmCodeCategoryMaster mdmCodeCategoryMaster);

        public  IEnumerable<MdmCodeMaster> GetAllMaster(MdmCodeMaster mdmCodeMaster);
        public void InsertMaster(MdmCodeMaster mdmCodeMaster);
        public int UpdateMaster(MdmCodeMaster mdmCodeMaster);
        public int DeleteMaster(MdmCodeMaster mdmCodeMaster);
    }
}