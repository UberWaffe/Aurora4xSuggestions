using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.ExtraGameManipulation
{
    public static class ExtraGameManipulationConstants
    {
        public static Dictionary<int, int> TechCostForTechLevel = new Dictionary<int, int>()
        {
            { 1, 150 },
            { 2, 600 },
            { 3, 1200 },
            { 4, 2400 },
            { 5, 3600 },
            { 6, 6000 },
            { 7, 12000 },
            { 8, 24000 },
            { 9, 45000 },
            { 10, 90000 },
            { 11, 180000 },
            { 12, 375000 },
            { 13, 750000 },
            { 14, 1500000 },
            { 15, 2000000 },
            { 16, 3000000 },
            { 17, 4500000 },
            { 18, 6750000 },
            { 19, 10000000 },
            { 20, 15000000 },
            { 21, 22500000 },
            { 22, 33750000 },
            { 23, 50000000 },
            { 24, 75000000 },
            { 25, 112000000 },
            { 26, 168000000 },
            { 27, 252000000 },
            { 28, 380000000 },
            { 29, 570000000 },
            { 30, 855000000 },
            { 31, 1280000000 },
            { 32, 1920000000 },
            { 33, 2000000000 }
        };

        public static string TechType_PowerPlantTechnology = "Power Plant Technology";
        public static string TechType_ShieldRegenRate = "Shield Regeneration Rate";
    }
}
