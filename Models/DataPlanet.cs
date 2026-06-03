using System;
using CustomGarbageCollector.Helpers;

namespace CustomGarbageCollector.Models;

public class DataPlanet : SpaceObject
{
    public string Name { get; private set; }

    public DataPlanet(string name, double mass) : base(mass)
    {
        Name = name;
        Id = CosmicHelper.GenerateUniqueId("PLNT");
        Size = 40;
        ColorHex = "#3498DB";
    }

    public override void MarkAsGarbage()
    {
        base.MarkAsGarbage();
        Console.WriteLine($"Planet Data '{Name}' (ID: {Id}).");
    }
}