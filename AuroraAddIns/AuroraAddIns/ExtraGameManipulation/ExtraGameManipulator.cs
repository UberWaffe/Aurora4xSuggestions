using Aurora.AddIns.Technologies;
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
        private ITechsManipulation _techs;
        private List<TechType> _allTechTypes;

        public ExtraGameManipulator() : this(new GameManipPersistentStorage(), new TechManager())
        { }

        public ExtraGameManipulator(IGameManipPersistentStorage _thePersistor, ITechsManipulation techker)
        {
            this._persistentStorage = _thePersistor;
            this._techs = techker;
            this._allTechTypes = null;
        }

        public void CreateNewExtendedTechnologies()
        {

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
