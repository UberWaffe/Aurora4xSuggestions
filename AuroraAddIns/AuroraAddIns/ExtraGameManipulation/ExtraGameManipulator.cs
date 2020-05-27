using Aurora.AddInsInterfacing.ExtraGameManipulation.Interface;
using Aurora.AddInsInterfacing.ExtraGameManipulation.Models;
using Aurora.AddInsPersist.ExtraGameManipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.ExtraGameManipulation
{
    public class ExtraGameManipulator : IExtraGameManipulation
    {
        private IGameManipPersistentStorage _persistentStorage;
        private List<TechType> _allTechTypes;


        public ExtraGameManipulator() : this(new GameManipPersistentStorage())
        { }

        public ExtraGameManipulator(IGameManipPersistentStorage _thePersistor)
        {
            this._persistentStorage = _thePersistor;
            this._allTechTypes = null;
        }

        public int GetStandardTechCostForLevel(int techLevel)
        {
            var usedLevel = MathHelper.LimitRange(techLevel, min: 1, max: 33);

            return ExtraGameManipulationConstants.TechCostForTechLevel[usedLevel];
        }

        public TechObject NewTech(string name, string description, TechType techType, int techLevel)
        {
            var theNewTech = new TechObject()
            {
                Name = name,
                ComponentName = "",
                TechDescription = description,
                DevelopCost = GetStandardTechCostForLevel(techLevel: techLevel),
                CategoryID = techType.FieldID,
                TechTypeID = techType.TechTypeID,
                GameID = 0,
                RaceID = 0,
                AdditionalInfo = 0.0,
                AdditionalInfo2 = 0.0,
                AdditionalInfo3 = 0.0,
                AdditionalInfo4 = 0.0,
                ConventionalSystem = false,
                StartingSystem = false,
                RuinOnly = false,
                NoTechScan = true,
                TechSystemID = null,
                Prerequisite1 = 0,
                Prerequisite2 = 0
            };

            return theNewTech;
        }

        public List<TechType> GetAllTechTypes()
        {
            if (_allTechTypes == null)
            {
                _allTechTypes = _persistentStorage.GetAllTechTypesFromStorage();
            }

            return _allTechTypes;
        }

    }
}
