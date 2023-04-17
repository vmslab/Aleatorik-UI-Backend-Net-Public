using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmWipDao
    {
        public IEnumerable<MdmWip> GetAll();
        public void Insert(MdmWip mdmWip);
        public int Update(MdmWip mdmWip);
        public int Delete(MdmWip mdmWip);
    }
}