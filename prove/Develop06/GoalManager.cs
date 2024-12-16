using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class GoalManager
{
    private List<BaseGoal> _goals;
    private int _totalPoints;

    public GoalManager()
    {
        _goals = new List<BaseGoal>();
        _totalPoints = 0;
    }

    public void AddGoal(BaseGoal goal)
    {
        _goals.Add(goal);
    }

    public void RecordGoal(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordGoal();
            _totalPoints += _goals[index].Points;
        }
    }

    public void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetGoalDetails());
        }
        Console.WriteLine($"Total Points: {_totalPoints}\n");
    }

    public void SaveGoals(string filePath)
    {
        var json = JsonConvert.SerializeObject(_goals, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public void LoadGoals(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            _goals = JsonConvert.DeserializeObject<List<BaseGoal>>(json);
        }
    }
}
