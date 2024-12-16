public class ChecklistGoal : BaseGoal
{
    private int _targetCompletions;
    private int _pointsPerCompletion;
    private int _bonusPoints;

    private int _currentCompletions;

    public ChecklistGoal(string name, int targetCompletions, int pointsPerCompletion, int bonusPoints) : base(name)
    {
        _targetCompletions = targetCompletions;
        _pointsPerCompletion = pointsPerCompletion;
        _bonusPoints = bonusPoints;
        _currentCompletions = 0;
    }

    public override void RecordGoal()
    {
        if (!IsComplete)
        {
            _currentCompletions++;
            Points += _pointsPerCompletion;

            if (_currentCompletions >= _targetCompletions)
            {
                Points += _bonusPoints;
                CompleteGoal();
            }
        }
    }

    public override string GetGoalDetails()
    {
        return $"{Name} [{(IsComplete ? "X" : " ")}] Completed {_currentCompletions}/{_targetCompletions} times. Points: {Points}";
    }
}
