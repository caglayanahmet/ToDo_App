using System.Data.Entity;
using System.Web.Mvc;
using ToDo_App.Models;

namespace ToDo_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context= new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var todolist = _context.Todos.Include(x => x.Category);
            return View(todolist);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}