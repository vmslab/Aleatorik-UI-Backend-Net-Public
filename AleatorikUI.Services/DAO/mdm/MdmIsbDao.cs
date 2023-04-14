using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmIsbDao : IMdmIsbDao
{
    public MdmIsbDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmIsb> GetAll()
    {
        return Mapper.QueryForList<MdmIsb>("MdmIsb.Select", null);
    }

    public void Insert(MdmIsb mdmIsb)
    {
        Mapper.Insert("MdmIsb.Insert", mdmIsb);
    }

    public int Update(MdmIsb mdmIsb)
    {
        return Mapper.Update("MdmIsb.Update", mdmIsb);
    }

    public int Delete(MdmIsb mdmIsb)
    {
        return Mapper.Delete("MdmIsb.Delete", mdmIsb);
    }
}