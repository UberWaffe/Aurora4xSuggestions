using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddInsInterfacing.ExpandedCivilianCompanies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsInterfacing.ExpandedCivilianCompanies.Interface
{
    public interface ITradeRoute
    {
        List<TradePriorityEnum> GetTrades();

        bool ShipDesignValidForRoute(ShipClassDesign shipDesignToCheck);
    }
}
