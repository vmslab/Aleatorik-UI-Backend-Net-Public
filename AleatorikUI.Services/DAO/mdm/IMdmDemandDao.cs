using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmDemandDao
    {
        public IEnumerable<MdmDemand> GetAll(MdmDemand mdmDemand);
        public void Insert(MdmDemand mdmDemand);
        public int Update(MdmDemand mdmDemand);
        public int Delete(MdmDemand mdmDemand);

        public IEnumerable<MdmDemandProp> GetAllProp(MdmDemandProp mdmDemandProp);
        public void InsertProp(MdmDemandProp mdmDemandProp);
        public int UpdateProp(MdmDemandProp mdmDemandProp);
        public int DeleteProp(MdmDemandProp mdmDemandProp);
    }
}