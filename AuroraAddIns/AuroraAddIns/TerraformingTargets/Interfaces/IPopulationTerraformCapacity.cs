using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.TerraformingTargets.Interfaces
{
    public interface IPopulationTerraformCapacity
    {
        double GetTotalTerraformingDeltaForPopulation(int populationId, long secondsSinceLastCalc);
    }
}
