using Aurora.AddInsInterfacing.AuroraFeatures.Enums;
using Aurora.AddInsInterfacing.AuroraFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddIns.AuroraFeatures.DesignInputDescriptors
{
    public static class InputDescriberMilitaryOrCommercial
    {
        public static object AllowedValues(object input)
        {
            var result = new Dictionary<int, string>();
            result.Add(0, "Commercial");
            result.Add(1, "Military");

            return result;
        }
    }
}
