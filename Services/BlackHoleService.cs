using System;
using System.Collections.Generic;
using System.Linq;
using CustomGarbageCollector.Models;
using CustomGarbageCollector.Helpers;

namespace CustomGarbageCollector.Services;

public class BlackHoleService
{
    private List<IMemoryEntity> _universeMemory;

    public BlackHoleService()
    {
        _universeMemory = new List<IMemoryEntity>();
    }

    public void SpawnObject(IMemoryEntity spaceObject)
    {
        _universeMemory.Add(spaceObject);
        Console.WriteLine($"[Spawn] Space object {spaceObject.Id} spawned with mass {spaceObject.Mass}");
    }

    public void SuckGarbage()
    {
        Console.WriteLine("\n[Black Hole] Event Horizon started!");

        var garbage = _universeMemory.Where(obj => obj.IsGarbage).ToList();
        
        if (garbage.Count == 0)
        {
            // Console.WriteLine("[Black Hole] --- ");
            return;
        }

        double totalGarbageMass = 0;

        foreach (var item in garbage)
        {
            totalGarbageMass += item.Mass;
            _universeMemory.Remove(item);
            Console.WriteLine($"[Black Hole] ABSORBEB: {item.Id} (Mass: {item.Mass})");
        }

        double disturbance = CosmicHelper.CalculateDisturbance(totalGarbageMass);
        
        Console.WriteLine($"[Black Hole] Garbage collection completed. Total reclaimed memory mass: {totalGarbageMass}.");
        Console.WriteLine($"[Singularity] Current singularity distortion level: {disturbance}\n");
    }
    
    public void PrintUniverseStatus()
    {
        Console.WriteLine($"[Status Memori] Active referenced objects: {_universeMemory.Count}");
    }
}