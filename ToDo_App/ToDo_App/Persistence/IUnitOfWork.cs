using ToDo_App.Persistence.Repositories;

namespace ToDo_App.Persistence
{
    public interface IUnitOfWork
    {
        ITodoRepository Todos { get; }
    }
}