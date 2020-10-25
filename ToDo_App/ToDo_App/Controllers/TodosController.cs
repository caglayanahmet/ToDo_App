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

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var todo = _context.Todos.FirstOrDefault(x=>x.Id==id && x.TodoUserId==userId);

            var viewModel = new TodosFormViewModel
            {
                Description = todo.Description,
                DateTime = todo.DateTime,
                Duration = todo.Duration,
                CategoryId = todo.CategoryId,
                IsDone = todo.IsDone,
                IsCanceled = todo.IsCanceled,
                TodoUserId = User.Identity.GetUserId()
                
            };

            viewModel.Categories = _context.Categories.ToList();
            _context.SaveChanges();

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Save(TodosFormViewModel todoViewModel)
        {
            var todoItem = _context.Todos.Find(todoViewModel.Id);

            todoItem.IsDone = todoViewModel.IsDone;
            todoItem.CategoryId = todoViewModel.CategoryId;
            todoItem.DateTime = todoViewModel.DateTime;
            todoItem.Description = todoViewModel.Description;
            todoItem.Duration = todoViewModel.Duration;
            todoItem.IsCanceled = todoViewModel.IsCanceled;
            
            _context.SaveChanges();

            return RedirectToAction("index", "Home");
        }
    }
}