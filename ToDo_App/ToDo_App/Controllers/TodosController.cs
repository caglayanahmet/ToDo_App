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

        
        // GET: Todos
        public ActionResult Create()
        {
            var viewModel = new TodosViewModel
            {
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);
        }
    }
}