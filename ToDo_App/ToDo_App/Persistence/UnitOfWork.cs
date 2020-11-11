using ToDo_App.Models;
using ToDo_App.Persistence.Repositories;

namespace ToDo_App.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ITodoRepository Todos { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Todos = new TodoRepository(context);
        }
    }
}