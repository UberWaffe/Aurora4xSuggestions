using Aurora.AddInsInterfacing.TerraformingTargets.Interfaces;

namespace Aurora.AddIns.TerraformingTargets
{
    /// <summary>
    /// Fake interface class. Should interface with proper Aurora 4x C# global gamestate data.
    /// </summary>
    public class PopulationTerraformingCapacityGetter : IPopulationTerraformCapacity
    {
        public double ValueToReturnForPerAnnumTerraformCapacity = 0.0;

        public double GetTotalTerraformingDeltaForPopulation(int populationId, long secondsSinceLastCalc)
        {
            var deltaAdjustedToTime = ValueToReturnForPerAnnumTerraformCapacity;
            deltaAdjustedToTime /= 365;
            deltaAdjustedToTime /= 24;
            deltaAdjustedToTime *= secondsSinceLastCalc; // Multiply first, to avoid really small floating point calculation errors.
            deltaAdjustedToTime /= 3600;
            return deltaAdjustedToTime;
        }
    }
}