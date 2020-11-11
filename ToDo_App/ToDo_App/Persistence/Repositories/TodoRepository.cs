using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDo_App.Models;

namespace ToDo_App.Persistence.Repositories
{
    public class TodoRepository:ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Todo> GetTodoList(string userId)
        {
            return _context.Todos.Include(x => x.Category)
                .Where(x => x.TodoUserId == userId && !x.IsCanceled);
        }
    }
}