using System.IO;

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

    public List<Goal> GetGoals()
    {
        return goals;
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalScore);
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Description},{goal.PointsPerCompletion}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"TargetCompletions:{checklistGoal.targetCompletions},CurrentCompletions:{checklistGoal.currentCompletions}");
                }
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                totalScore = int.Parse(reader.ReadLine());
                goals.Clear();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string goalType = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    Goal goal;
                    if (goalType == "SimpleGoal")
                    {
                        goal = new SimpleGoal(name, description, points);
                    }
                    else if (goalType == "EternalGoal")
                    {
                        goal = new EternalGoal(name, description, points);
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        string[] checklistParts = reader.ReadLine().Split(',');
                        int targetCompletions = int.Parse(checklistParts[1]);
                        int currentCompletions = int.Parse(checklistParts[3]);
                        goal = new ChecklistGoal(name, description, points, targetCompletions);
                        ((ChecklistGoal)goal).currentCompletions = currentCompletions;
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown goal type");
                    }

                    goals.Add(goal);
                }
            }
        }
    }
}