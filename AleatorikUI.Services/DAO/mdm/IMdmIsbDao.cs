using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmIsbDao
    {
        public IEnumerable<MdmIsb> GetAll();
        public void Insert(MdmIsb mdmIsb);
        public int Update(MdmIsb mdmIsb);
        public int Delete(MdmIsb mdmIsb);
    }
}