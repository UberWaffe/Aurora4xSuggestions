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
using Aurora.AddInsInterfacing.AuroraFeatures.Models;

namespace Aurora.AddIns.Tests.FlexibleComponentDesign
{
    [TestClass]
    public class ShipComponentDescriberTests
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void ShipComponentDescriber_WhenDescribingAnEngine_Should_ReturnCorrectDescriptionOfInputs()
        {
            var componentType = ShipComponentTypesEnum.Engine;
            var designInputs = ShipComponentDescriber.GetDesignInputs(componentType);

            var pos = 0;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, TechDesignInternalEnum.IsMilitary, "Military or Commercial design");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Number, TechDesignInternalEnum.SizeInHS, "Component Size");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Tech, TechDesignInternalEnum.EnginePower, "Engine Power");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, TechDesignInternalEnum.EnginePowerMod, "Engine Power Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Tech, TechDesignInternalEnum.FuelUse, "Fuel Efficiency");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, TechDesignInternalEnum.FuelUseMod, "Fuel Efficiency Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Tech, TechDesignInternalEnum.ThermalReduction, "Thermal Reduction");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, TechDesignInternalEnum.ThermalReductionMod, "Thermal Reduction Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, TechDesignInternalEnum.CostMineralsMod, "Manufacture TN Cost Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, TechDesignInternalEnum.CostEffortMod, "Manufacture BP Cost Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, TechDesignInternalEnum.MspOnBreakMod, "Maintenance MSP Cost Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, TechDesignInternalEnum.CrewNeededMod, "Crew Requirement Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, TechDesignInternalEnum.ResearchCostMod, "Research Cost Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, TechDesignInternalEnum.BreakdownChangeOnActiveUse, "Active use Breakdown Chance");
        }

        private void ShipComponentDescriber_TestDesignInputs(TechDesignInputDescription inputDesc, DesignInputTypeEnum expectedType, TechDesignInternalEnum expectedInternal, string expectedDesc)
        {
            Assert.AreEqual(expectedType, inputDesc.Type);
            Assert.AreEqual(expectedInternal, inputDesc.InternalName);
            Assert.AreEqual(expectedDesc, inputDesc.Description);
            Assert.IsNotNull(inputDesc.IsEnabled);
            Assert.IsNotNull(inputDesc.AllowedValues);
            Assert.IsNotNull(inputDesc.OnValueChanged);
            Assert.IsNotNull(inputDesc.PreCompleteDesign);
            Assert.IsNotNull(inputDesc.TooltipInfo);
        }
    }
}
