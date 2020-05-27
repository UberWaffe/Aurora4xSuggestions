using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.AddIns.Tests.TestHelpers;
using System.Linq;
using System.Collections.Generic;
using Moq;

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
        public void Company_WithSufficientWealthAndLackingShip_Should_PurchaseNewShip()
        {
            Assert.Fail();
        }
    }
}
