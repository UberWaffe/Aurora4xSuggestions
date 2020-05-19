﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.TerraformingTargets.Models
{
    public class OrbitBodyWithTerraformInfo
    {
        public int OrbitBodyId { get; set; }
        public int PopulationId { get; set; }
        public TerraformElementsSet DesiredTargets { get; set; }
        public TerraformElementsSet CurrentElements { get; set; }


        public OrbitBodyWithTerraformInfo(int id, int popId) : this()
        {
            OrbitBodyId = id;
            PopulationId = popId;
        }

        public OrbitBodyWithTerraformInfo()
        {
            DesiredTargets = new TerraformElementsSet();
            CurrentElements = new TerraformElementsSet();
        }
    }
}
