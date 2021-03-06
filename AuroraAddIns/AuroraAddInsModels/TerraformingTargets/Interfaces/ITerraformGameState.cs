﻿using Aurora.AddInsInterfacing.TerraformingTargets.Models;
using System.Collections.Generic;

namespace Aurora.AddInsInterfacing.TerraformingTargets.Interfaces
{
    public interface ITerraformGameState
    {
        void DoGameUpdate();
        bool SetTargetFor(int orbitBodyId, int populationId, int elementId, double targetAmount);
        bool DeleteTargetFor(int orbitBodyId, int populationId, int elementId);
        OrbitBodyWithTerraformInfo GetTargetsFor(int orbitBodyId, int populationId);
        List<OrbitBodyWithTerraformInfo> GetTargetsForAll();

        OrbitBodyWithCurrentElementInfo GetCurrentElementsFor(int orbitBodyId);
    }
}