using AleatorikUI.Services.DTO.sam;

namespace AleatorikUI.Services.DAO.sam;

public interface ISamMenuMapDao
{
    public IEnumerable<SamMenuMapInfo> GetAll(SamMenuMapInfo samMenuMapInfo);
    public SamMenuMapInfo GetById(string samMenuMapId);
    public int Save(List<SamMenuMapInfo> samMenuMapInfos);
}
