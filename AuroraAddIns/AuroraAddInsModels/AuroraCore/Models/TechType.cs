using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsInterfacing.AuroraCore.Models
{
    public class TechType
    {
        public int TechTypeID { get; set; }
        public string Description { get; set; }
        public int FieldID { get; set; }
        public int DistributeLowerTech { get; set; }
    }
}
