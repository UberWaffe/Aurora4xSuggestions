using Aurora.AddIns.TerraformingTargets;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.AddIns.Tests.TestHelpers;
using Aurora.AddInsInterfacing.TerraformingTargets.Models;
using System.Linq;
using System.Collections.Generic;
using Moq;
using Aurora.AddInsInterfacing.TerraformingTargets.Interfaces;

namespace Aurora.AddIns.Tests.TerraformingTargets

{
    [TestClass]
    public class TerraformingTargetsTests
    {
        private TerraformingManager _terraformManager;
        private DiceRoller _dice;

        private Mock<IPopulationTerraformCapacity> _mockCapGetter;

        [TestInitialize]
        public void Initialize()
        {
            _mockCapGetter = TerraformMockHelpers.SetupMock_IPopulationTerraformCapacity(0.3);

            _terraformManager = new TerraformingManager(_mockCapGetter.Object);
            _dice = new DiceRoller();
        }

        [TestMethod]
        public void Manager_WhenCalculatingChange_AndDeltaIsMoreThanNeeded_Should_GiveCorrectChangeLeft()
        {
            var targetAtm = 1.57;
            var currentAtm = 1.3;
            var maxChangePossible = 0.6;
            var expectedDeltaLeft = maxChangePossible - 0.27;

            var results = _terraformManager.CalculateSingleElementChange(targetAtm, currentAtm, maxChangePossible);

            Assert.AreEqual(expectedDeltaLeft, results.maxChangeLeft);
        }

        [TestMethod]
        public void Manager_WhenCalculatingChange_AndDeltaIsExactlyEnough_Should_GiveZero()
        {
            var targetAtm = 1.57;
            var currentAtm = 1.3;
            var maxChangePossible = 0.27;

            var results = _terraformManager.CalculateSingleElementChange(targetAtm, currentAtm, maxChangePossible);

            Assert.AreEqual(0.0, results.maxChangeLeft);
        }

        [TestMethod]
        public void Manager_WhenCalculatingChange_AndDeltaIsNotENough_Should_GiveZeroRemainingDelta()
        {
            var targetAtm = 1.57;
            var currentAtm = 1.3;
            var maxChangePossible = 0.1;

            var results = _terraformManager.CalculateSingleElementChange(targetAtm, currentAtm, maxChangePossible);

            Assert.AreEqual(0.0, results.maxChangeLeft);
        }

        [TestMethod]
        public void Manager_WhenCalculatingChange_AndDeltaIsEnough_Should_HaveFinalBeAtTarget()
        {
            var targetAtm = _dice.GetDouble(1.0, 3.0);
            var currentAtm = _dice.GetDouble(0.0, 0.7);
            var maxChangePossible = 8.0;

            var results = _terraformManager.CalculateSingleElementChange(targetAtm, currentAtm, maxChangePossible);

            Assert.AreEqual(targetAtm, results.newElementAmount);
        }

        [TestMethod]
        public void Manager_WhenCalculatingChange_AndDeltaIsZero_Should_NotAdjustCurrentEvenIfDeltaIsClose()
        {
            var targetAtm = 1.000001;
            var currentAtm = 1.0;
            var maxChangePossible = 0.0;

            var results = _terraformManager.CalculateSingleElementChange(targetAtm, currentAtm, maxChangePossible);

            Assert.AreEqual(currentAtm, results.newElementAmount);
        }

        [TestMethod]
        public void Manager_WhenCalculatingChange_AndDeltaLacks_Should_GiveCorrectNew()
        {
            var targetAtm = 2.4;
            var currentAtm = 1.05;
            var maxChangePossible = 0.75;
            var expectedNew = 1.8;

            var results = _terraformManager.CalculateSingleElementChange(targetAtm, currentAtm, maxChangePossible);

            Assert.AreEqual(expectedNew, results.newElementAmount);
        }

        [TestMethod]
        public void Manager_WhenCalculatingChange_AndDeltaIsEnough_Should_GiveTrueForTargetReached()
        {
            var targetAtm = 2.4;
            var currentAtm = 1.05;
            var maxChangePossible = 3.0;

            var results = _terraformManager.CalculateSingleElementChange(targetAtm, currentAtm, maxChangePossible);

            Assert.AreEqual(true, results.targetReached);
        }

