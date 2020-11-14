namespace ToDo_App.Persistence.Repositories
{
    public interface IDashboardRepository
    {
        string GetCompletionMessage(int pendingTasks);
        int GetPendingTasks();
        int GetCompletedTasks();
        float CalculateRatio(float completedTasks, int pendingTasks);
        string GetRatioOfCompletion(float ratio);
        double GetDailyStuffCompletion(int dailyStuffCompletionDuration, int totalCompletedDuration);
        int GetDailyStuffCompletionDuration();
        double GetUniversityLecturesCompletion(int wordpressCompletedDuration, int totalCompletedDuration);
        int GetUniversityLecturesCompletedDuration();
        double GetJavaScriptCompletion(int typingCompletedDuration, int totalCompletedDuration);
        int GetJavaScriptCompletedDuration();
        double GetDotnetCompletion(int dotnetCompletedDuration, int totalCompletedDuration);
        int GetDotnetCompletedDuration();
        int GetTotalCompletedDuration();
        int GetDotnetPercentage();
    }
}
