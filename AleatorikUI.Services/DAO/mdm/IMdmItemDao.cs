using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmItemDao
    {
        public IEnumerable<MdmItem> GetAll();
        public void Insert(MdmItem mdmItem);
        public int Update(MdmItem mdmItem);
        public int Delete(MdmItem mdmItem);
    }
}