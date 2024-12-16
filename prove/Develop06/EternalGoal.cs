public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override void RecordCompletion()
    {
        // Increment a completion counter or similar logic
    }
}