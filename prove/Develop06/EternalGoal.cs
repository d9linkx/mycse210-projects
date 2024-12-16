public class EternalGoal : BaseGoal
{
    private int _pointsPerRecording;

    public EternalGoal(string name, int pointsPerRecording) : base(name)
    {
        _pointsPerRecording = pointsPerRecording;
    }

    public override void RecordGoal()
    {
        if (!IsComplete)
        {
            Points += _pointsPerRecording;
        }
    }

    public override string GetGoalDetails()
    {
        return $"{Name} [ ] Points: {Points}";
    }
}
