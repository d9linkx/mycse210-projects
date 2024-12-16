public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _goalCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int goalCount, int bonusPoints) : base(name, points)
    {
        _goalCount = goalCount;
        _bonusPoints = bonusPoints;
        _timesCompleted = 0;
    }

    public override void RecordProgress()
    {
        if (_timesCompleted < _goalCount)
        {
            _timesCompleted++;
            Points += 50; // Points for each completion
            Console.WriteLine($"You recorded progress for '{Name}'! Total points: {Points}");

            if (_timesCompleted == _goalCount)
            {
                Points += _bonusPoints;
                Console.WriteLine($"Bonus! You completed '{Name}'! You earned {_bonusPoints} extra points!");
            }
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' is already complete.");
        }
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {Name} - Completed {_timesCompleted}/{_goalCount} times - {Points} points");
    }
}
