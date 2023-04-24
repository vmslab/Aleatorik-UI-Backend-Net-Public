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

    public IEnumerable<MdmItemMaster> GetAll(MdmItemMaster mdmItemMaster)
    {
        return Mapper.QueryForList<MdmItemMaster>("MdmItemMaster.Select", mdmItemMaster);
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

    /**
    *  Item PROP
    */
    public IEnumerable<MdmItemProp> GetAllProp(MdmItemProp mdmItemProp)
    {
        return Mapper.QueryForList<MdmItemProp>("MdmItemProp.Select", mdmItemProp);
    }

    public void InsertProp(MdmItemProp mdmItemProp)
    {
        Mapper.Insert("MdmItemProp.InsertProp", mdmItemProp);
    }

    public int UpdateProp(MdmItemProp mdmItemProp)
    {
        return Mapper.Update("MdmItemProp.Update", mdmItemProp);
    }

    public int DeleteProp(MdmItemProp mdmItemProp)
    {
        return Mapper.Delete("MdmItemProp.Delete", mdmItemProp);
    }
}