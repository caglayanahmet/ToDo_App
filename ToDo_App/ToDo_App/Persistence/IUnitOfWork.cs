using ToDo_App.Models;
using ToDo_App.Persistence.Repositories;

namespace ToDo_App.Persistence
{
    public interface IUnitOfWork
    {
        ITodoRepository Todos { get; }
        ICategoryRepository Categories { get; }
        IDashboardRepository Dashboards { get; }
        void AddTodo(Todo todo);
        void Complete();

    }
}