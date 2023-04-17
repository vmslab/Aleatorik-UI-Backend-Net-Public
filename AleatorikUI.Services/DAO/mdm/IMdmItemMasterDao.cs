using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmItemMasterDao
    {
        public IEnumerable<MdmItemMaster> GetAll();
        public void Insert(MdmItemMaster mdmItemMaster);
        public int Update(MdmItemMaster mdmItemMaster);
        public int Delete(MdmItemMaster mdmItemMaster);
    }
}