        [TestMethod]
        public void Manager_WhenCalculatingChange_AndDeltaLacks_Should_GiveFalseForTargetReached()
        {
            var targetAtm = 2.4;
            var currentAtm = 1.05;
            var maxChangePossible = 0.03;

            var results = _terraformManager.CalculateSingleElementChange(targetAtm, currentAtm, maxChangePossible);

            Assert.AreEqual(false, results.targetReached);
        }

        [TestMethod]
        public void Manager_WhenCalculatingMultiple_AndDeltaIsEnough_Should_ReachAllTargets()
        {
            var currentElements = new TerraformElementsSet();
            currentElements.Set(elementId: 1, amount: 1.6);
            currentElements.Set(elementId: 2, amount: 1.8);
            currentElements.Set(elementId: 31, amount: 0.1);

            var targets = new TerraformElementsSet();
            targets.Set(elementId: 1, amount: 2.0);
            targets.Set(elementId: 2, amount: 2.05);
            targets.Set(elementId: 31, amount: 1.0);

            var results = _terraformManager.AdjustMultipleElements(currentElements, targets, maxChangePossible: 3.0);

            Assert.AreEqual(2.0, results.currentElementValues.GetAmount(1));
            Assert.AreEqual(2.05, results.currentElementValues.GetAmount(2));
            Assert.AreEqual(1.0, results.currentElementValues.GetAmount(31));
        }

        [TestMethod]
        public void Manager_WhenCalculatingMultiple_AndDeltaIsEnough_Should_HaveEmptyFinalTargetList()
        {
            var currentElements = new TerraformElementsSet();
            currentElements.Set(elementId: 1, amount: 1.6);
            currentElements.Set(elementId: 2, amount: 1.8);
            currentElements.Set(elementId: 31, amount: 0.1);

            var targets = new TerraformElementsSet();
            targets.Set(elementId: 1, amount: 2.0);
            targets.Set(elementId: 2, amount: 2.05);
            targets.Set(elementId: 31, amount: 1.0);

            var results = _terraformManager.AdjustMultipleElements(currentElements, targets, maxChangePossible: 3.0);
            var updatedTargets = results.adjustedTargets;

            Assert.IsFalse(updatedTargets.theElements.Any());
        }

        [TestMethod]
        public void Manager_WhenCalculatingMultiple_AndDeltaIsInsufficient_Should_DoAsMuchAsPossible()
        {
            var currentElements = new TerraformElementsSet();
            currentElements.Set(elementId: 1, amount: 1.6);
            currentElements.Set(elementId: 2, amount: 1.8);
            currentElements.Set(elementId: 31, amount: 0.1);

            var targets = new TerraformElementsSet();
            targets.Set(elementId: 1, amount: 2.0);
            targets.Set(elementId: 2, amount: 2.05);
            targets.Set(elementId: 31, amount: 1.0);

            var results = _terraformManager.AdjustMultipleElements(currentElements, targets, maxChangePossible: 0.6);

            Assert.AreEqual(2.0, results.currentElementValues.GetAmount(1));
            Assert.AreEqual(2.0, results.currentElementValues.GetAmount(2));

            Assert.IsFalse(results.adjustedTargets.IsPresent(1));
            Assert.AreEqual(2.05, results.adjustedTargets.GetAmount(2));
            Assert.AreEqual(1.0, results.adjustedTargets.GetAmount(31));
        }

        [TestMethod]
        public void Manager_WhenCalculatingMultiple_AndTwoPopulationsOnOneBody_Should_CalculateNetCorrectly()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void Manager_WhenProcessingOrbitBody_Should_ProcessCorrectly()
        {
            var mockPopulation = new OrbitBodyWithTerraformInfo(2071, 1099);
            mockPopulation.DesiredTargets.Set(1, 0.2);
            mockPopulation.DesiredTargets.Set(2, 0.8);

            var mockOrbitBody = new OrbitBodyWithCurrentElementInfo(2071);
            mockOrbitBody.CurrentElements.Set(5, 85.76);
            
            var results = _terraformManager.ProcessOrbitBody(mockPopulation, mockOrbitBody, 3600 * 24 * 5);

            Assert.IsFalse(results.newTargets.DesiredTargets.IsPresent(1));
            TwoDoublesAreCloseEnough(0.2, results.newValues.CurrentElements.GetAmount(1));
            TwoDoublesAreCloseEnough(0.1, results.newValues.CurrentElements.GetAmount(2));
            TwoDoublesAreCloseEnough(85.76, results.newValues.CurrentElements.GetAmount(5));
        }

