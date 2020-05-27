using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.AddInsInterfacing.TerraformingTargets.Interfaces;
using Aurora.AddInsInterfacing.TerraformingTargets.Models;

namespace Aurora.AddInsPersist.TerraformingTargets
{
    public class TerraformingTargetsEF : ITerraformingTargetsPersist
    {
        public List<OrbitBodyWithTerraformInfo> Load(int gameId)
        {
            throw new NotImplementedException();
        }

        public bool Save(List<OrbitBodyWithTerraformInfo> allGameTerraformTargets, int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
