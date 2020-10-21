using System.Collections.Generic;
using ToDo_App.Models;

namespace ToDo_App.ViewModels
{
    public class TodosViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Todo Todos { get; set; }
    }
}