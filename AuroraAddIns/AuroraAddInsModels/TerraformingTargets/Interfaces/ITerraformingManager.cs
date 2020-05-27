using Aurora.AddInsInterfacing.TerraformingTargets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsInterfacing.TerraformingTargets.Interfaces
{
    public interface ITerraformingManager
    {
        TerraformChangeResult CalculateSingleElementChange(double targetAmount, double currentAmount, double maxChangePossible);
        TerraformMutipleAdjustmentResult AdjustMultipleElements(TerraformElementsSet currentElements, TerraformElementsSet targets, double maxChangePossible);
        ProcessedTerraformingResult ProcessOrbitBody(OrbitBodyWithTerraformInfo target, OrbitBodyWithCurrentElementInfo currentElements, long deltaTimeInSeconds);
        ProcessedTerraformingListResult ProcessAll(List<OrbitBodyWithTerraformInfo> allTargets, List<OrbitBodyWithCurrentElementInfo> allCurrentElements, long deltaTimeInSeconds);
    }
}
