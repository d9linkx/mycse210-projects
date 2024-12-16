using System;
using System.Collections.Generic;
using System.Linq;

public class User
{
    public string Name { get; set; }
    public List<Goal> Goals { get; set; }
    public int TotalPoints { get; set; }

    public User(string name)
    {
        Name = name;
        Goals = new List<Goal>();
        TotalPoints = 0;
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordGoalProgress(string goalName)
    {
        var goal = Goals.FirstOrDefault(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordProgress();
            TotalPoints += goal.Points;
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine($"Goals for {Name}:");
        foreach (var goal in Goals)
        {
            goal.DisplayGoal();
        }
    }

    public void DisplayTotalPoints()
    {
        Console.WriteLine($"Total points: {TotalPoints}");
    }
}
