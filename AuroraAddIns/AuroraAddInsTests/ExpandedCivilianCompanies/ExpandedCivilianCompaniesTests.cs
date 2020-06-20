using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.AddIns.Tests.TestHelpers;
using System.Linq;
using System.Collections.Generic;
using Moq;
using Aurora.AddInsInterfacing.ExpandedCivilianCompanies.Models;
using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddIns.ExpandedCivilianCompanies;

namespace Aurora.AddIns.Tests.ExpandedCivilianCompanies
{
    [TestClass]
    public class ExpandedCivilianCompaniesTests
    {
        private DiceRoller _dice;

        [TestInitialize]
        public void Initialize()
        {
            _dice = new DiceRoller();
        }

        [TestMethod]
        public void TradeRoute_ShouldBeAbleTo_Give_ListOfTradePriorities()
        {
            var tradeRoute = new TradeRoute();
            var tradePriorities = tradeRoute.GetTrades();

            Assert.AreEqual(TradePriorityEnum.PlanetaryInstallations, tradePriorities[0]);
            Assert.AreEqual(TradePriorityEnum.TNMinerals, tradePriorities[1]);
            Assert.AreEqual(TradePriorityEnum.Colonists, tradePriorities[2]);
            Assert.AreEqual(TradePriorityEnum.Fuel, tradePriorities[3]);
            Assert.AreEqual(TradePriorityEnum.MaintenanceSupply, tradePriorities[4]);
            Assert.AreEqual(TradePriorityEnum.SNGoodsAndResources, tradePriorities[5]);
        }

        [TestMethod]
        public void TradeRoute_WhenCheckingShipValidForJoiningRoute_Should_RespondYesIfShipDesignMeetsAllCriteria()
        {
            var tradeRoute = new TradeRoute();
            var shipDesignToCheck = new ShipClassDesign();
            var shipIsValid = tradeRoute.ShipDesignValidForRoute(shipDesignToCheck);

            Assert.IsTrue(shipIsValid);
        }

        [TestMethod]
        public void Company_WithSufficientWealthAndLackingShip_Should_PurchaseNewShip()
        {
            Assert.Fail();
        }
    }
}
