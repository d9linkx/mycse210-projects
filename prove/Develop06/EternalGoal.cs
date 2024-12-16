public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        // Points are added each time the event is recorded
    }

    public override string GetDetailsString()
    {
        return $"{Name} - [∞] - {Points} points each time";
    }
}
