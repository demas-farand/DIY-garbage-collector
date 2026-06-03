namespace CustomGarbageCollector.Core;

public interface IMemoryEntity
{
    string Id { get; }
    double Mass { get; } 
    bool IsGarbage { get; }
    
    void MarkAsGarbage();
}