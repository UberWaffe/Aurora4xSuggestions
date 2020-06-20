using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddInsInterfacing.ExpandedCivilianCompanies.Interface;
using Aurora.AddInsInterfacing.ExpandedCivilianCompanies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddIns.ExpandedCivilianCompanies
{
    public class TradeRoute : ITradeRoute
    {
        private Dictionary<TradePriorityEnum, Func<ShipClassDesign, bool>> _tradeTypeChecksDictionary;



        public TradeRoute()
        {
            _tradeTypeChecksDictionary = new Dictionary<TradePriorityEnum, Func<ShipClassDesign, bool>>();
            _tradeTypeChecksDictionary.Add(TradePriorityEnum.PlanetaryInstallations, new Func<ShipClassDesign, bool>(input => CheckShipCanTradeCargo(input)));
            _tradeTypeChecksDictionary.Add(TradePriorityEnum.TNMinerals, new Func<ShipClassDesign, bool>(input => CheckShipCanTradeCargo(input)));
            _tradeTypeChecksDictionary.Add(TradePriorityEnum.Colonists, new Func<ShipClassDesign, bool>(input => CheckShipCanTradeColonists(input)));
            _tradeTypeChecksDictionary.Add(TradePriorityEnum.Fuel, new Func<ShipClassDesign, bool>(input => CheckShipCanTradeFuel(input)));
            _tradeTypeChecksDictionary.Add(TradePriorityEnum.MaintenanceSupply, new Func<ShipClassDesign, bool>(input => CheckShipCanTradeMaintenanceSupplies(input)));
            _tradeTypeChecksDictionary.Add(TradePriorityEnum.SNGoodsAndResources, new Func<ShipClassDesign, bool>(input => CheckShipCanTradeCargo(input)));
        }


        public List<TradePriorityEnum> GetTrades()
        {
            return new List<TradePriorityEnum>()
            {
                TradePriorityEnum.PlanetaryInstallations,
                TradePriorityEnum.TNMinerals,
                TradePriorityEnum.Colonists,
                TradePriorityEnum.Fuel,
                TradePriorityEnum.MaintenanceSupply,
                TradePriorityEnum.SNGoodsAndResources
            };
        }

        public bool ShipDesignValidForRoute(ShipClassDesign shipDesignToCheck)
        {
            var isValid = false;

            foreach (var tradeType in this.GetTrades())
            {
                isValid = this.ShipDesignValidForRoute(shipDesignToCheck, tradeType);
                if (isValid)
                {
                    break;
                }
            }

            return isValid;
        }

        private bool ShipDesignValidForRoute(ShipClassDesign shipDesignToCheck, TradePriorityEnum tradeTypeToCheck)
        {
            var isValid = false;

            return isValid;
        }

        private bool CheckShipCanTradeCargo(ShipClassDesign shipDesignToCheck)
        {
            var isValid = false;

            return isValid;
        }

        public static bool CheckShipCanTradeColonists(ShipClassDesign shipDesignToCheck)
        {
            throw new NotImplementedException();
        }

        public static bool CheckShipCanTradeFuel(ShipClassDesign shipDesignToCheck)
        {
            throw new NotImplementedException();
        }

        public static bool CheckShipCanTradeMaintenanceSupplies(ShipClassDesign shipDesignToCheck)
        {
            throw new NotImplementedException();
        }
    }
}
