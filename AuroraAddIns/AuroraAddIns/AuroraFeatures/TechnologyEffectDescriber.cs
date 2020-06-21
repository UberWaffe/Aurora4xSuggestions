using Aurora.AddInsInterfacing.AuroraCore.Enums;
using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddInsInterfacing.AuroraFeatures.Enums;
using Aurora.AddInsInterfacing.AuroraFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddIns.AuroraFeatures
{
    public static class TechnologyEffectDescriber
    {
        private static Dictionary<AuroraTechTypes, Func<TechObject, List<TechEffectDescription>>> _describerFunctions = new Dictionary<AuroraTechTypes, Func<TechObject, List<TechEffectDescription>>>()
        {
            { AuroraTechTypes.EnginePower, new Func<TechObject, List<TechEffectDescription>>(input => DescribeEnginePower(input)) }
        };

        private static Dictionary<TechEffectEnum, string> _effectDescriptions = new Dictionary<TechEffectEnum, string>()
        {
            { TechEffectEnum.EnginePowerPerHs, "{0:0.0} Engine Power per HS of Engine Size" }
        };

        public static List<TechEffectDescription> GetDescriptionList(TechObject techToDescribeEffectsOf)
        {
            var techType = techToDescribeEffectsOf.TechType;
            if (TechnologyEffectDescriber._describerFunctions.ContainsKey(techType) == false)
            {
                return new List<TechEffectDescription>();
            }

            var describer = TechnologyEffectDescriber._describerFunctions[techType];
            return describer(techToDescribeEffectsOf);
        }

        private static List<TechEffectDescription> DescribeEnginePower(TechObject theTech)
        {
            var result = new List<TechEffectDescription>();

            var entry1 = new TechEffectDescription()
            {
                EffectType = TechEffectEnum.EnginePowerPerHs,
                Description = string.Format(_effectDescriptions[TechEffectEnum.EnginePowerPerHs], theTech.AdditionalInfo)
            };
            result.Add(entry1);

            return result;
        }

    }
}
