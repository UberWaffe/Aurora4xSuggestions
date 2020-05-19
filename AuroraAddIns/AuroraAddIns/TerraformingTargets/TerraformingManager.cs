using Aurora.AddIns.TerraformingTargets.Interfaces;
using Aurora.AddIns.TerraformingTargets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.TerraformingTargets
{
    public class TerraformingManager : ITerraformingManager
    {
        private IPopulationTerraformCapacity _terraformCapacityGetter;

        public TerraformingManager(IPopulationTerraformCapacity capGetter)
        {
            _terraformCapacityGetter = capGetter;
        }

        public TerraformChangeResult CalculateSingleElementChange(double targetAmount, double currentAmount, double maxChangePossible)
        {
            if (maxChangePossible < TerraformConstants.CloseEnoughToMatch)
            {
                return new TerraformChangeResult(currentAmount, 0.0, false);
            }

            var requiredDelta = Math.Abs(targetAmount - currentAmount);
            var usedChange = Math.Min(requiredDelta, maxChangePossible);
            var changeLeftOver = maxChangePossible - usedChange;
            var targetReached = false;

            var newElementAmount = currentAmount;
            if (targetAmount < currentAmount)
            {
                newElementAmount -= usedChange;
            }
            else if (targetAmount > currentAmount)
            {
                newElementAmount += usedChange;
            }

            if (Math.Abs(targetAmount - newElementAmount) < TerraformConstants.CloseEnoughToMatch)
            {
                newElementAmount = targetAmount;
                targetReached = true;
            }

            return new TerraformChangeResult(newElementAmount, changeLeftOver, targetReached);
        }

        public TerraformMutipleAdjustmentResult AdjustMultipleElements(TerraformElementsSet currentElements, TerraformElementsSet targets, double maxChangePossible)
        {
            var targetsToRemove = new List<TerraformElement>();

            var remainingDelta = maxChangePossible;
            foreach (var target in targets.theElements)
            {
                var currentElement = currentElements.Get(target.elementId);
                var adjustResult = CalculateSingleElementChange(target.amount, currentElement.amount, remainingDelta);
                remainingDelta = adjustResult.maxChangeLeft;

                currentElements.Set(currentElement.elementId, adjustResult.newElementAmount);

                if (adjustResult.targetReached)
                {
                    targetsToRemove.Add(target);
                }
            }

            foreach(var target in targetsToRemove)
            {
                targets.Remove(target.elementId);
            }

            return new TerraformMutipleAdjustmentResult()
            {
                currentElementValues = currentElements,
                adjustedTargets = targets
            };
        }

        public ProcessedTerraformingResult ProcessOrbitBody(OrbitBodyWithTerraformInfo target, OrbitBodyWithCurrentElementInfo currentElements, long deltaTimeInSeconds)
        {
            var maxPossibleDelta = _terraformCapacityGetter.GetTotalTerraformingDeltaForPopulation(target.PopulationId, secondsSinceLastCalc: deltaTimeInSeconds);

            var adjustResults = AdjustMultipleElements(currentElements: currentElements.CurrentElements, targets: target.DesiredTargets, maxChangePossible: maxPossibleDelta);
            currentElements.CurrentElements = adjustResults.currentElementValues;
            target.DesiredTargets = adjustResults.adjustedTargets;

            return new ProcessedTerraformingResult()
            {
                newTargets = target,
                newValues = currentElements
            };
        }

        public ProcessedTerraformingListResult ProcessAll(List<OrbitBodyWithTerraformInfo> allTargets, List<OrbitBodyWithCurrentElementInfo> allCurrentElements, long deltaTimeInSeconds)
        {
            var allTargetsArray = allTargets.ToArray();
            for (var counter = 0; counter < allTargets.Count; counter++)
            {
                var currentTarget = allTargetsArray[counter];
                var relatedOrbitBodyInfo = allCurrentElements.FirstOrDefault(body => body.OrbitBodyId == currentTarget.OrbitBodyId);
                if (relatedOrbitBodyInfo == null)
                {
                    relatedOrbitBodyInfo = new OrbitBodyWithCurrentElementInfo(currentTarget.OrbitBodyId);
                    allCurrentElements.Add(relatedOrbitBodyInfo);
                }

                var processResult = ProcessOrbitBody(currentTarget, relatedOrbitBodyInfo, deltaTimeInSeconds);
                allTargetsArray[counter] = processResult.newTargets;

                relatedOrbitBodyInfo = processResult.newValues;
            }

            return new ProcessedTerraformingListResult()
            {
                newTargets = allTargetsArray.ToList(),
                newValues = allCurrentElements
            };
        }
    }
}
