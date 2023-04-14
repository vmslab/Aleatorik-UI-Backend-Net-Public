using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmPropertyDao : IMdmPropertyDao
{
    public MdmPropertyDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmProperty> GetAll()
    {
        return Mapper.QueryForList<MdmProperty>("MdmProperty.Select", null);
    }

    public void Insert(MdmProperty mdmProperty)
    {
        Mapper.Insert("MdmProperty.Insert", mdmProperty);
    }

    public int Update(MdmProperty mdmProperty)
    {
        return Mapper.Update("MdmProperty.Update", mdmProperty);
    }

    public int Delete(MdmProperty mdmProperty)
    {
        return Mapper.Delete("MdmProperty.Delete", mdmProperty);
    }
}