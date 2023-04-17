using AleatorikUI.Services.DTO.sam;
using SqlBatis.DataMapper;

namespace AleatorikUI.Services.DAO.sam;

public class SamGroupDao : ISamGroupDao
{
    public SamGroupDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<SamGroupInfo> GetAll()
    {
        return Mapper.QueryForList<SamGroupInfo>("Group.SelectGroups", null);
    }

    public SamGroupInfo GetById(SamGroupInfo samGroupInfo)
    {
        return Mapper.QueryForObject<SamGroupInfo>("Group.SelectGroup", samGroupInfo.GroupId);
    }

    public IEnumerable<SamGroupInfo> GetBySystem(string systemId)
    {
        return Mapper.QueryForList<SamGroupInfo>("Group.SelectGroupsBySystem", systemId);
    }

    public void Insert(SamGroupInfo samGroupInfo)
    {
        Mapper.Insert("Group.InsertGroup", samGroupInfo);
    }

    public int Update(SamGroupInfo samGroupInfo)
    {
        return Mapper.Update("Group.UpdateGroup", samGroupInfo);
    }

    public int Delete(SamGroupInfo samGroupInfo)
    {
        Mapper.Update("User.UpdateUserGroup", samGroupInfo.GroupId);
        return Mapper.Delete("Group.DeleteGroup", samGroupInfo.GroupId);
    }
}