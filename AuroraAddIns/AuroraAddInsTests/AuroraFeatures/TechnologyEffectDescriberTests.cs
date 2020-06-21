using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.AddIns.Tests.TestHelpers;
using System.Linq;
using System.Collections.Generic;
using Moq;
using Aurora.AddIns.AuroraFeatures;
using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddInsInterfacing.AuroraCore.Enums;
using Aurora.AddInsInterfacing.AuroraFeatures.Enums;

namespace Aurora.AddIns.Tests.FlexibleComponentDesign
{
    [TestClass]
    public class TechnologyEffectDescriberTests
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void TechnologyEffectDescriber_WhenDescribing_Should_ReturnEmptyListWhenUnknownTechType()
        {
            var fakeTech = new TechObject();
            var description = TechnologyEffectDescriber.GetDescriptionList(fakeTech);

            Assert.IsFalse(description.Any());
        }

        [TestMethod]
        public void TechnologyEffectDescriber_WhenDescribing_Should_ReturnCorrectDescriptionFor_EnginePower()
        {
            var testTech = new TechObject()
            {
                TechType = AuroraTechTypes.EnginePower,
                AdditionalInfo = 500.0
            };
            var description = TechnologyEffectDescriber.GetDescriptionList(testTech);

            Assert.AreEqual(TechEffectEnum.EnginePowerPerHs, description[0].EffectType);
            Assert.AreEqual("500.0 Engine Power per HS of Engine Size", description[0].Description);
        }
    }
}
