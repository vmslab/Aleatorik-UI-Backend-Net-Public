using AleatorikUI.Services.DTO.sam;

namespace AleatorikUI.Services.DAO.sam;

public interface IGroupDao
{
    public IEnumerable<GroupInfo> GetAll();
    public GroupInfo GetById(GroupInfo groupInfo);
    public IEnumerable<GroupInfo> GetBySystem(string systemId);
    public void Insert(GroupInfo groupInfo);
    public int Update(GroupInfo groupInfo);
    public int Delete(GroupInfo groupInfo);
}
