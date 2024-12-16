class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        // Add goals
        goalManager.AddGoal(new SimpleGoal("Run a Marathon", "Complete a full marathon", 1000));
        goalManager.AddGoal(new EternalGoal("Read Scriptures Daily", "Read scriptures daily", 10));
        goalManager.AddGoal(new ChecklistGoal("Attend Temple", "Attend the temple 10 times", 50, 10));

        // Record completions
        goalManager.RecordCompletion(0); // Complete the marathon goal
        goalManager.RecordCompletion(1); // Read scriptures
        goalManager.RecordCompletion(2); // Attend the temple

        // Display goals and progress
        foreach (Goal goal in goalManager.Goals)
        {
            Console.WriteLine($"Goal: {goal.Name}");
            Console.WriteLine($"Description: {goal.Description}");
            Console.WriteLine($"Points per completion: {goal.PointsPerCompletion}");
            Console.WriteLine($"Is complete: {goal.IsComplete()}");
            Console.WriteLine();
        }

        Console.WriteLine($"Total Score: {goalManager.CalculateScore()}");
    }
}