public class SimpleGoal : Goal
{
    private bool isCompleted;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        isCompleted = false;
    }

    public override bool IsComplete()
    {
        return isCompleted;
    }

    public override void RecordCompletion()
    {
        isCompleted = true;
    }
}