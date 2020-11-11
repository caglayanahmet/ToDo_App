using System.Collections.Generic;
using System.Linq;
using ToDo_App.Models;

namespace ToDo_App.Persistence.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Category> GetCategoriesList()
        {
            return _context.Categories.ToList();
        }
    }
}