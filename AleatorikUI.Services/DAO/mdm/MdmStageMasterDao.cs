using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmStageMasterDao : IMdmStageMasterDao
{
    public MdmStageMasterDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmStageMaster> GetAll()
    {
        return Mapper.QueryForList<MdmStageMaster>("MdmStage.Select", null);
    }

    public void Insert(MdmStageMaster msmStageMaster)
    {
        Mapper.Insert("MdmStage.Insert", msmStageMaster);
    }

    public int Update(MdmStageMaster msmStageMaster)
    {
        return Mapper.Update("MdmStage.Update", msmStageMaster);
    }

    public int Delete(MdmStageMaster msmStageMaster)
    {
        return Mapper.Delete("MdmStage.Delete", msmStageMaster);
    }
}