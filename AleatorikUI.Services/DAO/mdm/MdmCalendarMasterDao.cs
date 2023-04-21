using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmCalendarMasterDao : IMdmCalendarMasterDao
{
    public MdmCalendarMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmCalendarMaster> GetAll(MdmCalendarMaster mdmCalendarMaster)
    {
        return Mapper.QueryForList<MdmCalendarMaster>("MdmCalendarMaster.Select", mdmCalendarMaster);
    }

    public void Insert(MdmCalendarMaster mdmCalendarMaster)
    {
        Mapper.Insert("MdmCalendarMaster.Insert", mdmCalendarMaster);
    }

    public int Update(MdmCalendarMaster mdmCalendarMaster)
    {
        return Mapper.Update("MdmCalendarMaster.Update", mdmCalendarMaster);
    }

    public int Delete(MdmCalendarMaster mdmCalendarMaster)
    {
        return Mapper.Delete("MdmCalendarMaster.Delete", mdmCalendarMaster);
    }

    /**
     * Detail
     */
    public IEnumerable<MdmCalendarDetail> GetAllDetail(MdmCalendarDetail mdmCalendarDetail)
    {
        return Mapper.QueryForList<MdmCalendarDetail>("MdmCalendarDetail.Select", mdmCalendarDetail);
    }

    public void InsertDetail(MdmCalendarDetail mdmCalendarDetail)
    {
        Mapper.Insert("MdmCalendarDetail.Insert", mdmCalendarDetail);
    }

    public int UpdateDetail(MdmCalendarDetail mdmCalendarDetail)
    {
        return Mapper.Update("MdmCalendarDetail.Update", mdmCalendarDetail);
    }

    public int DeleteDetail(MdmCalendarDetail mdmCalendarDetail)
    {
        return Mapper.Delete("MdmCalendarDetail.Delete", mdmCalendarDetail);
    }

    /**
     * BasedAttr
     */
    public IEnumerable<MdmCalendarBasedAttr> GetAllBasedAttr(MdmCalendarBasedAttr mdmCalendarBasedAttr)
    {
        return Mapper.QueryForList<MdmCalendarBasedAttr>("MdmCalendarBasedAttr.Select", mdmCalendarBasedAttr);
    }

    public void InsertBasedAttr(MdmCalendarBasedAttr mdmCalendarBasedAttr)
    {
        Mapper.Insert("MdmCalendarBasedAttr.Insert", mdmCalendarBasedAttr);
    }

    public int UpdateBasedAttr(MdmCalendarBasedAttr mdmCalendarBasedAttr)
    {
        return Mapper.Update("MdmCalendarBasedAttr.Update", mdmCalendarBasedAttr);
    }

    public int DeleteBasedAttr(MdmCalendarBasedAttr mdmCalendarBasedAttr)
    {
        return Mapper.Delete("MdmCalendarBasedAttr.Delete", mdmCalendarBasedAttr);
    }
}