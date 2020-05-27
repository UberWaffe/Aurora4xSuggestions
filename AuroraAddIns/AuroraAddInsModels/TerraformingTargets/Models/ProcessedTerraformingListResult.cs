using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsInterfacing.TerraformingTargets.Models
{
    public class ProcessedTerraformingListResult
    {
        public List<OrbitBodyWithTerraformInfo> newTargets;
        public List<OrbitBodyWithCurrentElementInfo> newValues;
    }
}
