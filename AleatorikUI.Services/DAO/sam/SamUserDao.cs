using AleatorikUI.Services.DTO.sam;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.sam;

public class SamUserDao : ISamUserDao
{
    public SamUserDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<SamUserInfo> GetAll()
    {
        return Mapper.QueryForList<SamUserInfo>("User.SelectUsers", null);
    }

    public SamUserInfo GetByEmail(SamUserInfo samUserInfo)
    {
        return Mapper.QueryForObject<SamUserInfo>("User.SelectUser", samUserInfo.Email);
    }

    public void Insert(SamUserInfo samUserInfo)
    {
        Mapper.Insert("User.InsertUser", samUserInfo);
    }

    public int Update(SamUserInfo samUserInfo)
    {
        return Mapper.Update("User.UpdateUser", samUserInfo);
    }

    public int Delete(SamUserInfo samUserInfo)
    {
        return Mapper.Delete("User.DeleteUser", samUserInfo.Email);
    }

    public SamUserInfo Login(SamAuthInfo authInfo)
    {
        return Mapper.QueryForObject<SamUserInfo>("User.Login", authInfo);
    }
}