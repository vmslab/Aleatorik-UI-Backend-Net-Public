using AleatorikUI.Services.DTO.mdm;

namespace AleatorikUI.Services.DAO.mdm
{
    public interface IMdmConstraintDao
    {
        public IEnumerable<MdmConstraint> GetAll(MdmConstraint mdmConstInfo);
        public void Insert(MdmConstraint mdmConstInfo);
        public int Update(MdmConstraint mdmConstInfo);
        public int Delete(MdmConstraint mdmConstInfo);
    }
}