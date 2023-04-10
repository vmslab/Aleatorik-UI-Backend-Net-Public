using MozartUI.Services.DTO;

namespace MozartUI.Services.DAO;

public interface IGroupDao
{
    public IEnumerable<GroupInfo> GetAll();
    public GroupInfo GetById(GroupInfo groupInfo);
    public IEnumerable<GroupInfo> GetBySystem(GroupInfo groupInfo);
    public void Insert(GroupInfo groupInfo);
    public int Update(GroupInfo groupInfo);
    public int Delete(GroupInfo groupInfo);
}
