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
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, "IsMilitary", "Military or Commercial design");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Number, "SizeInHS", "Component Size");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Tech, "EnginePower", "Engine Power");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, "EnginePowerMod", "Engine Power Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Tech, "FuelUse", "Fuel Efficiency");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, "FuelUseMod", "Fuel Efficiency Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Tech, "ThermalReduction", "Thermal Reduction");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, "ThermalReductionMod", "Thermal Reduction Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, "CostMineralsMod", "Manufacture TN Cost Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, "CostEffortMod", "Manufacture BP Cost Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, "MspOnBreakMod", "Maintenance MSP Cost Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, "CrewNeededMod", "Crew Requirement Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, "ResearchCostMod", "Research Cost Modifier");

            pos++;
            ShipComponentDescriber_TestDesignInputs(designInputs[pos], DesignInputTypeEnum.Choice, "", "");
        }

        private void ShipComponentDescriber_TestDesignInputs(TechDesignInputDescription inputDesc, DesignInputTypeEnum expectedType, string expectedName, string expectedDesc)
        {
            Assert.AreEqual(expectedType, inputDesc.Type);
            Assert.AreEqual(expectedName, inputDesc.InternalName);
            Assert.AreEqual(expectedDesc, inputDesc.Description);
            Assert.IsNotNull(inputDesc.IsEnabled);
            Assert.IsNotNull(inputDesc.AllowedValues);
            Assert.IsNotNull(inputDesc.OnValueChanged);
            Assert.IsNotNull(inputDesc.PreCompleteDesign);
            Assert.IsNotNull(inputDesc.TooltipInfo);
        }
    }
}
