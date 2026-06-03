using System;

namespace CustomGarbageCollector.Core;

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