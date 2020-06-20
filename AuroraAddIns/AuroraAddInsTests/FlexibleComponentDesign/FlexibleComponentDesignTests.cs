using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.AddIns.Tests.TestHelpers;
using System.Linq;
using System.Collections.Generic;
using Moq;

namespace Aurora.AddIns.Tests.FlexibleComponentDesign
{
    [TestClass]
    public class FlexibleComponentDesignTests
    {
        private DiceRoller _dice;

        [TestInitialize]
        public void Initialize()
        {
            _dice = new DiceRoller();
        }

        [TestMethod]
        public void PrerequisiteResearch_WhenChecking_Should_ReturnTrueIfAllPrerequisitesMet()
        {


            Assert.Fail();
        }
    }
}
