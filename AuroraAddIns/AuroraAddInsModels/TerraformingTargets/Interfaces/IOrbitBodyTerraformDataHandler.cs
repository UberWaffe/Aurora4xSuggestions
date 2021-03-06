﻿using Aurora.AddInsInterfacing.TerraformingTargets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsInterfacing.TerraformingTargets.Interfaces
{
    public interface IOrbitBodyTerraformDataHandler
    {
        List<OrbitBodyWithTerraformInfo> GetAllPopulationsTerraformInfo();
        List<OrbitBodyWithCurrentElementInfo> GetAllOrbitBodiesCurrentElementsInfo();

        void SetAllPopulationsTerraformInfo(List<OrbitBodyWithTerraformInfo> newValues);
        void SetAllOrbitBodiesCurrentElementsInfo(List<OrbitBodyWithCurrentElementInfo> newValues);

        long GetDeltaTimeSinceLastGameUpdate();
    }
}