        [TestMethod]
        public void Manager_WhenProcessingAll_Should_ProcessAllCorrectly()
        {
            var allMockInfo = new List<OrbitBodyWithTerraformInfo>();

            var entry = new OrbitBodyWithTerraformInfo(2100, 1100);
            entry.DesiredTargets.Set(1, 0.8);
            entry.DesiredTargets.Set(2, 0.2);
            allMockInfo.Add(entry);

            entry = new OrbitBodyWithTerraformInfo(2071, 1099);
            entry.DesiredTargets.Set(1, 0.1);
            entry.DesiredTargets.Set(2, 0.9);
            allMockInfo.Add(entry);

            var allBodyInfo = new List<OrbitBodyWithCurrentElementInfo>();

            var entryEle = new OrbitBodyWithCurrentElementInfo(2100);
            entryEle.CurrentElements.Set(1, 0.7);
            allBodyInfo.Add(entryEle);

            entryEle = new OrbitBodyWithCurrentElementInfo(2071);
            entryEle.CurrentElements.Set(5, 85.76);
            allBodyInfo.Add(entryEle);

            var results = _terraformManager.ProcessAll(allMockInfo, allBodyInfo, 3600 * 24 * 5);

            var body2071Results = results.newValues.First(body => body.OrbitBodyId == 2071);
            var body2071Targets = results.newTargets.First(body => body.OrbitBodyId == 2071);

            Assert.IsFalse(body2071Targets.DesiredTargets.IsPresent(1));

            TwoDoublesAreCloseEnough(0.1, body2071Results.CurrentElements.GetAmount(1));
            TwoDoublesAreCloseEnough(0.2, body2071Results.CurrentElements.GetAmount(2));
            TwoDoublesAreCloseEnough(85.76, body2071Results.CurrentElements.GetAmount(5));


            var body2100Results = results.newValues.First(body => body.OrbitBodyId == 2100);
            var body2100Targets = results.newTargets.First(body => body.OrbitBodyId == 2100);

            Assert.IsFalse(body2100Targets.DesiredTargets.IsPresent(1));
            Assert.IsFalse(body2100Targets.DesiredTargets.IsPresent(2));
            TwoDoublesAreCloseEnough(0.8, body2100Results.CurrentElements.GetAmount(1));
            TwoDoublesAreCloseEnough(0.2, body2100Results.CurrentElements.GetAmount(2));
        }

        [TestMethod]
        public void Manager_TerraformGameState_OneInvoke_Should_ProcessOnceOnly()
        {
            var mockState = TerraformMockHelpers.Setup_MockGameStateData_Targets();
            var mockStateCurrent = TerraformMockHelpers.Setup_MockGameStateData_Elements();
            var mockProcessedResult = new ProcessedTerraformingListResult()
            {
                newTargets = mockState,
                newValues = mockStateCurrent
            };

            var gameDataHandlerMock = TerraformMockHelpers.SetupMock_IOrbitBodyTerraformDataHandler(mockState);
            var managerMock = TerraformMockHelpers.SetupMock_ITerraformingManager(mockProcessedResult);
            var gameState = new TerraformGameState(gameDataHandlerMock.Object, managerMock.Object);

            gameState.DoGameUpdate();

            gameDataHandlerMock.Verify(m => m.GetAllPopulationsTerraformInfo(), Times.Once);
            managerMock.Verify(m => m.ProcessAll(It.IsAny<List<OrbitBodyWithTerraformInfo>>(), It.IsAny<List<OrbitBodyWithCurrentElementInfo>>(), 3600 * 24 * 5), Times.Once);
            gameDataHandlerMock.Verify(m => m.SetAllPopulationsTerraformInfo(mockState), Times.Once);
        }

        [TestMethod]
        public void GameState_SettingANewTarget_Should_AddCorrectly()
        {
            var mockState = TerraformMockHelpers.Setup_MockGameStateData_Targets();
            var mockStateCurrent = TerraformMockHelpers.Setup_MockGameStateData_Elements();
            var mockProcessedResult = new ProcessedTerraformingListResult()
            {
                newTargets = mockState,
                newValues = mockStateCurrent
            };

            var gameDataHandlerMock = TerraformMockHelpers.SetupMock_IOrbitBodyTerraformDataHandler(mockState);
            var managerMock = TerraformMockHelpers.SetupMock_ITerraformingManager(mockProcessedResult);
            var gameState = new TerraformGameState(gameDataHandlerMock.Object, managerMock.Object);

            gameState.SetTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 777, targetAmount: 100.0);

