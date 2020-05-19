using System.Collections.Generic;
using Aurora.AddIns.TerraformingTargets.Interfaces;
using Aurora.AddIns.TerraformingTargets.Models;

namespace Aurora.AddIns.TerraformingTargets
{
    /// <summary>
    /// Fake interface class. Should interface with proper Aurora 4x C# global gamestate data.
    /// </summary>
    public class OrbitBodyTerraformDataHandler : IOrbitBodyTerraformDataHandler
    {
        public List<OrbitBodyWithTerraformInfo> CurrentPopulationTerraformTargets;
        public List<OrbitBodyWithCurrentElementInfo> CurrentPlanetGasValues;
        public long SecondsSinceLastProcessToSimulate = 3600 * 24 * 5;

        public OrbitBodyTerraformDataHandler()
        {
            CurrentPopulationTerraformTargets = new List<OrbitBodyWithTerraformInfo>();
            CurrentPlanetGasValues = new List<OrbitBodyWithCurrentElementInfo>();
        }

        public List<OrbitBodyWithCurrentElementInfo> GetAllOrbitBodiesCurrentElementsInfo()
        {
            return CurrentPlanetGasValues;
        }

        public List<OrbitBodyWithTerraformInfo> GetAllPopulationsTerraformInfo()
        {
            return CurrentPopulationTerraformTargets;
        }

        public long GetDeltaTimeSinceLastGameUpdate()
        {
            return SecondsSinceLastProcessToSimulate;
        }

        public void SetAllOrbitBodiesCurrentElementsInfo(List<OrbitBodyWithCurrentElementInfo> newValues)
        {
            CurrentPlanetGasValues = newValues;
        }

        public void SetAllPopulationsTerraformInfo(List<OrbitBodyWithTerraformInfo> newValues)
        {
            CurrentPopulationTerraformTargets = newValues;
        }
    }
}