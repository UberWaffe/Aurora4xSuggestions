using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.AddIns.TerraformingTargets.Models;

namespace Aurora.AddIns.Persist.TerraformingTargets
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
