using Aurora.AddIns.TerraformingTargets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.TerraformingTargets.Interfaces
{
    public interface ITerraformingManager
    {
        TerraformChangeResult CalculateSingleElementChange(double targetAmount, double currentAmount, double maxChangePossible);
        TerraformMutipleAdjustmentResult AdjustMultipleElements(TerraformElementsSet currentElements, TerraformElementsSet targets, double maxChangePossible);
        OrbitBodyWithTerraformInfo ProcessOrbitBody(OrbitBodyWithTerraformInfo target, long deltaTimeInSeconds);
        List<OrbitBodyWithTerraformInfo> ProcessAll(List<OrbitBodyWithTerraformInfo> allTargets, long deltaTimeInSeconds);
    }
}
