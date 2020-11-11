using System.Collections.Generic;
using ToDo_App.Models;

namespace ToDo_App.Persistence.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategoriesList();
    }
}