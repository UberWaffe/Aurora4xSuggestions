using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsInterfacing.AuroraCore.Models
{
    public class ShipClassComponent
    {
	    public long GameID { get; set; }
        public ShipClassDesign ShipClass { get; set; }
        public ShipComponent TheComponent { get; set; }
        public double? NumberOfTheComponent { get; set; }
        public long ChanceToHit { get; set; }
        public long ElectronicCTH { get; set; }

        public ShipClassComponent()
        {
            this.NumberOfTheComponent = null;
        }
    }
}
