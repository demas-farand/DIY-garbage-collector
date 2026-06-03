using CustomGarbageCollector.Helpers;

namespace CustomGarbageCollector.Models;

public class CacheAsteroid : SpaceObject
{
    public CacheAsteroid(double mass) : base(mass)
    {
        Id = CosmicHelper.GenerateUniqueId("ASTR");
    }

}