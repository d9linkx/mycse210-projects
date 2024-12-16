public abstract class BaseGoal
{
    public string Name { get; set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    public BaseGoal(string name)
    {
        Name = name;
        Points = 0;
        IsComplete = false;
    }

    public abstract void RecordGoal();
    public abstract string GetGoalDetails();

    public void CompleteGoal()
    {
        IsComplete = true;
    }
}
