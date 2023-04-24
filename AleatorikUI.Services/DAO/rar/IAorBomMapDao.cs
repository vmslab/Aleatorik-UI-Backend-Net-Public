using AleatorikUI.Services.DTO.rar;

namespace AleatorikUI.Services.DAO.rar;

public interface IAorBomMapDao
{
    public IEnumerable<AorBomMapInfo> GetBomNetworkInfos(AorBomMapParam param);
    public IEnumerable<AorBomMapSub1> GetBomPathLog(AorBomMapParam param);
}
