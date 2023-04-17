using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmOperResMasterDao : IMdmOperResMasterDao
{
    public MdmOperResMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmOperResMaster> GetAll()
    {
        return Mapper.QueryForList<MdmOperResMaster>("MdmOperResMaster.Select", null);
    }

    public void Insert(MdmOperResMaster mdmOperResMaster)
    {
        Mapper.Insert("MdmOperResMaster.Insert", mdmOperResMaster);
    }

    public int Update(MdmOperResMaster mdmOperResMaster)
    {
        return Mapper.Update("MdmOperResMaster.Update", mdmOperResMaster);
    }

    public int Delete(MdmOperResMaster mdmOperResMaster)
    {
        return Mapper.Delete("MdmOperResMaster.Delete", mdmOperResMaster);
    }

    /**
     * Sub1
     */
    public IEnumerable<MdmOperResSub1> GetAllSub1(String routingID)
    {
        return Mapper.QueryForList<MdmOperResSub1>("MdmOperResSub1.Select", routingID);
    }

    public void InsertSub1(MdmOperResSub1 mdmOperResSub1)
    {
        Mapper.Insert("MdmOperResSub1.Insert", mdmOperResSub1);
    }

    public int UpdateSub1(MdmOperResSub1 mdmOperResSub1)
    {
        return Mapper.Update("MdmOperResSub1.Update", mdmOperResSub1);
    }

    public int DeleteSub1(MdmOperResSub1 mdmOperResSub1)
    {
        return Mapper.Delete("MdmOperResSub1.Delete", mdmOperResSub1);
    }
}