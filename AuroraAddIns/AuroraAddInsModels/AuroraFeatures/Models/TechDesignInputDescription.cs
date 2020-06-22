using Aurora.AddInsInterfacing.AuroraFeatures.Enums;
using System;

namespace Aurora.AddInsInterfacing.AuroraFeatures.Models
{
    public class TechDesignInputDescription
    {
        public DesignInputTypeEnum Type { get; set; }
        public string InternalName { get; set; }
        public string Description { get; set; }
        public Func<object, bool> IsEnabled { get; set; }
        public Func<object, object> AllowedValues { get; set; }
        public Func<object, object> OnValueChanged { get; set; }
        public Func<object, object> PreCompleteDesign { get; set; }
        public Func<object, string> TooltipInfo { get; set; }
    }
}
