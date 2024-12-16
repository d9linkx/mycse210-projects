using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        goalManager.LoadGoals("goals.json");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to your Eternal Quest!");
            Console.WriteLine("1. Add a new goal");
            Console.WriteLine("2. Record progress for a goal");
            Console.WriteLine("3. Show all goals");
            Console.WriteLine("4. Save and exit");
            Console.Write("Please choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewGoal(goalManager);
                    break;
                case "2":
                    RecordGoalProgress(goalManager);
                    break;
                case "3":
                    goalManager.ShowGoals();
                    break;
                case "4":
                    goalManager.SaveGoals("goals.json");
                    Console.WriteLine("Goals saved. Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void AddNewGoal(GoalManager goalManager)
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string goalType = Console.ReadLine();

        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();

        switch (goalType)
        {
            case "1":
                Console.Write("Enter points for completing this goal: ");
                int simplePoints = int.Parse(Console.ReadLine());
                goalManager.AddGoal(new SimpleGoal(name, simplePoints));
                break;
            case "2":
                Console.Write("Enter points for each recording: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                goalManager.AddGoal(new EternalGoal(name, eternalPoints));
                break;
            case "3":
                Console.Write("Enter the target number of completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter points per completion: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completion: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goalManager.AddGoal(new ChecklistGoal(name, target, checklistPoints, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void RecordGoalProgress(GoalManager goalManager)
    {
        goalManager.ShowGoals();
        Console.Write("Enter the number of the goal you want to record progress for: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        goalManager.RecordGoal(index);
    }
}
