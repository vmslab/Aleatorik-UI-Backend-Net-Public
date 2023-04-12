using MozartUI.Services.DTO.exp;

namespace MozartUI.Services.DAO.exp;

public interface ITodoDao
{
    public IEnumerable<TodoInfo> GetAll();
    public TodoInfo GetById(TodoInfo todoInfo);
    public void Insert(TodoInfo todoInfo);
    public int Update(TodoInfo todoInfo);
    public int Delete(TodoInfo todoInfo);
}
