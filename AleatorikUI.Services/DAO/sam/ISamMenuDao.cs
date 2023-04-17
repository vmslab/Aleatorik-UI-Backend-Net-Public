using AleatorikUI.Services.DTO.sam;

namespace AleatorikUI.Services.DAO.sam;

public interface ISamMenuDao
{
    public IEnumerable<SamMenuInfo> GetAll(string systemId);
    public IEnumerable<SamMenuInfo> GetAll(SamUserInfo samUserInfo);
    public SamMenuInfo GetById(SamMenuInfo samMenuInfo);
    public int Save(List<SamMenuInfo> samMenuInfos);
}
