using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmCodeGroupDao : IMdmCodeGroupDao
{
    public MdmCodeGroupDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmCodeGroup> GetAll()
    {
        return Mapper.QueryForList<MdmCodeGroup>("MdmCodeGroup.Select", null);
    }

    public void Insert(MdmCodeGroup mdmCodeGroup)
    {
        Mapper.Insert("MdmCodeGroup.Insert", mdmCodeGroup);
    }

    public int Update(MdmCodeGroup mdmCodeGroup)
    {
        return Mapper.Update("MdmCodeGroup.Update", mdmCodeGroup);
    }

    public int Delete(MdmCodeGroup mdmCodeGroup)
    {
        return Mapper.Delete("MdmCodeGroup.Delete", mdmCodeGroup);
    }

    public IEnumerable<MdmCodeGroupSub1> GetAllDetail(String categoryID)
    {
        return Mapper.QueryForList<MdmCodeGroupSub1>("MdmCodeGroupSub1.Select", categoryID);
    }

    public void InsertDetail(MdmCodeGroupSub1 mdmCodeGroupSub1)
    {
        Mapper.Insert("MdmCodeGroupSub1.Insert", mdmCodeGroupSub1);
    }

    public int UpdateDetail(MdmCodeGroupSub1 mdmCodeGroupSub1)
    {
        return Mapper.Update("MdmCodeGroupSub1.Update", mdmCodeGroupSub1);
    }

    public int DeleteDetail(MdmCodeGroupSub1 mdmCodeGroupSub1)
    {
        return Mapper.Delete("MdmCodeGroupSub1.Delete", mdmCodeGroupSub1);
    }
}