namespace CustomGarbageCollector.Models;

public interface IMemoryEntity
{
    string Id { get; }
    double Mass { get; } 
    bool IsGarbage { get; }

    void MarkAsGarbage();
}