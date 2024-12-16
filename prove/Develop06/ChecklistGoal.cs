public class ChecklistGoal : Goal
{
    private int targetCompletions;
    private int currentCompletions;

    public ChecklistGoal(string name, string description, int points, int target) : base(name, description, points)
    {
        targetCompletions = target;
        currentCompletions = 0;
    }

    public override bool IsComplete()
    {
        return currentCompletions >= targetCompletions;
    }

    public override void RecordCompletion()
    {
        currentCompletions++;
    }
}