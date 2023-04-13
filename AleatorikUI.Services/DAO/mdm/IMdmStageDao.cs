using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmStageDao
    {
        public IEnumerable<MdmStage> GetAll();
        public MdmStage GetById(string mdmStage);
        public void Insert(MdmStage mdmStage);
        public int Update(MdmStage mdmStage);
        public int Delete(MdmStage mdmStage);
    }

}