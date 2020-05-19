using Aurora.AddIns.TerraformingTargets;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.AddIns.Tests.TestHelpers;
using Aurora.AddIns.TerraformingTargets.Models;
using System.Linq;

namespace Aurora.AddIns.Tests.TerraformingTargets

{
    [TestClass]
    public class TerraformingTargetsTests
    {
        private TerraformingManager _terraformManager;
        private DiceRoller _dice;

        [TestInitialize]
        public void Initialize()
        {
            _terraformManager = new TerraformingManager();
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
    }
}
