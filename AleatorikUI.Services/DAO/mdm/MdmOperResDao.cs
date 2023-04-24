using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmOperResDao : IMdmOperResDao
{
    public MdmOperResDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmOperRes> GetAll(MdmOperRes mdmOperRes)
    {
        return Mapper.QueryForList<MdmOperRes>("MdmOperRes.Select", mdmOperRes);
    }

    public void Insert(MdmOperRes mdmOperRes)
    {
        Mapper.Insert("MdmOperRes.Insert", mdmOperRes);
    }

    public int Update(MdmOperRes mdmOperRes)
    {
        return Mapper.Update("MdmOperRes.Update", mdmOperRes);
    }

    public int Delete(MdmOperRes mdmOperRes)
    {
        return Mapper.Delete("MdmOperRes.Delete", mdmOperRes);
    }

    /**
     * OperRes Prop
     */
    public IEnumerable<MdmOperResProp> GetAllProp(MdmOperResProp mdmOperResProp)
    {
        return Mapper.QueryForList<MdmOperResProp>("MdmOperResProp.Select", mdmOperResProp);
    }

    public void InsertProp(MdmOperResProp mdmOperResProp)
    {
        Mapper.Insert("MdmOperResProp.Insert", mdmOperResProp);
    }

    public int UpdateProp(MdmOperResProp mdmOperResProp)
    {
        return Mapper.Update("MdmOperResProp.Update", mdmOperResProp);
    }

    public int DeleteProp(MdmOperResProp mdmOperResProp)
    {
        return Mapper.Delete("MdmOperResProp.Delete", mdmOperResProp);
    }

    /**
     * OperRes Add Res
     */
    public IEnumerable<MdmOperAddRes> GetAllAddRes(MdmOperAddRes mdmOperAddRes)
    {
        return Mapper.QueryForList<MdmOperAddRes>("MdmOperAddRes.Select", mdmOperAddRes);
    }

    public void InsertAddRes(MdmOperAddRes mdmOperAddRes)
    {
        Mapper.Insert("MdmOperAddRes.Insert", mdmOperAddRes);
    }

    public int UpdateAddRes(MdmOperAddRes mdmOperAddRes)
    {
        return Mapper.Update("MdmOperAddRes.Update", mdmOperAddRes);
    }

    public int DeleteAddRes(MdmOperAddRes mdmOperAddRes)
    {
        return Mapper.Delete("MdmOperAddRes.Delete", mdmOperAddRes);
    }

    /**
     * OperRes Add Res Prop
     */
    public IEnumerable<MdmOperAddResProp> GetAllAddResProp(MdmOperAddResProp mdmOperAddResProp)
    {
        return Mapper.QueryForList<MdmOperAddResProp>("MdmOperAddResProp.Select", mdmOperAddResProp);
    }

    public void InsertAddResProp(MdmOperAddResProp mdmOperAddResProp)
    {
        Mapper.Insert("MdmOperAddResProp.Insert", mdmOperAddResProp);
    }

    public int UpdateAddResProp(MdmOperAddResProp mdmOperAddResProp)
    {
        return Mapper.Update("MdmOperAddResProp.Update", mdmOperAddResProp);
    }

    public int DeleteAddResProp(MdmOperAddResProp mdmOperAddResProp)
    {
        return Mapper.Delete("MdmOperAddResProp.Delete", mdmOperAddResProp);
    }
}