public class SimpleGoal : BaseGoal
{
    private int _pointsPerCompletion;

    public SimpleGoal(string name, int points) : base(name)
    {
        _pointsPerCompletion = points;
    }

    public override void RecordGoal()
    {
        if (!IsComplete)
        {
            Points += _pointsPerCompletion;
            CompleteGoal();
        }
    }

    public override string GetGoalDetails()
    {
        return $"{Name} [{(IsComplete ? "X" : " ")}] Points: {Points}";
    }
}