            var fetchTarget = gameState.GetTargetsFor(orbitBodyId: 9999, populationId: 8888);
            Assert.AreEqual(100.0, fetchTarget.DesiredTargets.GetAmount(777));
        }

        [TestMethod]
        public void GameState_SettingTheSameElementTargetMultipleTimes_Should_EndWithTheFinalSet()
        {
            var mockState = TerraformMockHelpers.Setup_MockGameStateData_Targets();
            var mockStateCurrent = TerraformMockHelpers.Setup_MockGameStateData_Elements();
            var mockProcessedResult = new ProcessedTerraformingListResult()
            {
                newTargets = mockState,
                newValues = mockStateCurrent
            };

            var gameDataHandlerMock = TerraformMockHelpers.SetupMock_IOrbitBodyTerraformDataHandler(mockState);
            var managerMock = TerraformMockHelpers.SetupMock_ITerraformingManager(mockProcessedResult);
            var gameState = new TerraformGameState(gameDataHandlerMock.Object, managerMock.Object);

            gameState.SetTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 777, targetAmount: 100.0);
            gameState.SetTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 777, targetAmount: 734.0);
            gameState.SetTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 777, targetAmount: 123.0);
            gameState.SetTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 777, targetAmount: 45.0);

            var fetchTarget = gameState.GetTargetsFor(orbitBodyId: 9999, populationId: 8888);
            Assert.AreEqual(45.0, fetchTarget.DesiredTargets.GetAmount(777));
        }

        [TestMethod]
        public void GameState_DeletingATarget_Should_RemoveCorrectly()
        {
            var mockState = TerraformMockHelpers.Setup_MockGameStateData_Targets();
            var mockStateCurrent = TerraformMockHelpers.Setup_MockGameStateData_Elements();
            var mockProcessedResult = new ProcessedTerraformingListResult()
            {
                newTargets = mockState,
                newValues = mockStateCurrent
            };

            var gameDataHandlerMock = TerraformMockHelpers.SetupMock_IOrbitBodyTerraformDataHandler(mockState);
            var managerMock = TerraformMockHelpers.SetupMock_ITerraformingManager(mockProcessedResult);
            var gameState = new TerraformGameState(gameDataHandlerMock.Object, managerMock.Object);

            gameState.SetTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 1, targetAmount: 1.1);
            gameState.SetTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 2, targetAmount: 2.2);
            gameState.SetTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 3, targetAmount: 3.3);

            gameState.DeleteTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 2);

            var fetchTarget = gameState.GetTargetsFor(orbitBodyId: 9999, populationId: 8888);
            Assert.AreEqual(1.1, fetchTarget.DesiredTargets.GetAmount(1));
            Assert.IsFalse(fetchTarget.DesiredTargets.IsPresent(2));
            Assert.AreEqual(3.3, fetchTarget.DesiredTargets.GetAmount(3));
        }

        [TestMethod]
        public void GameState_IfAllTargetsAreDeleted_Should_RemoveEntryEntirely()
        {
            var mockState = TerraformMockHelpers.Setup_MockGameStateData_Targets();
            var mockStateCurrent = TerraformMockHelpers.Setup_MockGameStateData_Elements();
            var mockProcessedResult = new ProcessedTerraformingListResult()
            {
                newTargets = mockState,
                newValues = mockStateCurrent
            };

            var gameDataHandlerMock = TerraformMockHelpers.SetupMock_IOrbitBodyTerraformDataHandler(mockState);
            var managerMock = TerraformMockHelpers.SetupMock_ITerraformingManager(mockProcessedResult);
            var gameState = new TerraformGameState(gameDataHandlerMock.Object, managerMock.Object);

            gameState.SetTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 1, targetAmount: 1.1);

            var fetchTarget = gameState.GetTargetsFor(orbitBodyId: 9999, populationId: 8888);
            Assert.AreEqual(1.1, fetchTarget.DesiredTargets.GetAmount(1));

            gameState.DeleteTargetFor(orbitBodyId: 9999, populationId: 8888, elementId: 1);
            fetchTarget = gameState.GetTargetsFor(orbitBodyId: 9999, populationId: 8888);

            Assert.IsNull(fetchTarget);
        }


        #region private_functions

        private void TwoDoublesAreCloseEnough(double expected, double actual)
        {
            var delta = Math.Abs(expected - actual);
            if (delta < 0.001)
            {
                Assert.IsTrue(delta < 0.001);
            }
            else
            {
                Assert.AreEqual(expected, actual);
            }
        }

        #endregion
    }
}
