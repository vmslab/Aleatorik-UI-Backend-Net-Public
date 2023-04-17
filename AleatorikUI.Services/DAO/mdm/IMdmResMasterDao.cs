using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmResMasterDao
    {
        public IEnumerable<MdmResMaster> GetAll();
        public void Insert(MdmResMaster mdmResMaster);
        public int Update(MdmResMaster mdmResMaster);
        public int Delete(MdmResMaster mdmResMaster);
    }
}