namespace CustomGarbageCollector.Models;

public abstract class SpaceObject : IMemoryEntity
{
    public string Id { get; protected set; } = string.Empty;
    public double Mass { get; protected set; }
    public bool IsGarbage { get; protected set; }

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