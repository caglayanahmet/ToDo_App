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
        [ValidateAntiForgeryToken]
        public ActionResult Create(TodosViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }
            var todo = new Todo
            {
                Description = viewModel.Description,
                TodoUserId = User.Identity.GetUserId(),
                DateTime = viewModel.DateTime,
                Duration = viewModel.Duration,
                CategoryId = viewModel.CategoryId,
                IsDone = viewModel.IsDone,
                IsCanceled = false
            };

            _context.Todos.Add(todo);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}