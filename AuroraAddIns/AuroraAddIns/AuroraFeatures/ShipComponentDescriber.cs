using Aurora.AddInsInterfacing.AuroraFeatures.Enums;
using Aurora.AddInsInterfacing.AuroraFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddIns.AuroraFeatures
{
    public static class ShipComponentDescriber
    {
        private static Dictionary<ShipComponentTypesEnum, Func<List<TechDesignInputDescription>>> _describerFunctions = new Dictionary<ShipComponentTypesEnum, Func<List<TechDesignInputDescription>>>()
        {
            { ShipComponentTypesEnum.Engine, new Func<List<TechDesignInputDescription>>(() => DescribeInputsForEngine()) }
        };


        public static List<TechDesignInputDescription> GetDesignInputs(ShipComponentTypesEnum componentType)
        {
            if (_describerFunctions.ContainsKey(componentType) == false)
            {
                return null;
            }

            var functionToCall = _describerFunctions[componentType];
            return functionToCall();
        }


        public static List<TechDesignInputDescription> DescribeInputsForEngine()
        {
            var result = new List<TechDesignInputDescription>();



            return result;
        }
    }
}
