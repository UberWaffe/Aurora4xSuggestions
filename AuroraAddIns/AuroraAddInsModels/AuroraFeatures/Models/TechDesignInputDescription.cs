using Aurora.AddInsInterfacing.AuroraFeatures.Enums;
using System;

namespace Aurora.AddInsInterfacing.AuroraFeatures.Models
{
    public class TechDesignInputDescription
    {
        public DesignInputTypeEnum Type { get; set; }
        public TechDesignInternalEnum InternalName { get; set; }
        public string Description { get; set; }
        public Func<object, bool> IsEnabled { get; set; }
        public Func<object, object> AllowedValues { get; set; }
        public Func<object, object> OnValueChanged { get; set; }
        public Func<object, object> PreCompleteDesign { get; set; }
        public Func<object, string> TooltipInfo { get; set; }
    }


    public enum TechDesignInternalEnum
    {
        None = 0,
        IsMilitary,
        SizeInHS,
        EnginePower,
        EnginePowerMod,
        FuelUse,
        FuelUseMod,
        ThermalReduction,
        ThermalReductionMod,
        CostMineralsMod,
        CostEffortMod,
        MspOnBreakMod,
        BreakdownChangeOnActiveUse,
        CrewNeededMod,
        ResearchCostMod,
    }
}
