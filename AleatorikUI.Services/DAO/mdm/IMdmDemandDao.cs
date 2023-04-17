using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmDemandDao
    {
        public IEnumerable<MdmDemand> GetAll();
        public void Insert(MdmDemand mdmDemand);
        public int Update(MdmDemand mdmDemand);
        public int Delete(MdmDemand mdmDemand);
    }
}