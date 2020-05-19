using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.TerraformingTargets.Models
{
    public class OrbitBodyWithCurrentElementInfo
    {
        public int OrbitBodyId { get; set; }
        public TerraformElementsSet CurrentElements { get; set; }


        public OrbitBodyWithCurrentElementInfo(int bodyId) : this()
        {
            OrbitBodyId = bodyId;
        }

        public OrbitBodyWithCurrentElementInfo()
        {
            CurrentElements = new TerraformElementsSet();
        }
    }
}
