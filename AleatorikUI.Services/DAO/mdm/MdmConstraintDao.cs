using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmConstraintDao : IMdmConstraintDao
{
    public MdmConstraintDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmConstraint> GetAll(MdmConstraint mdmConstraint)
    {
        return Mapper.QueryForList<MdmConstraint>("MdmConstraint.Select", mdmConstraint);
    }

    public void Insert(MdmConstraint mdmConstraint)
    {
        Mapper.Insert("MdmConstraint.Insert", mdmConstraint);
    }

    public int Update(MdmConstraint mdmConstraint)
    {
        return Mapper.Update("MdmConstraint.Update", mdmConstraint);
    }

    public int Delete(MdmConstraint mdmConstraint)
    {
        return Mapper.Delete("MdmConstraint.Delete", mdmConstraint);
    }
}