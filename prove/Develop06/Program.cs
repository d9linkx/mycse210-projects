using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        User user = new User("John Doe");

        // Example Goals
        Goal scriptureGoal = new EternalGoal("Read Scriptures", 0);
        Goal marathonGoal = new SimpleGoal("Run Marathon", 1000);
        Goal templeGoal = new ChecklistGoal("Attend the Temple", 50, 10, 500);

        user.AddGoal(scriptureGoal);
        user.AddGoal(marathonGoal);
        user.AddGoal(templeGoal);

        // Simulate user progress
        user.RecordGoalProgress("Read Scriptures");
        user.RecordGoalProgress("Run Marathon");
        user.RecordGoalProgress("Attend the Temple");

        // Display User's Progress
        user.DisplayGoals();
        user.DisplayTotalPoints();
    }
}
