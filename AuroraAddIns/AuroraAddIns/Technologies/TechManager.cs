using Aurora.AddIns.ExtraGameManipulation;
using Aurora.AddInsInterfacing.ExtraGameManipulation.Interface;
using Aurora.AddInsInterfacing.ExtraGameManipulation.Models;
using Aurora.AddInsPersist.ExtraGameManipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddIns.Technologies
{
    public class TechManager : ITechsManipulation
    {
        private IGameManipPersistentStorage _persistentStorage;
        private List<TechObject> _allTechs;

        public TechManager() : this(new GameManipPersistentStorage())
        { }

        public TechManager(IGameManipPersistentStorage persistor)
        {
            this._persistentStorage = persistor;
            this._allTechs = new List<TechObject>();
        }

        public int GetStandardTechCostForLevel(int techLevel)
        {
            var usedLevel = MathHelper.LimitRange(techLevel, min: 1, max: 33);

            return ExtraGameManipulationConstants.TechCostForTechLevel[usedLevel];
        }

        public TechObject NewGlobalTech(string name, string description, TechType techType, int techLevel, string componentName = "",
            double info1 = 0.0, double info2 = 0.0, double info3 = 0.0, double info4 = 0.0,
            string prerequisite1 = null, string prerequisite2 = null)
        {
            var theNewTech = new TechObject()
            {
                Name = name,
                ComponentName = componentName,
                TechDescription = description,
                DevelopCost = GetStandardTechCostForLevel(techLevel: techLevel),
                CategoryID = techType.FieldID,
                TechTypeID = techType.TechTypeID,
                GameID = 0,
                RaceID = 0,
                AdditionalInfo = info1,
                AdditionalInfo2 = info2,
                AdditionalInfo3 = info3,
                AdditionalInfo4 = info4,
                ConventionalSystem = false,
                StartingSystem = false,
                RuinOnly = false,
                NoTechScan = true,
                TechSystemID = null,
                Prerequisite1 = 0,
                Prerequisite2 = 0
            };

            if (string.IsNullOrEmpty(prerequisite1) == false)
            {
                var req1Tech = GetTechByName(prerequisite1);
                if (req1Tech != null)
                {
                    theNewTech.Prerequisite1 = req1Tech.TechSystemID.Value;
                }
            }

            if (string.IsNullOrEmpty(prerequisite2) == false)
            {
                var req2Tech = GetTechByName(prerequisite2);
                if (req2Tech != null)
                {
                    theNewTech.Prerequisite2 = req2Tech.TechSystemID.Value;
                }
            }

            return NewGlobalTech(theNewTech);
        }

        public TechObject NewGlobalTech(TechObject theNewTech)
        {
            if (CheckIfTechExists(theNewTech.Name))
            {
                throw new ArgumentException($"{theNewTech.Name} already exists.");
            }

            theNewTech = _persistentStorage.AddNewTech(theNewTech);
            _allTechs.Add(theNewTech);

            return theNewTech;
        }

        public List<TechObject> GetAllTechs()
        {
            if (_allTechs == null || _allTechs.Any() == false)
            {
                _allTechs = _persistentStorage.GetAllTechsFromStorage();
            }

            return _allTechs;
        }

        public bool CheckIfTechExists(string techName)
        {
            return (GetTechByName(techName) == null)
        }

        public TechObject GetTechByName(string techName)
        {
            var techList = GetAllTechs();
            return techList.SingleOrDefault(tech => tech.Name == techName);
        }

        public void AddInExtendedTechs()
        {

        }
    }
}
