using Aurora.AddInsInterfacing.TerraformingTargets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsInterfacing.TerraformingTargets.Interfaces
{
    public interface ITerraformingTargetsPersist
    {
        bool Save(List<OrbitBodyWithTerraformInfo> allGameTerraformTargets, int gameId);

        List<OrbitBodyWithTerraformInfo> Load(int gameId);
    }
}
