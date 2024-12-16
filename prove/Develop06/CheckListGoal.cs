public class ChecklistGoal : Goal
{
    private int targetCompletions;
    private int currentCompletions;

    public ChecklistGoal(string name, string description, int points, int targetCompletions) : base(name, description, points)
    {
        this.targetCompletions = targetCompletions;
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