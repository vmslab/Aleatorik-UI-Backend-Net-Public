using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmPropertyDao
    {
        public IEnumerable<MdmProperty> GetAll();
        public void Insert(MdmProperty mdmProperty);
        public int Update(MdmProperty mdmProperty);
        public int Delete(MdmProperty mdmProperty);
    }
}