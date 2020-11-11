using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using ToDo_App.Models;
using ToDo_App.Persistence;
using ToDo_App.ViewModels;

namespace ToDo_App.Controllers
{
    public class TodosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]      
        public ActionResult Create()
        {
            var viewModel = new TodosViewModel
            {
                Categories = _unitOfWork.Categories.GetCategoriesList()
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
                viewModel.Categories = _unitOfWork.Categories.GetCategoriesList();
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

            _unitOfWork.AddTodo(todo);
            _unitOfWork.Complete();

            return RedirectToAction("Index","Home");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var todo = _unitOfWork.Todos.GetTodoByIdAndUser(id, userId);

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

            viewModel.Categories = _unitOfWork.Categories.GetCategoriesList();
            _unitOfWork.Complete();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(TodosFormViewModel todoViewModel)
        {
            var todoItem = _unitOfWork.Todos.GetTodoById(todoViewModel);

            todoItem.IsDone = todoViewModel.IsDone;
            todoItem.CategoryId = todoViewModel.CategoryId;
            todoItem.DateTime = todoViewModel.DateTime;
            todoItem.Description = todoViewModel.Description;
            todoItem.Duration = todoViewModel.Duration;
            todoItem.IsCanceled = todoViewModel.IsCanceled;
            
            _unitOfWork.Complete();

            return RedirectToAction("index", "Home");
        }
    }
}