using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmBomMasterDao : IMdmBomMasterDao
{
    public MdmBomMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmBomMaster> GetAll(String projectID)
    {
        return Mapper.QueryForList<MdmBomMaster>("MdmBomMaster.Select", projectID);
    }

    public void Insert(MdmBomMaster mdmBomMaster)
    {
        Mapper.Insert("MdmBomMaster.Insert", mdmBomMaster);
    }

    public int Update(MdmBomMaster mdmBomMaster)
    {
        return Mapper.Update("MdmBomMaster.Update", mdmBomMaster);
    }

    public int Delete(MdmBomMaster mdmBomMaster)
    {
        return Mapper.Delete("MdmBomMaster.Delete", mdmBomMaster);
    }

    /**
     * Detail
     */
    public IEnumerable<MdmBomDetail> GetAllDetail(String projectID)
    {
        return Mapper.QueryForList<MdmBomDetail>("MdmBomDetail.Select", projectID);
    }

    public void InsertDetail(MdmBomDetail mdmBomDetail)
    {
        Mapper.Insert("MdmBomDetail.Insert", mdmBomDetail);
    }

    public int UpdateDetail(MdmBomDetail mdmBomDetail)
    {
        return Mapper.Update("MdmBomDetail.Update", mdmBomDetail);
    }

    public int DeleteDetail(MdmBomDetail mdmBomDetail)
    {
        return Mapper.Delete("MdmBomDetail.Delete", mdmBomDetail);
    }

    /**
     * DetailAlt
     */
    public IEnumerable<MdmBomDetailAlt> GetAllDetailAlt(String projectID)
    {
        return Mapper.QueryForList<MdmBomDetailAlt>("MdmBomDetailAlt.Select", projectID);
    }

    public void InsertDetailAlt(MdmBomDetailAlt mdmBomDetailAlt)
    {
        Mapper.Insert("MdmBomDetailAlt.Insert", mdmBomDetailAlt);
    }

    public int UpdateDetailAlt(MdmBomDetailAlt mdmBomDetailAlt)
    {
        return Mapper.Update("MdmBomDetailAlt.Update", mdmBomDetailAlt);
    }

    public int DeleteDetailAlt(MdmBomDetailAlt mdmBomDetailAlt)
    {
        return Mapper.Delete("MdmBomDetailAlt.Delete", mdmBomDetailAlt);
    }

    /**
     * Prop
     */
    public IEnumerable<MdmBomProp> GetAllProp(String projectID)
    {
        return Mapper.QueryForList<MdmBomProp>("MdmBomProp.Select", projectID);
    }

    public void InsertProp(MdmBomProp mdmBomProp)
    {
        Mapper.Insert("MdmBomProp.Insert", mdmBomProp);
    }

    public int UpdateProp(MdmBomProp mdmBomProp)
    {
        return Mapper.Update("MdmBomProp.Update", mdmBomProp);
    }

    public int DeleteProp(MdmBomProp mdmBomProp)
    {
        return Mapper.Delete("MdmBomProp.Delete", mdmBomProp);
    }

    /**
    * Routing
    */
    public IEnumerable<MdmBomRouting> GetAllRouting(String projectID)
    {
        return Mapper.QueryForList<MdmBomRouting>("MdmBomRouting.Select", projectID);
    }

    public void InsertRouting(MdmBomRouting mdmBomRouting)
    {
        Mapper.Insert("MdmBomRouting.Insert", mdmBomRouting);
    }

    public int UpdateRouting(MdmBomRouting mdmBomRouting)
    {
        return Mapper.Update("MdmBomRouting.Update", mdmBomRouting);
    }

    public int DeleteRouting(MdmBomRouting mdmBomRouting)
    {
        return Mapper.Delete("MdmBomRouting.Delete", mdmBomRouting);
    }


    /**
    * RoutingProp
    */
    public IEnumerable<MdmBomRoutingProp> GetAllRoutingProp(String projectID)
    {
        return Mapper.QueryForList<MdmBomRoutingProp>("MdmBomRoutingProp.Select", projectID);
    }

    public void InsertRoutingProp(MdmBomRoutingProp mdmBomRoutingProp)
    {
        Mapper.Insert("MdmBomRoutingProp.Insert", mdmBomRoutingProp);
    }

    public int UpdateRoutingProp(MdmBomRoutingProp mdmBomRoutingProp)
    {
        return Mapper.Update("MdmBomRoutingProp.Update", mdmBomRoutingProp);
    }

    public int DeleteRoutingProp(MdmBomRoutingProp mdmBomRoutingProp)
    {
        return Mapper.Delete("MdmBomRoutingProp.Delete", mdmBomRoutingProp);
    }
}