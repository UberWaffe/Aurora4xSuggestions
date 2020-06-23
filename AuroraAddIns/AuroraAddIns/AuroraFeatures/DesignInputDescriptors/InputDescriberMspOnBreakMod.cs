using Aurora.AddInsInterfacing.AuroraFeatures.Enums;
using Aurora.AddInsInterfacing.AuroraFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddIns.AuroraFeatures.DesignInputDescriptors
{
    public static class InputDescriberMspOnBreakMod
    {
        public static TechDesignInputDescription Get()
        {
            var result = new TechDesignInputDescription()
            {
                Type = DesignInputTypeEnum.Choice,
                InternalName = TechDesignInternalEnum.MspOnBreakMod,
                Description = "Maintenance MSP Cost Modifier",
            };
            result.AllowedValues = new Func<object, object>(input => AllowedValues(input));
            result.IsEnabled = new Func<object, bool>(input => IsEnabled(input));
            result.OnValueChanged = new Func<object, object>(input => OnValueChanged(input));
            result.PreCompleteDesign = new Func<object, object>(input => PreCompleteDesign(input));
            result.TooltipInfo = new Func<object, string>(input => TooltipInfo(input));

            return result;
        }

        public static object AllowedValues(object input)
        {
            var result = new Dictionary<int, string>();

            return result;
        }

        public static bool IsEnabled(object input)
        {
            return true;
        }

        public static object OnValueChanged(object input)
        {
            return true;
        }

        public static object PreCompleteDesign(object input)
        {
            return true;
        }

        public static string TooltipInfo(object input)
        {
            return "";
        }
    }
}
