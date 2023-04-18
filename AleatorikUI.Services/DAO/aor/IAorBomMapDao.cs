using AleatorikUI.Services.DTO.aor;

namespace AleatorikUI.Services.DAO.aor;

public interface IAorBomMapDao
{
    public IEnumerable<AorBomMapInfo> GetBomNetworkInfos(AorBomMapParam param);
    public IEnumerable<AorBomMapSub1> GetBomPathLog(AorBomMapParam param);
}
