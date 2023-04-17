using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmItemMasterDao : IMdmItemMasterDao
{
    public MdmItemMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmItemMaster> GetAll()
    {
        return Mapper.QueryForList<MdmItemMaster>("MdmItemMaster.Select", null);
    }

    public void Insert(MdmItemMaster mdmItemMaster)
    {
        Mapper.Insert("MdmItemMaster.Insert", mdmItemMaster);
    }

    public int Update(MdmItemMaster mdmItemMaster)
    {
        return Mapper.Update("MdmItemMaster.Update", mdmItemMaster);
    }

    public int Delete(MdmItemMaster mdmItemMaster)
    {
        return Mapper.Delete("MdmItemMaster.Delete", mdmItemMaster);
    }
}