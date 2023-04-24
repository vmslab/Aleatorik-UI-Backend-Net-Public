using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmRoutingMasterDao : IMdmRoutingMasterDao
{
    public MdmRoutingMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmRoutingMaster> GetAll()
    {
        return Mapper.QueryForList<MdmRoutingMaster>("MdmRoutingMaster.Select", null);
    }

    public void Insert(MdmRoutingMaster mdmRoutingMaster)
    {
        Mapper.Insert("MdmRoutingMaster.Insert", mdmRoutingMaster);
    }

    public int Update(MdmRoutingMaster mdmRoutingMaster)
    {
        return Mapper.Update("MdmRoutingMaster.Update", mdmRoutingMaster);
    }

    public int Delete(MdmRoutingMaster mdmRoutingMaster)
    {
        return Mapper.Delete("MdmRoutingMaster.Delete", mdmRoutingMaster);
    }

    /**
     * Sub1
     */
    public IEnumerable<MdmRoutingOper> GetAllSub1(String routingID)
    {
        return Mapper.QueryForList<MdmRoutingOper>("MdmRoutingSub1.Select", routingID);
    }

    public void InsertSub1(MdmRoutingOper mdmRoutingSub1)
    {
        Mapper.Insert("MdmRoutingSub1.Insert", mdmRoutingSub1);
    }

    public int UpdateSub1(MdmRoutingOper mdmRoutingSub1)
    {
        return Mapper.Update("MdmRoutingSub1.Update", mdmRoutingSub1);
    }

    public int DeleteSub1(MdmRoutingOper mdmRoutingSub1)
    {
        return Mapper.Delete("MdmRoutingSub1.Delete", mdmRoutingSub1);
    }

    /**
     * Sub2
     */
    public IEnumerable<MdmRoutingOperProp> GetAllSub2(String routingID)
    {
        return Mapper.QueryForList<MdmRoutingOperProp>("MdmRoutingSub2.Select", routingID);
    }

    public void InsertSub2(MdmRoutingOperProp mdmRoutingSub2)
    {
        Mapper.Insert("MdmRoutingSub2.Insert", mdmRoutingSub2);
    }

    public int UpdateSub2(MdmRoutingOperProp mdmRoutingSub2)
    {
        return Mapper.Update("MdmRoutingSub2.Update", mdmRoutingSub2);
    }

    public int DeleteSub2(MdmRoutingOperProp mdmRoutingSub2)
    {
        return Mapper.Delete("MdmRoutingSub2.Delete", mdmRoutingSub2);
    }
}