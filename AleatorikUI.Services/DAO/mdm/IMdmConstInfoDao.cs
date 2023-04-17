using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmConstInfoDao
    {
        public IEnumerable<MdmConstInfo> GetAll();
        public void Insert(MdmConstInfo mdmConstInfo);
        public int Update(MdmConstInfo mdmConstInfo);
        public int Delete(MdmConstInfo mdmConstInfo);
    }
}