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
        return Mapper.Delete("MdmCodeGroup.Delete", mdmCodeGroup.categoryID);
    }
}