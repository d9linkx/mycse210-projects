public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never truly complete
    }

    public override void RecordCompletion()
    {
        // Implement logic for tracking progress or rewards for repeated completions
    }
}