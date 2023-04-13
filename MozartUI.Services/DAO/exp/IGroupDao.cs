using AleatorikUI.Services.DTO.sys;

namespace AleatorikUI.Services.DAO.exp;

public interface IGroupDao
{
    public IEnumerable<GroupInfo> GetAll();
    public GroupInfo GetById(GroupInfo groupInfo);
    public IEnumerable<GroupInfo> GetBySystem(GroupInfo groupInfo);
    public void Insert(GroupInfo groupInfo);
    public int Update(GroupInfo groupInfo);
    public int Delete(GroupInfo groupInfo);
}
