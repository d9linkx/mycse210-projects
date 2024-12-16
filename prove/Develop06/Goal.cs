public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PointsPerCompletion { get; set; }

    protected Goal(string name, string description, int pointsPerCompletion)
    {
        Name = name;
        Description = description;
        PointsPerCompletion = pointsPerCompletion;
    }

    public abstract bool IsComplete();
    public abstract void RecordCompletion();
}