using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmItemSiteBufferMasterDao : IMdmItemSiteBufferMasterDao
{
    public MdmItemSiteBufferMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmItemSiteBufferMaster> GetAll(MdmItemSiteBufferMaster mdmItemSiteBufferMaster)
    {
        return Mapper.QueryForList<MdmItemSiteBufferMaster>("MdmItemSiteBufferMaster.Select", mdmItemSiteBufferMaster);
    }

    public void Insert(MdmItemSiteBufferMaster mdmItemSiteBufferMaster)
    {
        Mapper.Insert("MdmItemSiteBufferMaster.Insert", mdmItemSiteBufferMaster);
    }

    public int Update(MdmItemSiteBufferMaster mdmItemSiteBufferMaster)
    {
        return Mapper.Update("MdmItemSiteBufferMaster.Update", mdmItemSiteBufferMaster);
    }

    public int Delete(MdmItemSiteBufferMaster mdmItemSiteBufferMaster)
    {
        return Mapper.Delete("MdmItemSiteBufferMaster.Delete", mdmItemSiteBufferMaster);
    }

    /**
    *  ItemSiteBuffer PROP
    */
    public IEnumerable<MdmItemSiteBufferProp> GetAllProp(MdmItemSiteBufferProp mdmItemSiteBufferProp)
    {
        return Mapper.QueryForList<MdmItemSiteBufferProp>("MdmItemSiteBufferProp.Select", mdmItemSiteBufferProp);
    }

    public void InsertProp(MdmItemSiteBufferProp mdmItemSiteBufferProp)
    {
        Mapper.Insert("MdmItemSiteBufferProp.InsertProp", mdmItemSiteBufferProp);
    }

    public int UpdateProp(MdmItemSiteBufferProp mdmItemSiteBufferProp)
    {
        return Mapper.Update("MdmItemSiteBufferProp.Update", mdmItemSiteBufferProp);
    }

    public int DeleteProp(MdmItemSiteBufferProp mdmItemSiteBufferProp)
    {
        return Mapper.Delete("MdmItemSiteBufferProp.Delete", mdmItemSiteBufferProp);
    }
}