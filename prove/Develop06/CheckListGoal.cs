public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override void RecordEvent()
    {
        CurrentCount++;
    }

    public override string GetDetailsString()
    {
        return $"{Name} - Completed {CurrentCount}/{TargetCount} times - {Points} points each time, {BonusPoints} bonus points on completion";
    }
}
