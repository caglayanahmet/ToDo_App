using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDo_App.Models;

namespace ToDo_App.Persistence.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetTodoList(string userId);
    }
}