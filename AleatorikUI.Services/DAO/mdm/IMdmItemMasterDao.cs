using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmItemMasterDao
    {
        public IEnumerable<MdmItemMaster> GetAll(MdmItemMaster mdmItemMaster);
        public void Insert(MdmItemMaster mdmItemMaster);
        public int Update(MdmItemMaster mdmItemMaster);
        public int Delete(MdmItemMaster mdmItemMaster);

        public IEnumerable<MdmItemProp> GetAllProp(MdmItemProp mdmItemProp);
        public void InsertProp(MdmItemProp mdmItemProp);
        public int UpdateProp(MdmItemProp mdmItemProp);
        public int DeleteProp(MdmItemProp mdmItemProp);
    }
}