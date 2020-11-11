using System.Collections.Generic;
using ToDo_App.Models;
using ToDo_App.ViewModels;

namespace ToDo_App.Persistence.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodoList(string userId);
        Todo GetTodoByIdAndUser(int id, string userId);
        Todo GetTodoById(TodosFormViewModel todoViewModel);
    }
}