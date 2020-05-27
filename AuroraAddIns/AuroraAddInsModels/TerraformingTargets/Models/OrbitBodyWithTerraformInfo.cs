using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsInterfacing.TerraformingTargets.Models
{
    public class OrbitBodyWithTerraformInfo
    {
        public int OrbitBodyId { get; set; }
        public int PopulationId { get; set; }
        public TerraformElementsSet DesiredTargets { get; set; }


        public OrbitBodyWithTerraformInfo(int bodyId, int popId) : this()
        {
            OrbitBodyId = bodyId;
            PopulationId = popId;
        }

        public OrbitBodyWithTerraformInfo()
        {
            DesiredTargets = new TerraformElementsSet();
        }
    }
}
