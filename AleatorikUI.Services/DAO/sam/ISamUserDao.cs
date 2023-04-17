using AleatorikUI.Services.DTO.sam;

namespace AleatorikUI.Services.DAO.sam;

public interface ISamUserDao
{
    public IEnumerable<SamUserInfo> GetAll();
    public SamUserInfo GetByEmail(SamUserInfo samUserInfo);
    public void Insert(SamUserInfo samUserInfo);
    public int Update(SamUserInfo samUserInfo);
    public int Delete(SamUserInfo samUserInfo);
    public SamUserInfo Login(SamAuthInfo samUserInfo);
}
