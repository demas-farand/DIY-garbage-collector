using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Avalonia.Threading;
using CustomGarbageCollector.Models;
using CustomGarbageCollector.Services;

namespace CustomGarbageCollector.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly BlackHoleService _blackHoleService;
    private readonly Random _random = new();

    private double _distortionLevel;
    public double DistortionLevel
    {
        get => _distortionLevel;
        set => RaiseAndSetIfChanged(ref _distortionLevel, value);
    }
    private string _graphData = "M 0,30 L 800,30";
    public string GraphData
    {
        get => _graphData;
        set => RaiseAndSetIfChanged(ref _graphData, value);
    }

    public ObservableCollection<SpaceObject> SpaceObjects { get; }

    public MainWindowViewModel()
    {
        _blackHoleService = new BlackHoleService();
        SpaceObjects = new ObservableCollection<SpaceObject>();
        DistortionLevel = 0;
        var timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(150) 
        };
        timer.Tick += (sender, e) => GenerateGraphLine(); 
        timer.Start();
    }
    
    public void SpawnPlanet()
    {
        var planet = new DataPlanet("Planet", 10)
        {
            X = _random.Next(50, 700),
            Y = _random.Next(50, 350)
        };
        _blackHoleService.SpawnObject(planet);
        SpaceObjects.Add(planet);
        
        DistortionLevel += 5;
        if (DistortionLevel > 100) DistortionLevel = 100;

        Console.WriteLine($"[UI] Spawned Planet at X: {planet.X}, Y: {planet.Y}");
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

        DistortionLevel += 5;
        if (DistortionLevel > 100) DistortionLevel = 100;

        Console.WriteLine($"[UI] Spawned Asteroid at X: {asteroid.X}, Y: {asteroid.Y}");
    }

    public void MarkAsGarbage()
    {
        var activeObject = SpaceObjects.FirstOrDefault(o => !o.IsGarbage);
        if (activeObject != null)
        {
            activeObject.MarkAsGarbage();
            Console.WriteLine($"[UI] Marked {activeObject.Id} as garbage.");
        }
    }

    public void ActivateBlackHole()
    {
        _blackHoleService.SuckGarbage();

        var garbageList = SpaceObjects.Where(o => o.IsGarbage).ToList();
        var survivorsList = SpaceObjects.Where(o => !o.IsGarbage).ToList();

        foreach (var garbage in garbageList)
        {
            SpaceObjects.Remove(garbage);
        }

        foreach (var survivor in survivorsList)
        {
            if (survivor.Generation < 2)
            {
                survivor.Generation++;
                Console.WriteLine($"[Generational GC] {survivor.Id} promoted to Gen {survivor.Generation}");
            }
        }

        DistortionLevel -= garbageList.Count * 5; 
        if (DistortionLevel < 0) DistortionLevel = 0;
        
        Console.WriteLine($"[UI] Sweep complete. Current Distortion: {DistortionLevel}%");
    }
    private void GenerateGraphLine()
    {
        var sb = new StringBuilder();
        sb.Append("M 0,30 "); // M = Move To X = 0, Y = 30)

        for (int x = 10; x <= 800; x += 15)
        {
            double y = 30;

            if (DistortionLevel > 0)
            {
                double spike = _random.NextDouble() * (DistortionLevel / 2); 
                
                if (_random.Next(2) == 0) spike = -spike;
                
                y = 30 + spike;

                if (y < 5) y = 5;
                if (y > 55) y = 55;
            }

            sb.Append($"L {x},{y} ");
        }
        GraphData = sb.ToString();
    }
}