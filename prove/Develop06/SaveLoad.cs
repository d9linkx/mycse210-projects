using System;
using System.IO;

public static class SaveLoad
{
    public static void SaveUser(User user, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(user.Name);
            writer.WriteLine(user.TotalPoints);
            foreach (var goal in user.Goals)
            {
                writer.WriteLine($"{goal.Name},{goal.Points},{goal.GetType().Name}");
            }
        }
    }

    public static User LoadUser(string fileName)
    {
        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string name = reader.ReadLine();
                int totalPoints = int.Parse(reader.ReadLine());

                User user = new User(name) { TotalPoints = totalPoints };

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    string goalName = parts[0];
                    int points = int.Parse(parts[1]);
                    string goalType = parts[2];

                    Goal goal = goalType switch
                    {
                        "EternalGoal" => new EternalGoal(goalName, points),
                        "SimpleGoal" => new SimpleGoal(goalName, points),
                        "ChecklistGoal" => new ChecklistGoal(goalName, points, 10, 500),
                        _ => throw new ArgumentException("Unknown goal type.")
                    };
                    user.AddGoal(goal);
                }
                return user;
            }
        }
        else
        {
            Console.WriteLine("No saved data found.");
            return null;
        }
    }
}
