using MozartUI.Services.DTO.mdm;
namespace MozartUI.Services.DAO.mdm
{
    public interface IMdmSiteDao
    {
        public IEnumerable<MdmSite> GetAll();
        public MdmSite GetById(string mdmSite);
        public void Insert(MdmSite mdmSite);
        public int Update(MdmSite mdmSite);
        public int Delete(MdmSite mdmSite);
    }
}