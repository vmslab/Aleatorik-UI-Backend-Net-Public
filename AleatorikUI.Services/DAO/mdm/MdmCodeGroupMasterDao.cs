using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmCodeGroupMasterDao : IMdmCodeGroupMasterDao
{
    public MdmCodeGroupMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmCodeGroupMaster> GetAll()
    {
        return Mapper.QueryForList<MdmCodeGroupMaster>("MdmCodeGroupMaster.Select", null);
    }

    public void Insert(MdmCodeGroupMaster mdmCodeGroupMaster)
    {
        Mapper.Insert("MdmCodeGroupMaster.Insert", mdmCodeGroupMaster);
    }

    public int Update(MdmCodeGroupMaster mdmCodeGroupMaster)
    {
        return Mapper.Update("MdmCodeGroupMaster.Update", mdmCodeGroupMaster);
    }

    public int Delete(MdmCodeGroupMaster mdmCodeGroupMaster)
    {
        return Mapper.Delete("MdmCodeGroupMaster.Delete", mdmCodeGroupMaster);
    }

    /**
     * Sub1
     */
    public IEnumerable<MdmCodeGroupSub1> GetAllSub1(String categoryID)
    {
        return Mapper.QueryForList<MdmCodeGroupSub1>("MdmCodeGroupSub1.Select", categoryID);
    }

    public void InsertSub1(MdmCodeGroupSub1 mdmCodeGroupSub1)
    {
        Mapper.Insert("MdmCodeGroupSub1.Insert", mdmCodeGroupSub1);
    }

    public int UpdateSub1(MdmCodeGroupSub1 mdmCodeGroupSub1)
    {
        return Mapper.Update("MdmCodeGroupSub1.Update", mdmCodeGroupSub1);
    }

    public int DeleteSub1(MdmCodeGroupSub1 mdmCodeGroupSub1)
    {
        return Mapper.Delete("MdmCodeGroupSub1.Delete", mdmCodeGroupSub1);
    }
}