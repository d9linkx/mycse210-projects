public class SimpleGoal : Goal
{
    public bool IsComplete { get; private set; }

    public SimpleGoal(string name, int points) : base(name, points)
    {
        IsComplete = false;
    }

    public override void RecordEvent()
    {
        IsComplete = true;
    }

    public override string GetDetailsString()
    {
        return $"{Name} - {(IsComplete ? "[X]" : "[ ]")} - {Points} points";
    }
}
