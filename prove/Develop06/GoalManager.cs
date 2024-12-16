public class GoalManager
{
    private List<Goal> goals;
    private int totalScore;

    public GoalManager()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordCompletion(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordCompletion();
            totalScore += goals[index].PointsPerCompletion;
        }
    }

    public int CalculateScore()
    {
        return totalScore;
    }

    // Implement methods for saving and loading goals to/from a file
    public void SaveGoals(string filename)
    {
        // Implement file saving logic here
    }

    public void LoadGoals(string filename)
    {
        // Implement file loading logic here
    }

    public List<Goal> GetGoals()
    {
        return goals;
    }
}