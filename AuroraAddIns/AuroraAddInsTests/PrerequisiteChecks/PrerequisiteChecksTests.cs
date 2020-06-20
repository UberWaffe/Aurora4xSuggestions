using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.AddIns.Tests.TestHelpers;
using System.Linq;
using System.Collections.Generic;
using Moq;
using Aurora.AddInsInterfacing.AuroraCore.Models;
using Aurora.AddInsInterfacing.AuroraFeatures.Models;
using Aurora.AddIns.AuroraFeatures;

namespace Aurora.AddIns.Tests.FlexibleComponentDesign
{
    [TestClass]
    public class PrerequisiteChecksTests
    {
        private DiceRoller _dice;

        [TestInitialize]
        public void Initialize()
        {
            _dice = new DiceRoller();
        }

        [TestMethod]
        public void ResearchPrerequisitesWorker_WhenChecking_Should_ReturnTrueIfAllPrerequisitesMet()
        {
            var listOfPrerequisites = new List<TechObject>()
            {
                new TechObject()
                {
                    TechSystemID = 1,
                    Name = "Test1"
                },
                new TechObject()
                {
                    TechSystemID = 15,
                    Name = "Test2"
                },
                new TechObject()
                {
                    TechSystemID = 77,
                    Name = "Test3"
                }
            };

            var mockResearchedTechListOfEmpire = new Dictionary<int, TechObject>();
            foreach (var tech in listOfPrerequisites)
            {
                mockResearchedTechListOfEmpire.Add(tech.TechSystemID.Value, tech);
            }

            var prerequisites = new ResearchPrerequisitesWorker();
            prerequisites.AddPrerequisites(listOfPrerequisites);
            var passed = prerequisites.IsFulfilledBy(mockResearchedTechListOfEmpire);

            Assert.IsTrue(passed);
        }

        [TestMethod]
        public void ResearchPrerequisitesWorker_WhenChecking_Should_ReturnFalseIfAnyPrerequisitesIsNotMet()
        {
            var listOfPrerequisites = new List<TechObject>()
            {
                new TechObject()
                {
                    TechSystemID = 1,
                    Name = "Test1"
                },
                new TechObject()
                {
                    TechSystemID = 15,
                    Name = "Test2"
                },
                new TechObject()
                {
                    TechSystemID = 77,
                    Name = "Test3"
                }
            };

            var mockResearchedTechListOfEmpire = new Dictionary<int, TechObject>();
            foreach (var tech in listOfPrerequisites)
            {
                mockResearchedTechListOfEmpire.Add(tech.TechSystemID.Value, tech);
            }
            mockResearchedTechListOfEmpire.Remove(15);

            var prerequisites = new ResearchPrerequisitesWorker();
            prerequisites.AddPrerequisites(listOfPrerequisites);
            var passed = prerequisites.IsFulfilledBy(mockResearchedTechListOfEmpire);

            Assert.IsFalse(passed);
        }

        [TestMethod]
        public void ResearchPrerequisitesWorker_WhenChecking_Should_ReturnTrueIfPrerequisitesIsEmptyList()
        {
            var mockResearchedTechListOfEmpire = new Dictionary<int, TechObject>();
            mockResearchedTechListOfEmpire.Add(1, new TechObject());

            var prerequisites = new ResearchPrerequisitesWorker();
            var passed = prerequisites.IsFulfilledBy(mockResearchedTechListOfEmpire);

            Assert.IsTrue(passed);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "ResearchPrerequisitesWorker.IsFulfilledBy cannot have a prerequisite that is null. Was given MissingIdTech")]
        public void ResearchPrerequisitesWorker_WhenChecking_Should_ThrowExceptionWhenToldATechWIthNullIdIsAPrerequisite()
        {
            var listOfPrerequisites = new List<TechObject>()
            {
                new TechObject() {
                    TechSystemID = null,
                    Name = "MissingIdTech"
                }
            };

            var mockResearchedTechListOfEmpire = new Dictionary<int, TechObject>();
            foreach (var tech in listOfPrerequisites)
            {
                mockResearchedTechListOfEmpire.Add(1, tech);
            }

            var prerequisites = new ResearchPrerequisitesWorker();
            prerequisites.AddPrerequisites(listOfPrerequisites);
            var passed = prerequisites.IsFulfilledBy(mockResearchedTechListOfEmpire);
        }
    }
}
