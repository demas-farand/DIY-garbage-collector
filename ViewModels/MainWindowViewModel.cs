using System;
using System.Collections.ObjectModel;
using System.Linq;
using CustomGarbageCollector.Models;
using CustomGarbageCollector.Services;

namespace CustomGarbageCollector.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly BlackHoleService _blackHoleService;
    private double _distortionLevel;
    public double DistortionLevel
    {
        get => _distortionLevel;
        set => RaiseAndSetIfChanged(ref _distortionLevel, value);
    }

    public ObservableCollection<SpaceObject> SpaceObjects { get; }

    public MainWindowViewModel()
    {
        _blackHoleService = new BlackHoleService();
        SpaceObjects = new ObservableCollection<SpaceObject>();
        DistortionLevel = 0;
    }

    private readonly Random _random = new();

    public void SpawnPlanet()
    {
        var planet = new DataPlanet("Planet", 10)
        {
            X = _random.Next(50, 700),
            Y = _random.Next(50, 350)
        };
        _blackHoleService.SpawnObject(planet);
        SpaceObjects.Add(planet);
        Console.WriteLine($"[UI] Spawned Planet. Total objects: {SpaceObjects.Count}");
    }

    public void SpawnAsteroid()
    {
        var asteroid = new CacheAsteroid(2)
        {
            X = _random.Next(50, 700),
            Y = _random.Next(50, 350)
        };
        _blackHoleService.SpawnObject(asteroid);
        SpaceObjects.Add(asteroid);
        Console.WriteLine($"[UI] Spawned Asteroid. Total objects: {SpaceObjects.Count}");
    }

    public void MarkAsGarbage()
    {
        var activeObject = SpaceObjects.FirstOrDefault(o => !o.IsGarbage);
        if (activeObject != null)
        {
            activeObject.MarkAsGarbage();
            Console.WriteLine($"[UI] Marked {activeObject.Id} as garbage.");
        }
        else
        {
            Console.WriteLine("[UI] No active objects left to mark as garbage.");
        }
    }

    public void ActivateBlackHole()
    {
        _blackHoleService.SuckGarbage();

        var garbageList = SpaceObjects.Where(o => o.IsGarbage).ToList();
        foreach (var garbage in garbageList)
        {
            SpaceObjects.Remove(garbage);
        }

        DistortionLevel += garbageList.Count * 5; 
        
        if (DistortionLevel > 100) DistortionLevel = 100;
        
        Console.WriteLine($"[UI] Sweep complete. Current Distortion: {DistortionLevel}%");
    }
}