using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmItemDao : IMdmItemDao
{
    public MdmItemDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmItem> GetAll()
    {
        return Mapper.QueryForList<MdmItem>("MdmItem.Select", null);
    }

    public void Insert(MdmItem mdmItem)
    {
        Mapper.Insert("MdmItem.Insert", mdmItem);
    }

    public int Update(MdmItem mdmItem)
    {
        return Mapper.Update("MdmItem.Update", mdmItem);
    }

    public int Delete(MdmItem mdmItem)
    {
        return Mapper.Delete("MdmItem.Delete", mdmItem);
    }
}