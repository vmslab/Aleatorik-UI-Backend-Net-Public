using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmWipDao : IMdmWipDao
{
    public MdmWipDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmWip> GetAll()
    {
        return Mapper.QueryForList<MdmWip>("MdmWip.Select", null);
    }

    public void Insert(MdmWip mdmWip)
    {
        Mapper.Insert("MdmWip.Insert", mdmWip);
    }

    public int Update(MdmWip mdmWip)
    {
        return Mapper.Update("MdmWip.Update", mdmWip);
    }

    public int Delete(MdmWip mdmWip)
    {
        return Mapper.Delete("MdmWip.Delete", mdmWip);
    }
}