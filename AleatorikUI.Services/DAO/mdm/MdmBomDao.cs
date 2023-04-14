using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmBomDao : IMdmBomDao
{
    public MdmBomDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmBom> GetAll()
    {
        return Mapper.QueryForList<MdmBom>("MdmBom.Select", null);
    }

    public void Insert(MdmBom mdmBom)
    {
        Mapper.Insert("MdmBom.Insert", mdmBom);
    }

    public int Update(MdmBom mdmBom)
    {
        return Mapper.Update("MdmBom.Update", mdmBom);
    }

    public int Delete(MdmBom mdmBom)
    {
        return Mapper.Delete("MdmBom.Delete", mdmBom);
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
}