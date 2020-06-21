using Aurora.AddIns.AuroraFeatures;
using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddInsInterfacing.AuroraFeatures.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraUIMockup.Helpers
{
    public static class TechAnalyzerHelper
    {
        private static Dictionary<TechEffectEnum, string> _effectSummary = new Dictionary<TechEffectEnum, string>()
        {
            { TechEffectEnum.EnginePowerPerHs, "+Engine Power" }
        };

        public static List<string> EffectsOfTheTech(TechObject theTechToAnalyse)
        {
            var effectList = TechnologyEffectDescriber.GetDescriptionList(theTechToAnalyse);

            var effects = new List<string>();
            foreach (var effectDescription in effectList)
            {
                var effectSummary = "";
                if (_effectSummary.ContainsKey(effectDescription.EffectType))
                {
                    effectSummary = _effectSummary[effectDescription.EffectType];
                }

                effects.Add($"{effectSummary} : {effectDescription.Description}");
            }

            return effects;
        }
    }
}
