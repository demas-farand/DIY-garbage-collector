namespace CustomGarbageCollector.Models;

public abstract class SpaceObject : IMemoryEntity
{
    public string Id { get; protected set; } = string.Empty;
    public double Mass { get; protected set; }
    public bool IsGarbage { get; protected set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Size { get; protected set; }
    public string ColorHex { get; protected set; } = "#FFFFFF";

    protected SpaceObject(double mass)
    {
        Mass = mass;
        IsGarbage = false;
    }

    public virtual void MarkAsGarbage()
    {
        IsGarbage = true;
    }
}