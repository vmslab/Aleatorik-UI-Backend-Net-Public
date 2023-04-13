using AleatorikUI.Services.DTO.mdm;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.mdm;

public class MdmStageDao : IMdmStageDao
{
    public MdmStageDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<MdmStage> GetAll()
    {
        return Mapper.QueryForList<MdmStage>("MdmStage.Select", null);
    }

    public MdmStage GetById(string mdmStage)
    {
        return Mapper.QueryForObject<MdmStage>("MdmStage.SelectID", mdmStage);
    }

    public void Insert(MdmStage mdmStage)
    {
        Mapper.Insert("MdmStage.Insert", mdmStage);
    }

    public int Update(MdmStage mdmStage)
    {
        return Mapper.Update("MdmStage.Update", mdmStage);
    }

    public int Delete(MdmStage mdmStage)
    {
        return Mapper.Delete("MdmStage.Delete", mdmStage.stageID);
    }
}