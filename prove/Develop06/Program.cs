using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        SimpleGoal goal1 = new SimpleGoal("Run a marathon", 1000);
        goals.Add(goal1);

        EternalGoal goal2 = new EternalGoal("Read scriptures", 100);
        goals.Add(goal2);

        ChecklistGoal goal3 = new ChecklistGoal("Attend temple", 50, 10, 500);
        goals.Add(goal3);

        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }

        // Example of recording events
        goal1.RecordEvent();
        goal2.RecordEvent();
        goal3.RecordEvent();
        goal3.RecordEvent();

        Console.WriteLine("\nAfter recording events:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }
}
