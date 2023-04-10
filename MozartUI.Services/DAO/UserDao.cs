using MozartUI.Services.DTO;
using SqlBatis.DataMapper;

namespace MozartUI.Services.DAO;

public class UserDao : IUserDao
{
    public UserDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

	public IEnumerable<UserInfo> GetAll()
    {
        return Mapper.QueryForList<UserInfo>("User.SelectUsers", null);
    }

	public UserInfo GetByEmail(UserInfo userInfo)
    {
        return Mapper.QueryForObject<UserInfo>("User.SelectUser", userInfo.Email);
    }

	public void Insert(UserInfo userInfo)
    {
        Mapper.Insert("User.InsertUser", userInfo);
    }

	public int Update(UserInfo userInfo)
    {
        return Mapper.Update("User.UpdateUser", userInfo);
    }

	public int Delete(UserInfo userInfo)
	{
        return Mapper.Delete("User.DeleteUser", userInfo.Email);
	}

	public UserInfo Login(AuthInfo authInfo)
    {
        return Mapper.QueryForObject<UserInfo>("User.Login", authInfo);
    }
}