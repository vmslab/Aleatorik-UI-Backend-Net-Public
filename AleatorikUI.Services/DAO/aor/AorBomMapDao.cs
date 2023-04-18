using AleatorikUI.Services.DTO.aor;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.aor;

public class AorBomMapDao : IAorBomMapDao
{
    public AorBomMapDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<AorBomMapInfo> GetBomNetworkInfos(AorBomMapParam param)
    {
        return Mapper.QueryForList<AorBomMapInfo>("BomMap.SelectBomNetworkInfos", param);
    }

    public IEnumerable<AorBomMapSub1> GetBomPathLog(AorBomMapParam param)
    {
        return Mapper.QueryForList<AorBomMapSub1>("BomMap.SelectBomNetworkInfos", param);
    }
}