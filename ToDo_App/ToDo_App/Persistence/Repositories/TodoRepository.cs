using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDo_App.Models;
using ToDo_App.ViewModels;

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

        public Todo GetTodoByIdAndUser(int id, string userId)
        {
            return _context.Todos.FirstOrDefault(x => x.Id == id && x.TodoUserId == userId);
        }

        public Todo GetTodoById(TodosFormViewModel todoViewModel)
        {
            return _context.Todos.Find(todoViewModel.Id);
        }
    }
}