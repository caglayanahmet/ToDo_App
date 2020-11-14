using System;
using System.Data.Entity;
using System.Linq;
using ToDo_App.Extensions;
using ToDo_App.Models;

namespace ToDo_App.Persistence.Repositories
{
    public class DashboardRepository:IDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetCompletionMessage(int pendingTasks)
        {
            if (pendingTasks.IsBetween(0, 3, true))
                return "You are doing well";
            else if (pendingTasks.IsBetween(4, 6, true))
                return "You have tasks to close";
            else if (pendingTasks.IsBetween(6, 9999, true))
                return "You have too much open tasks";
            else
                return "";
        }

        public int GetPendingTasks()
        {
            return _context.Todos.Include(m => m.Category).Count(x => x.IsDone == false);
        }

        public int GetCompletedTasks()
        {
            return _context.Todos.Include(m => m.Category).Count(x => x.IsDone == true);
        }

        public float CalculateRatio(float completedTasks, int pendingTasks)
        {
            return (completedTasks / (completedTasks + pendingTasks)) * 100;
        }

        public string GetRatioOfCompletion(float ratio)
        {
            return String.Format("{0:0.0}", ratio);
        }

        public  double GetDailyStuffCompletion(int dailyStuffCompletionDuration, int totalCompletedDuration)
        {
            return Math.Round(Convert.ToDouble(dailyStuffCompletionDuration)
                / Convert.ToDouble(totalCompletedDuration) * 100);
        }

        public int GetDailyStuffCompletionDuration()
        {
            return _context.Todos.Where(x => x.IsDone && x.CategoryId == 4).Sum(x => x.Duration);
        }

        public  double GetUniversityLecturesCompletion(int wordpressCompletedDuration, int totalCompletedDuration)
        {
            return Math.Round(Convert.ToDouble(wordpressCompletedDuration) /
                Convert.ToDouble(totalCompletedDuration) * 100);
        }

        public int GetUniversityLecturesCompletedDuration()
        {
            return _context.Todos.Where(x => x.IsDone && x.CategoryId == 3).Sum(x => x.Duration);
        }

        public  double GetJavaScriptCompletion(int typingCompletedDuration, int totalCompletedDuration)
        {
            return Math.Round(Convert.ToDouble(typingCompletedDuration) /
                Convert.ToDouble(totalCompletedDuration) * 100);
        }

        public int GetJavaScriptCompletedDuration()
        {
            return _context.Todos.Where(x => x.IsDone && x.CategoryId == 2).Sum(x => x.Duration);
        }

        public  double GetDotnetCompletion(int dotnetCompletedDuration, int totalCompletedDuration)
        {
            return Math.Round(Convert.ToDouble(dotnetCompletedDuration) /
                Convert.ToDouble(totalCompletedDuration) * 100);
        }

        public int GetDotnetCompletedDuration()
        {
            return _context.Todos.Where(x => x.IsDone && x.CategoryId == 1).Sum(x => x.Duration);
        }

        public int GetTotalCompletedDuration()
        {
            return _context.Todos.Where(x => x.IsDone).Sum(x => x.Duration);
        }

        public int GetDotnetPercentage()
        {
            return _context.Todos.Include(m => m.Category).Where(m => m.Category.Id == 1).Sum(m => m.Duration);
        }
    }
}