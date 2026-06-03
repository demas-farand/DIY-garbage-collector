using System;
using CustomGarbageCollector.Models;
using CustomGarbageCollector.Services;

namespace CustomGarbageCollector.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly BlackHoleService _blackHoleService;

    public MainWindowViewModel()
    {
        _blackHoleService = new BlackHoleService();
        
        RunCosmicSimulation();
    }

    private void RunCosmicSimulation()
    {
        Console.WriteLine("\nSTARTING BLACK HOLE GC SIMULATION");
        
        var earth = new DataPlanet("Earth", 1000);
        var mars = new DataPlanet("Mars", 800);
        // var spaceDust =
        // var alienShip =
        
        _blackHoleService.SpawnObject(earth);
        _blackHoleService.SpawnObject(mars);
        // _blackHoleService.SpawnObject(spaceDust);
        // _blackHoleService.SpawnObject(alienShip);
        
        _blackHoleService.PrintUniverseStatus();

        Console.WriteLine("\n[Simulation] Releasing references from Earth and Space Dust...");
        earth.MarkAsGarbage();
        // spaceDust.MarkAsGarbage();
        _blackHoleService.SuckGarbage();
        
        _blackHoleService.PrintUniverseStatus();
        Console.WriteLine("SIMULATION COMPLETE\n");
    }
}