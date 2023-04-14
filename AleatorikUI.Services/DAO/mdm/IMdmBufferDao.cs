using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmBufferDao
    {
        public IEnumerable<MdmBuffer> GetAll();
        public void Insert(MdmBuffer mdmBuffer);
        public int Update(MdmBuffer mdmBuffer);
        public int Delete(MdmBuffer mdmBuffer);
    }
}