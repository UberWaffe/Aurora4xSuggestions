using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsInterfacing.AuroraCore.Models
{
    public class ShipComponentEx
    {
	    public long Id { get; set; }
	    public string Name { get; set; }
        public PurchaseCostSet Cost { get; set; }

        public ShipComponentEx()
        {
            this.Cost = new PurchaseCostSet();
        }
    }
}
