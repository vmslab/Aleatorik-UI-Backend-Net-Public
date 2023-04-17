using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmSetupInfoDao : IMdmSetupInfoDao
{
    public MdmSetupInfoDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmSetupInfo> GetAll()
    {
        return Mapper.QueryForList<MdmSetupInfo>("MdmSetupInfo.Select", null);
    }

    public void Insert(MdmSetupInfo mdmSetupInfo)
    {
        Mapper.Insert("MdmSetupInfo.Insert", mdmSetupInfo);
    }

    public int Update(MdmSetupInfo mdmSetupInfo)
    {
        return Mapper.Update("MdmSetupInfo.Update", mdmSetupInfo);
    }

    public int Delete(MdmSetupInfo mdmSetupInfo)
    {
        return Mapper.Delete("MdmSetupInfo.Delete", mdmSetupInfo);
    }
}