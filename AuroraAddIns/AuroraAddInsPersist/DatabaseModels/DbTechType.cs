using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddInsPersist.DatabaseModels
{
    public class DbTechType
    {
        public int TechTypeID { get; set; }
        public string Description { get; set; }
        public int FieldID { get; set; }
        public int DistributeLowerTech { get; set; }
    }
}
