using Aurora.AddIns.TerraformingTargets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.TerraformingTargets.Interfaces
{
    public interface IOrbitBodyTerraformDataHandler
    {
        List<OrbitBodyWithTerraformInfo> GetAllOrbitBodiesTerraformInfo();

        void SetAllOrbitBodiesTerraformInfo(List<OrbitBodyWithTerraformInfo> newValues);

        long GetDeltaTimeSinceLastGameUpdate();
    }
}
