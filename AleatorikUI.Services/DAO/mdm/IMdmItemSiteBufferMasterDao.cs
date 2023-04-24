using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmItemSiteBufferMasterDao
    {
        public IEnumerable<MdmItemSiteBufferMaster> GetAll(MdmItemSiteBufferMaster mbmItemSiteBufferMaster);
        public void Insert(MdmItemSiteBufferMaster mbmItemSiteBufferMaster);
        public int Update(MdmItemSiteBufferMaster mbmItemSiteBufferMaster);
        public int Delete(MdmItemSiteBufferMaster mbmItemSiteBufferMaster);

        public IEnumerable<MdmItemSiteBufferProp> GetAllProp(MdmItemSiteBufferProp mdmItemSiteBufferProp);
        public void InsertProp(MdmItemSiteBufferProp mdmItemSiteBufferProp);
        public int UpdateProp(MdmItemSiteBufferProp mdmItemSiteBufferProp);
        public int DeleteProp(MdmItemSiteBufferProp mdmItemSiteBufferProp);
    }
}