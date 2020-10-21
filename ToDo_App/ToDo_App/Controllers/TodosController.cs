using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using ToDo_App.Models;
using ToDo_App.ViewModels;

namespace ToDo_App.Controllers
{
    public class TodosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodosController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]      
        public ActionResult Create()
        {
            var viewModel = new TodosViewModel
            {
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(TodosViewModel viewModel)
        {
            var todo = new Todo
            {
                Description = viewModel.Todos.Description,
                TodoUserId = User.Identity.GetUserId(),
                DateTime = viewModel.Todos.DateTime,
                Duration = viewModel.Todos.Duration,
                CategoryId = viewModel.Todos.CategoryId,
                IsDone = viewModel.Todos.IsDone,
                IsCanceled = viewModel.Todos.IsCanceled
            };

            _context.Todos.Add(todo);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}