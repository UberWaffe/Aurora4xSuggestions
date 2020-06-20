using Aurora.AddInsInterfacing.AuroraCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsInterfacing.AuroraFeatures.Models
{
    public class ResearchPrerequisites
    {
        public long Id { get; set; }
        public List<TechObject> Prerequisites { get; set; }


        public ResearchPrerequisites()
        {
            this.Prerequisites = new List<TechObject>();
        }
    }
}
