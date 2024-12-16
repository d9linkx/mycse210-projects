public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PointsPerCompletion { get; set; }

    public abstract bool IsComplete();
    public abstract void RecordCompletion();
}