using MozartUI.Services.DTO;
using SqlBatis.DataMapper;

namespace MozartUI.Services.DAO;

public class TodoDao : ITodoDao
{
    public TodoDao(ISqlMapper mapper)
    {
        Mapper = mapper;
    }

    private ISqlMapper Mapper { get; }

    public IEnumerable<TodoInfo> GetAll()
    {
        return Mapper.QueryForList<TodoInfo>("Todo.SelectTodos", null);
    }

    public TodoInfo GetById(TodoInfo todoInfo)
    {
        return Mapper.QueryForObject<TodoInfo>("Todo.SelectTodo", todoInfo.Id);
    }

    public void Insert(TodoInfo todoInfo)
    {
        Mapper.Insert("Todo.InsertTodo", todoInfo);
    }

    public int Update(TodoInfo todoInfo)
    {
        return Mapper.Update("Todo.UpdateTodo", todoInfo);
    }

    public int Delete(TodoInfo todoInfo)
    {
        return Mapper.Delete("Todo.DeleteTodo", todoInfo.Id);
    }
}