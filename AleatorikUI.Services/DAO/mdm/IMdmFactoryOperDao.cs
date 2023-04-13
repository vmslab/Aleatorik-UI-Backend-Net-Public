using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmFactoryOperDao
    {
        public IEnumerable<MdmFactoryOper> GetAll();
        public void Insert(MdmFactoryOper mdmFactoryOper);
        public int Update(MdmFactoryOper mdmFactoryOper);
        public int Delete(MdmFactoryOper mdmFactoryOper);
    }
}
