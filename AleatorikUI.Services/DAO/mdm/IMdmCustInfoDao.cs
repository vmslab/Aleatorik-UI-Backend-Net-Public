using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmCustInfoDao
    {
        public IEnumerable<MdmCustInfo> GetAll();
        public void Insert(MdmCustInfo mdmCustInfo);
        public int Update(MdmCustInfo mdmCustInfo);
        public int Delete(MdmCustInfo mdmCustInfo);
    }
}