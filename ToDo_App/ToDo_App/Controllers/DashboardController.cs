using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ToDo_App.Extensions;
using ToDo_App.Models;

namespace ToDo_App.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController()
        {
            _context=new ApplicationDbContext();
        }

        // GET: Dashboard
        public ActionResult Index()
        {


            float completedTasks = _context.Todos.Include(m => m.Category).Count(x => x.IsDone == true);
            ViewBag.CompletedTasks = completedTasks;

            var pendingTasks = _context.Todos.Include(m => m.Category).Count(x => x.IsDone == false);
            ViewBag.PendingTasks = pendingTasks;

            float ratio = (completedTasks / (completedTasks + pendingTasks)) * 100;
            string ratioOfCompletion = String.Format("{0:0.0}", ratio);
            ViewBag.RatioOfCompletion = ratioOfCompletion;
            ViewBag.RatioPercentage = ratio;

            var dotnetPercentage = _context.Todos.Include(m => m.Category).Where(m => m.Category.Id == 1).Sum(m => m.Duration);
            ViewBag.DotnetPercentage = dotnetPercentage;

            if (pendingTasks.IsBetween(0, 3, true))
            {
                ViewBag.HowMyTasksGoing = "You are doing well";
            }
            else if (pendingTasks.IsBetween(4, 6, true))
            {
                ViewBag.HowMyTasksGoing = "You have tasks to close";
            }
            else if (pendingTasks.IsBetween(6, 9999, true))
            {
                ViewBag.HowMyTasksGoing = "You have too much open tasks";
            }

            var totalCompletedDuration = _context.Todos.Where(x => x.IsDone).Sum(x => x.Duration);
            ViewBag.TotalCompletion = totalCompletedDuration;

            var dotnetCompletedDuration = _context.Todos.Where(x => x.IsDone && x.CategoryId == 1).Sum(x => x.Duration);
            ViewBag.dotnetCompletion = Math.Round(Convert.ToDouble(dotnetCompletedDuration) /
                Convert.ToDouble(totalCompletedDuration) * 100);


            var typingCompletedDuration = _context.Todos.Where(x => x.IsDone && x.CategoryId == 2).Sum(x => x.Duration);
            ViewBag.typingCompletion = Math.Round(Convert.ToDouble(typingCompletedDuration) /
                Convert.ToDouble(totalCompletedDuration) * 100);

            var wordpressCompletedDuration = _context.Todos.Where(x => x.IsDone && x.CategoryId == 3).Sum(x => x.Duration);
            ViewBag.wordpressCompletion = Math.Round(Convert.ToDouble(wordpressCompletedDuration) /
                Convert.ToDouble(totalCompletedDuration) * 100);

            var dailyStuffCompletionDuration = _context.Todos.Where(x => x.IsDone && x.CategoryId == 4).Sum(x => x.Duration);
            ViewBag.dailyStuffCompletion = Math.Round(Convert.ToDouble(dailyStuffCompletionDuration)
                / Convert.ToDouble(totalCompletedDuration) * 100);

            //var javascriptCompletionDuration = _context.Todos.Where(x => x.IsDone && x.CategoryId == 1004).Sum(x => x.Duration);
            //ViewBag.javascriptCompletion = Math.Round(Convert.ToDouble(javascriptCompletionDuration)
            //    / Convert.ToDouble(totalCompletedDuration) * 100);

            return View();
        }
    }
}