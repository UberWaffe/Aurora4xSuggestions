using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddInsInterfacing.AuroraFeatures.Interfaces;
using Aurora.AddInsInterfacing.AuroraFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddIns.AuroraFeatures
{
    public class ResearchPrerequisitesWorker : ResearchPrerequisites, IResearchPrerequisites
    {
        public ResearchPrerequisitesWorker() : base()
        {

        }

        public void AddPrerequisite(TechObject techToAddAsPrerequisite)
        {
            if (this.Prerequisites.Any(reqTech => reqTech.TechSystemID == techToAddAsPrerequisite.TechSystemID) == false)
            {
                this.Prerequisites.Add(techToAddAsPrerequisite);
            }
        }

        public void AddPrerequisites(List<TechObject> techListToAddAsPrerequisite)
        {
            foreach (var newPrerequisite in techListToAddAsPrerequisite)
            {
                this.AddPrerequisite(newPrerequisite);
            }
        }

        public bool IsFulfilledBy(Dictionary<int, TechObject> availableTechs)
        {
            foreach (var prerequisite in this.Prerequisites)
            {
                if (prerequisite.TechSystemID.HasValue == false)
                {
                    throw new ArgumentException($"ResearchPrerequisitesWorker.IsFulfilledBy cannot have a prerequisite that is null. Was given {prerequisite.Name}");
                }

                var idToCheck = prerequisite.TechSystemID.Value;
                if (availableTechs.ContainsKey(idToCheck) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
