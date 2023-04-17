using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmSetupInfoDao
    {
        public IEnumerable<MdmSetupInfo> GetAll();
        public void Insert(MdmSetupInfo mdmSetupInfo);
        public int Update(MdmSetupInfo mdmSetupInfo);
        public int Delete(MdmSetupInfo mdmSetupInfo);
    }
}