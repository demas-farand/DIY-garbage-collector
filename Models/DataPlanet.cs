using System;

namespace CustomGarbageCollector.Core;

public class DataPlanet : SpaceObject
{
    public string Name { get; private set; }

    public DataPlanet(string name, double mass) : base(mass)
    {
        Name = name;
        Id = CosmicHelper.GenerateUniqueId("PLNT");
    }

    public override void MarkAsGarbage()
    {
        base.MarkAsGarbage();
        // Console.WriteLine($"Planet Data '{Name}' (ID: {Id}).");
    }
}