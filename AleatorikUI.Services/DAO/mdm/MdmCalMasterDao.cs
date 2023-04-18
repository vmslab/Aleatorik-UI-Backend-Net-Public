using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmCalMasterDao : IMdmCalMasterDao
{
    public MdmCalMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmCalMaster> GetAll()
    {
        return Mapper.QueryForList<MdmCalMaster>("MdmCalMaster.Select", null);
    }

    public void Insert(MdmCalMaster mdmCalMaster)
    {
        Mapper.Insert("MdmCalMaster.Insert", mdmCalMaster);
    }

    public int Update(MdmCalMaster mdmCalMaster)
    {
        return Mapper.Update("MdmCalMaster.Update", mdmCalMaster);
    }

    public int Delete(MdmCalMaster mdmCalMaster)
    {
        return Mapper.Delete("MdmCalMaster.Delete", mdmCalMaster);
    }

    /**
     * Sub1
     */
    public IEnumerable<MdmCalSub1> GetAllSub1(String calendarID)
    {
        return Mapper.QueryForList<MdmCalSub1>("MdmCalSub1.Select", calendarID);
    }

    public void InsertSub1(MdmCalSub1 mdmCalSub1)
    {
        Mapper.Insert("MdmCalSub1.Insert", mdmCalSub1);
    }

    public int UpdateSub1(MdmCalSub1 mdmCalSub1)
    {
        return Mapper.Update("MdmCalSub1.Update", mdmCalSub1);
    }

    public int DeleteSub1(MdmCalSub1 mdmCalSub1)
    {
        return Mapper.Delete("MdmCalSub1.Delete", mdmCalSub1);
    }

    /**
     * Sub2
     */
    public IEnumerable<MdmCalSub2> GetAllSub2(String calendarID)
    {
        return Mapper.QueryForList<MdmCalSub2>("MdmCalSub2.Select", calendarID);
    }

    public void InsertSub2(MdmCalSub2 mdmCalSub2)
    {
        Mapper.Insert("MdmCalSub2.Insert", mdmCalSub2);
    }

    public int UpdateSub2(MdmCalSub2 mdmCalSub2)
    {
        return Mapper.Update("MdmCalSub2.Update", mdmCalSub2);
    }

    public int DeleteSub2(MdmCalSub2 mdmCalSub2)
    {
        return Mapper.Delete("MdmCalSub2.Delete", mdmCalSub2);
    }
}