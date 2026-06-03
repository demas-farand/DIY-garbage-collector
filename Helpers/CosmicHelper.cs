using System;

namespace CustomGarbageCollector.Helpers;

public static class CosmicHelper
{
    public static string GenerateUniqueId(string prefix)
    {
        return $"{prefix}_{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";
    }

    public static double CalculateDisturbance(double totalGarbageMass)
    {
        return totalGarbageMass * 1.5; 
    }
    
}