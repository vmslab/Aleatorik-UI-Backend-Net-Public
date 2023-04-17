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

    public IEnumerable<MdmBomMaster> GetAll()
    {
        return Mapper.QueryForList<MdmBomMaster>("MdmBomMaster.Select", null);
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
     * Sub1
     */
    public IEnumerable<MdmBomSub1> GetAllSub1(String bomID)
    {
        return Mapper.QueryForList<MdmBomSub1>("MdmBomSub1.Select", bomID);
    }

    public void InsertSub1(MdmBomSub1 mdmBomSub1)
    {
        Mapper.Insert("MdmBomSub1.Insert", mdmBomSub1);
    }

    public int UpdateSub1(MdmBomSub1 mdmBomSub1)
    {
        return Mapper.Update("MdmBomSub1.Update", mdmBomSub1);
    }

    public int DeleteSub1(MdmBomSub1 mdmBomSub1)
    {
        return Mapper.Delete("MdmBomSub1.Delete", mdmBomSub1);
    }

    /**
     * Sub2
     */
    public IEnumerable<MdmBomSub2> GetAllSub2(String bomID)
    {
        return Mapper.QueryForList<MdmBomSub2>("MdmBomSub2.Select", bomID);
    }

    public void InsertSub2(MdmBomSub2 mdmBomSub2)
    {
        Mapper.Insert("MdmBomSub2.Insert", mdmBomSub2);
    }

    public int UpdateSub2(MdmBomSub2 mdmBomSub2)
    {
        return Mapper.Update("MdmBomSub2.Update", mdmBomSub2);
    }

    public int DeleteSub2(MdmBomSub2 mdmBomSub2)
    {
        return Mapper.Delete("MdmBomSub2.Delete", mdmBomSub2);
    }

    /**
     * Sub3
     */
    public IEnumerable<MdmBomSub3> GetAllSub3(String bomID)
    {
        return Mapper.QueryForList<MdmBomSub3>("MdmBomSub3.Select", bomID);
    }

    public void InsertSub3(MdmBomSub3 mdmBomSub3)
    {
        Mapper.Insert("MdmBomSub3.Insert", mdmBomSub3);
    }

    public int UpdateSub3(MdmBomSub3 mdmBomSub3)
    {
        return Mapper.Update("MdmBomSub3.Update", mdmBomSub3);
    }

    public int DeleteSub3(MdmBomSub3 mdmBomSub3)
    {
        return Mapper.Delete("MdmBomSub3.Delete", mdmBomSub3);
    }

    /**
    * Sub4
    */
    public IEnumerable<MdmBomSub4> GetAllSub4(String bomID)
    {
        return Mapper.QueryForList<MdmBomSub4>("MdmBomSub4.Select", bomID);
    }

    public void InsertSub4(MdmBomSub4 mdmBomSub4)
    {
        Mapper.Insert("MdmBomSub4.Insert", mdmBomSub4);
    }

    public int UpdateSub4(MdmBomSub4 mdmBomSub4)
    {
        return Mapper.Update("MdmBomSub4.Update", mdmBomSub4);
    }

    public int DeleteSub4(MdmBomSub4 mdmBomSub4)
    {
        return Mapper.Delete("MdmBomSub4.Delete", mdmBomSub4);
    }


    /**
    * Sub5
    */
    public IEnumerable<MdmBomSub5> GetAllSub5(String bomID)
    {
        return Mapper.QueryForList<MdmBomSub5>("MdmBomSub5.Select", bomID);
    }

    public void InsertSub5(MdmBomSub5 mdmBomSub5)
    {
        Mapper.Insert("MdmBomSub5.Insert", mdmBomSub5);
    }

    public int UpdateSub5(MdmBomSub5 mdmBomSub5)
    {
        return Mapper.Update("MdmBomSub5.Update", mdmBomSub5);
    }

    public int DeleteSub5(MdmBomSub5 mdmBomSub5)
    {
        return Mapper.Delete("MdmBomSub5.Delete", mdmBomSub5);
    }
}