using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmPropMasterDao
    {
        public IEnumerable<MdmPropMaster> GetAll();
        public void Insert(MdmPropMaster mdmPropMaster);
        public int Update(MdmPropMaster mdmPropMaster);
        public int Delete(MdmPropMaster mdmPropMaster);
    }
}