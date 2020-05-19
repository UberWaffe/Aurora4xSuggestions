using Aurora.AddIns.TerraformingTargets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.TerraformingTargets
{
    public class TerraformingManager
    {
        public TerraformingManager()
        {

        }

        public TerraformChangeResult CalculateSingleElementChange(double targetAmount, double currentAmount, double maxChangePossible)
        {
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
    }
}
