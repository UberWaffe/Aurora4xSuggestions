using Aurora.AddInsInterfacing.ExtraGameManipulation.Interface;
using Aurora.AddInsInterfacing.ExtraGameManipulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddIns.Technologies
{
    public class ExtendedTechnologies
    {
        private ITechsManipulation _techManager;

        private Dictionary<int, NewTechDetails> _gatewayTechNames = new Dictionary<int, NewTechDetails>()
        {
            { 1, new NewTechDetails() {
                tier = 9,
                name = "Fission/Fusion Matter Manipulation Technologies",
                description = "A new breakthrough in practical technological applications, using our knowledge of fission and fusion processes.",
                preRequisite1 = "Trans-Newtonian Technology",
                preRequisite2 = "Tokamak Fusion Reactor" }
            },
            { 2, new NewTechDetails() {
                tier = 12,
                name = "Energy and Field Manipulation Technology: Insight 1/5",
                description = "On the brink of new practical technology applications, we need to find everyday applications for our advanced power generation technologies.",
                preRequisite1 = "Fission/Fusion Matter Manipulation Technologies",
                preRequisite2 = "Vacuum Energy Power Plant" }
            },
            { 3, new NewTechDetails() {
                tier = 12,
                name = "Energy and Field Manipulation Technology: Insight 2/5",
                description = "Using our knowledge of field manipulation and generation, we can start to contain and manipulate matter and energy more directly.",
                preRequisite1 = "Energy and Field Manipulation Technology: Insight 1/5",
                preRequisite2 = "Omega Shields" }
            },
            { 4, new NewTechDetails() {
                tier = 12,
                name = "Energy and Field Manipulation Technology: Insight 3/5",
                description = "For true practical application breakthroughs we must also learn how to apply these principles on scales that span entire planets",
                preRequisite1 = "Energy and Field Manipulation Technology: Insight 2/5",
                preRequisite2 = "Terraforming Rate 0.00375 atm" }
            },
            { 5, new NewTechDetails() {
                tier = 12,
                name = "Energy and Field Manipulation Technology: Insight 4/5",
                description = "A true technological breakthrough will require applications that can withstand extreme tempreatures and environments.",
                preRequisite1 = "Energy and Field Manipulation Technology: Insight 3/5",
                preRequisite2 = "Colonization Cost Reduction 50%" }
            },
            { 6, new NewTechDetails() {
                tier = 12,
                name = "Energy and Field Manipulation Technology: Insight 5/5",
                description = "We must also be capable of monitoring matter and energy on a fundamental level, even in the midst of extreme energy reactions.",
                preRequisite1 = "Energy and Field Manipulation Technology: Insight 4/5",
                preRequisite2 = "EM Sensor Sensitivity 75" }
            },
            { 7, new NewTechDetails() {
                tier = 14,
                name = "Energy and Field Manipulation Technology",
                description = "A new breakthrough in practical technological applications, using all of our insights and understanding. All that is left is learning how to produce and manufacture this revolution.",
                preRequisite1 = "Energy and Field Manipulation Technology: Insight 5/5",
                preRequisite2 = "Construction Rate 70 BP" }
            },
        };


        public ExtendedTechnologies(ITechsManipulation theTechManager)
        {
            this._techManager = theTechManager;
        }

        public List<TechObject> AddExtendedTechsStage1()
        {
            var result = new List<TechObject>();

            for (var gateCount = 1; gateCount <= 7; gateCount++)
            {
                GetOrCreateExtendedGatewayTech(gateCount);
            }

            return result;
        }

        public TechObject GetOrCreateExtendedGatewayTech(int key)
        {
            var detailsEntry = _gatewayTechNames[key];
            var newTech = DuplicateIfNotExisting(detailsEntry.preRequisite1, detailsEntry);

            if (_techManager.CheckIfTechExists(newTech.Name) == false)
            {
                newTech = _techManager.NewGlobalTech(newTech);
            }

            return newTech;
        }

        public TechObject DuplicateIfNotExisting(string nameOfTechToDuplicate, NewTechDetails newTech)
        {
            if (_techManager.CheckIfTechExists(newTech.name) == true)
            {
                return _techManager.GetTechByName(newTech.name);
            }

            var theOriginalTech = _techManager.GetTechByName(nameOfTechToDuplicate);
            var theNewTech = DuplicateAndAdjustTech(theOriginalTech, newTech);

            return theNewTech;
        }

        private TechObject DuplicateAndAdjustTech(TechObject theOriginalTech, NewTechDetails newTech)
        {
            var theNewTech = theOriginalTech.Duplicate(newTech.name);
            theNewTech.DevelopCost = _techManager.GetStandardTechCostForLevel(newTech.tier);

            if (string.IsNullOrEmpty(newTech.description) == false)
            {
                theNewTech.TechDescription = newTech.description;
            }

            if (string.IsNullOrEmpty(newTech.preRequisite1) == false) {
                var prereqTech = _techManager.GetTechByName(newTech.preRequisite1);
                theNewTech.Prerequisite1 = prereqTech.TechSystemID.Value;
            }
            if (string.IsNullOrEmpty(newTech.preRequisite2) == false)
            {
                var prereqTech = _techManager.GetTechByName(newTech.preRequisite2);
                theNewTech.Prerequisite2 = prereqTech.TechSystemID.Value;
            }

            if (string.IsNullOrEmpty(newTech.component) == false) { theNewTech.ComponentName = newTech.component; }
            if (newTech.newValue1.HasValue) { theNewTech.AdditionalInfo = newTech.newValue1.Value; }
            if (newTech.newValue2.HasValue) { theNewTech.AdditionalInfo = newTech.newValue2.Value; }
            if (newTech.newValue3.HasValue) { theNewTech.AdditionalInfo = newTech.newValue3.Value; }
            if (newTech.newValue4.HasValue) { theNewTech.AdditionalInfo = newTech.newValue4.Value; }

            return theNewTech;
        }
    }

    public class NewTechDetails
    {
        public int tier;
        public string name;
        public string description = null;
        public string preRequisite1 = null;
        public string preRequisite2 = null;
        public string component = "";
        public double? newValue1 = null;
        public double? newValue2 = null;
        public double? newValue3 = null;
        public double? newValue4 = null;
    }
}
