using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmStageMasterDao
    {
        public IEnumerable<MdmStageMaster> GetAll();
        public void Insert(MdmStageMaster mdmStageMaster);
        public int Update(MdmStageMaster mdmStageMaster);
        public int Delete(MdmStageMaster mdmStageMaster);
    }

}