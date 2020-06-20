using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.AddIns.Tests.TestHelpers;
using System.Linq;
using System.Collections.Generic;
using Moq;
using Aurora.AddInsInterfacing.ExtraGameManipulation.Interface;
using Aurora.AddIns.ExtraGameManipulation;
using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddInsPersist.ExtraGameManipulation;
using Aurora.AddIns.Technologies;
using Aurora.AddInsInterfacing.AuroraCore.Models;

namespace Aurora.AddIns.Tests.ExtraGameManipulation
{
    [TestClass]
    public class ExtraGameManipulationTests
    {
        private DiceRoller _dice;

        [TestInitialize]
        public void Initialize()
        {
            _dice = new DiceRoller();
        }

        [TestMethod]
        public void NewTechs_WhenGettingTechCost_Should_ReturnCorrectValue()
        {
            var gameManip = new TechManager();

            var techLevel7Cost = gameManip.GetStandardTechCostForLevel(7);
            var techLevel20Cost = gameManip.GetStandardTechCostForLevel(20);
            var techLevel30Cost = gameManip.GetStandardTechCostForLevel(30);

            Assert.AreEqual(12000, techLevel7Cost);
            Assert.AreEqual(15000000, techLevel20Cost);
            Assert.AreEqual(855000000, techLevel30Cost);
        }

        [TestMethod]
        public void NewTechs_WhenGettingTechCostBelow1_Should_ReturnCostOfTechLevel1()
        {
            var gameManip = new TechManager();

            Assert.AreEqual(gameManip.GetStandardTechCostForLevel(1), gameManip.GetStandardTechCostForLevel(0));
            Assert.AreEqual(gameManip.GetStandardTechCostForLevel(1), gameManip.GetStandardTechCostForLevel(-6));
        }

        [TestMethod]
        public void NewTechs_WhenGettingTechCostAbove33_Should_ReturnCostOfTechLevel33()
        {
            var gameManip = new TechManager();

            Assert.AreEqual(gameManip.GetStandardTechCostForLevel(33), gameManip.GetStandardTechCostForLevel(34));
            Assert.AreEqual(gameManip.GetStandardTechCostForLevel(33), gameManip.GetStandardTechCostForLevel(765765));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Test already exists.")]
        public void NewTechs_WhenInsertingIntoDb_Should_NotCreateDuplicatesByName()
        {
            var mockDb = new Mock<IGameManipPersistentStorage>();
            mockDb.Setup(
                m => m.AddNewTech(It.IsAny<TechObject>())
                ).Returns(new TechObject() { Name = "Test", TechSystemID = 7 });


            var gameManip = new TechManager(mockDb.Object);
            var testTech = gameManip.NewGlobalTech(name: "Test", description: "A test tech", techType: new TechType() { TechTypeID = 99, Description = "Power Plant Technology", FieldID = 1, DistributeLowerTech = 1 }, techLevel: 7);
            var testTech2 = gameManip.NewGlobalTech(name: "Test", description: "A test tech", techType: new TechType() { TechTypeID = 99, Description = "Power Plant Technology", FieldID = 1, DistributeLowerTech = 1 }, techLevel: 7);
        }

        [TestMethod]
        public void TechTypes_WhenReadingFromDatabase_Expects_SomeSpecificValuesToBePresent()
        {
            var gameManip = new ExtraGameManipulator();
            var techTypesList = gameManip.GetAllTechTypes();

            var powerPlantTechType = techTypesList.FirstOrDefault(ttype => ttype.Description == ExtraGameManipulationConstants.TechType_PowerPlantTechnology);
            Assert.IsNotNull(powerPlantTechType);
            Assert.AreEqual(41, powerPlantTechType.TechTypeID);
            Assert.AreEqual(1, powerPlantTechType.FieldID);
            Assert.AreEqual(1, powerPlantTechType.DistributeLowerTech);

            var shieldRegenRateTechType = techTypesList.FirstOrDefault(ttype => ttype.Description == ExtraGameManipulationConstants.TechType_ShieldRegenRate);
            Assert.IsNotNull(shieldRegenRateTechType);
            Assert.AreEqual(14, shieldRegenRateTechType.TechTypeID);
            Assert.AreEqual(7, shieldRegenRateTechType.FieldID);
            Assert.AreEqual(1, shieldRegenRateTechType.DistributeLowerTech);
        }

        [TestMethod]
        public void TechTypes_WhenGettingAllTechTypesMultipleTimes_Should_OnlyGetFromStorageOnce()
        {
            var mockPersistor = new Mock<IGameManipPersistentStorage>();
            var mockTechs = new Mock<ITechsManipulation>();
            var gameManip = new ExtraGameManipulator(mockPersistor.Object, mockTechs.Object);

            mockPersistor.Setup(
                m => m.GetAllTechTypesFromStorage()
                ).Returns(new List<TechType>() { new TechType() { TechTypeID = 1, Description = "test" } });

            gameManip.GetAllTechTypes();
            gameManip.GetAllTechTypes();
            gameManip.GetAllTechTypes();

            mockPersistor.Verify(m => m.GetAllTechTypesFromStorage(), Times.Once);
        }

        [TestMethod]
        public void Techs_WhenGettingAllTechsMultipleTimes_Should_OnlyGetFromStorageOnce()
        {
            var mockPersistor = new Mock<IGameManipPersistentStorage>();
            var techManip = new TechManager(mockPersistor.Object);

            mockPersistor.Setup(
                m => m.GetAllTechsFromStorage()
                ).Returns(new List<TechObject>() { new TechObject() });

            techManip.GetAllTechs();
            techManip.GetAllTechs();
            techManip.GetAllTechs();

            mockPersistor.Verify(m => m.GetAllTechsFromStorage(), Times.Once);
        }

        [TestMethod]
        public void Techs_WhenCheckingForExistingTechs_Should_ReturnTrueIfNamePresent()
        {
            var gameManip = new TechManager();
            var isPresent = gameManip.CheckIfTechExists("Trans-Newtonian Technology");

            Assert.IsTrue(isPresent);
        }

        [TestMethod]
        public void Techs_WhenAddingExtendedTechs_Should_HaveValidIdsAndPrerequisites()
        {
            var testClass = new TechManager();
            testClass.AddInExtendedTechs();

            var testTech = testClass.GetTechByName("Fission/Fusion Matter Manipulation Technologies");
            Assert.IsNotNull(testTech.TechSystemID);

            var testTech2 = testClass.GetTechByName("Energy and Field Manipulation Technology");
            Assert.IsNotNull(testTech2.TechSystemID);
        }

    }
}
