using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmAllocGroupDao
    {
        public IEnumerable<MdmAllocGroup> GetAll();
        public void Insert(MdmAllocGroup mdmAllocGroup);
        public int Update(MdmAllocGroup mdmAllocGroup);
        public int Delete(MdmAllocGroup mdmAllocGroup);
    }
}