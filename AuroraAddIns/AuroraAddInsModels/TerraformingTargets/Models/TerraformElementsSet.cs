using System.Collections.Generic;
using System.Linq;

namespace Aurora.AddInsInterfacing.TerraformingTargets.Models
{
    public class TerraformElementsSet
    {
        public List<TerraformElement> theElements { get; set; }

        public TerraformElementsSet()
        {
            theElements = new List<TerraformElement>();
        }

        public void Add(int elementId, double amount)
        {
            var theElement = theElements.FirstOrDefault(elem => elem.elementId == elementId);
            if (theElement == null)
            {
                theElement = new TerraformElement()
                {
                    elementId = elementId,
                    amount = amount
                };
                theElements.Add(theElement);
            }
            else
            {
                theElement.amount += amount;
            }
        }

        public void Set(int elementId, double amount)
        {
            var theElement = theElements.FirstOrDefault(elem => elem.elementId == elementId);
            if (theElement == null)
            {
                theElement = new TerraformElement()
                {
                    elementId = elementId,
                    amount = amount
                };
                theElements.Add(theElement);
            }
            else
            {
                theElement.amount = amount;
            }
        }

        public void Remove(int elementId)
        {
            var exists = theElements.FirstOrDefault(elem => elem.elementId == elementId);
            if (exists != null)
            {
                theElements.Remove(exists);
            }
        }

        public double GetAmount(int elementId)
        {
            var theElement = theElements.FirstOrDefault(elem => elem.elementId == elementId);
            if (theElement == null)
            {
                return 0.0;
            }
            return theElement.amount;
        }

        public TerraformElement Get(int elementId)
        {
            var theElement = theElements.FirstOrDefault(elem => elem.elementId == elementId);
            if (theElement == null)
            {
                return new TerraformElement() {
                    elementId = elementId,
                    amount = 0.0
                };
            }
            return theElement;
        }

        public bool IsPresent(int elementId)
        {
            return theElements.Any(elem => elem.elementId == elementId);
        }

        public bool NoElementsLeft()
        {
            return (theElements.Any() == false);
        }
    }
}