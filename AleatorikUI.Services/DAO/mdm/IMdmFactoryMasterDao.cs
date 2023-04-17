using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmFactoryMasterDao
    {
        public IEnumerable<MdmFactoryMaster> GetAll();
        public void Insert(MdmFactoryMaster mdmFactoryMaster);
        public int Update(MdmFactoryMaster mdmFactoryMaster);
        public int Delete(MdmFactoryMaster mdmFactoryMaster);
    }
}
