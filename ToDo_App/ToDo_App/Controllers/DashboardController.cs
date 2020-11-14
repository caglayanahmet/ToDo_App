using System.Web.Mvc;
using ToDo_App.Persistence;

namespace ToDo_App.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            float completedTasks = _unitOfWork.Dashboards.GetCompletedTasks();
            ViewBag.CompletedTasks = completedTasks;

            var pendingTasks = _unitOfWork.Dashboards.GetPendingTasks();
            ViewBag.PendingTasks = pendingTasks;

            float ratio = _unitOfWork.Dashboards.CalculateRatio(completedTasks, pendingTasks);
            ViewBag.RatioPercentage = ratio;

            ViewBag.RatioOfCompletion = _unitOfWork.Dashboards.GetRatioOfCompletion(ratio);

            ViewBag.DotnetPercentage = _unitOfWork.Dashboards.GetDotnetPercentage();

            ViewBag.HowMyTasksGoing = _unitOfWork.Dashboards.GetCompletionMessage(pendingTasks);

            var totalCompletedDuration = _unitOfWork.Dashboards.GetTotalCompletedDuration();
            ViewBag.TotalCompletion = totalCompletedDuration;

            var dotnetCompletedDuration = _unitOfWork.Dashboards.GetDotnetCompletedDuration();
            ViewBag.DotnetCompletion = _unitOfWork.Dashboards.GetDotnetCompletion(dotnetCompletedDuration, totalCompletedDuration);

            var javaScriptCompletedDuration = _unitOfWork.Dashboards.GetJavaScriptCompletedDuration();
            ViewBag.JavaScriptCompletion = _unitOfWork.Dashboards.GetJavaScriptCompletion(javaScriptCompletedDuration, totalCompletedDuration);

            var universityLecturesCompletedDuration = _unitOfWork.Dashboards.GetUniversityLecturesCompletedDuration();
            ViewBag.UniversityLecturesCompletion = _unitOfWork.Dashboards.GetUniversityLecturesCompletion(universityLecturesCompletedDuration, totalCompletedDuration);

            var dailyTasksCompletionDuration = _unitOfWork.Dashboards.GetDailyStuffCompletionDuration();
            ViewBag.DailyTasksCompletion = _unitOfWork.Dashboards.GetDailyStuffCompletion(dailyTasksCompletionDuration, totalCompletedDuration);

            return View();
        }
    }
}