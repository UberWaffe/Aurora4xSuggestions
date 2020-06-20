using Aurora.AddInsInterfacing.AuroraCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsInterfacing.AuroraFeatures.Interfaces
{
    public interface IResearchPrerequisites
    {
        bool IsFulfilledBy(Dictionary<int, TechObject> availableTechs);

        void AddPrerequisite(TechObject techToAddAsPrerequisite);

        void AddPrerequisites(List<TechObject> techListToAddAsPrerequisite);
    }
}
