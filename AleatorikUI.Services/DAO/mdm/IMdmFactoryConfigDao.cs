using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmFactoryConfigDao
    {
        public IEnumerable<MdmFactoryConfig> GetAll();
        public void Insert(MdmFactoryConfig mdmFactoryConfig);
        public int Update(MdmFactoryConfig mdmFactoryConfig);
        public int Delete(MdmFactoryConfig mdmFactoryConfig);
    }
}
