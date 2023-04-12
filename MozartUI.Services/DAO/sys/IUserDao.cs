using MozartUI.Services.DTO.sys;

namespace MozartUI.Services.DAO.sys;

public interface IUserDao
{
    public IEnumerable<UserInfo> GetAll();
    public UserInfo GetByEmail(UserInfo userInfo);
    public void Insert(UserInfo userInfo);
    public int Update(UserInfo userInfo);
    public int Delete(UserInfo userInfo);
    public UserInfo Login(AuthInfo authInfo);
}
