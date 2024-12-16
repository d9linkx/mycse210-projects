public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordProgress()
    {
        Points += 100; // Every time progress is made, you get additional points (example).
        Console.WriteLine($"You recorded progress for '{Name}'! Total points: {Points}");
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {Name} - Total points: {Points}");
    }
}
