using Aurora.AddInsInterfacing.TerraformingTargets.Interfaces;
using Aurora.AddInsInterfacing.TerraformingTargets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.TerraformingTargets
{
    public class TerraformGameState : ITerraformGameState
    {
        private List<OrbitBodyWithTerraformInfo> _allTerraforming { get; set; }
        private List<OrbitBodyWithCurrentElementInfo> _allCurrentElementValues { get; set; }

        private IOrbitBodyTerraformDataHandler _orbitBodyDataHandler;
        private ITerraformingManager _terraformManager;

        public TerraformGameState(IOrbitBodyTerraformDataHandler orbitBodyDataHandler, ITerraformingManager manager)
        {
            _orbitBodyDataHandler = orbitBodyDataHandler;
            _terraformManager = manager;
            _allTerraforming = new List<OrbitBodyWithTerraformInfo>();
            _allCurrentElementValues = new List<OrbitBodyWithCurrentElementInfo>();
        }

        public void DoGameUpdate()
        {
            var deltaSecondsSinceLastUpdate = _orbitBodyDataHandler.GetDeltaTimeSinceLastGameUpdate();
            PopulateGameState();
            var processResult = _terraformManager.ProcessAll(_allTerraforming, _allCurrentElementValues, deltaSecondsSinceLastUpdate);
            _allTerraforming = processResult.newTargets;
            _allCurrentElementValues = processResult.newValues;
            UpdateGameState();
        }

        public bool SetTargetFor(int orbitBodyId, int populationId, int elementId, double targetAmount)
        {
            var targetElement = GetOrCreateTargetsFor(orbitBodyId: orbitBodyId, populationId: populationId);

            targetElement.DesiredTargets.Set(elementId: elementId, amount: targetAmount);

            return true;
        }

        public bool DeleteTargetFor(int orbitBodyId, int populationId, int elementId)
        {
            var elementToDelete = _allTerraforming.FirstOrDefault(target => target.OrbitBodyId == orbitBodyId && target.PopulationId == populationId);
            if (elementToDelete != null)
            {
                elementToDelete.DesiredTargets.Remove(elementId);

                if (elementToDelete.DesiredTargets.NoElementsLeft())
                {
                    _allTerraforming.Remove(elementToDelete);
                }
            }

            return true;
        }

        public OrbitBodyWithTerraformInfo GetTargetsFor(int orbitBodyId, int populationId)
        {
            var target = _allTerraforming.FirstOrDefault(elem => elem.OrbitBodyId == orbitBodyId && elem.PopulationId == populationId);
            return target;
        }

        public List<OrbitBodyWithTerraformInfo> GetTargetsForAll()
        {
            return _allTerraforming;
        }

        public OrbitBodyWithCurrentElementInfo GetCurrentElementsFor(int orbitBodyId)
        {
            var currentValues = _allCurrentElementValues.FirstOrDefault(elem => elem.OrbitBodyId == orbitBodyId);
            return currentValues;
        }

        private OrbitBodyWithTerraformInfo GetOrCreateTargetsFor(int orbitBodyId, int populationId)
        {
            var target = this.GetTargetsFor(orbitBodyId, populationId);
            if (target == null)
            {
                target = new OrbitBodyWithTerraformInfo(orbitBodyId, populationId);
                _allTerraforming.Add(target);
            }

            return target;
        }

        private void PopulateGameState()
        {
            _allTerraforming = _orbitBodyDataHandler.GetAllPopulationsTerraformInfo();
            _allCurrentElementValues = _orbitBodyDataHandler.GetAllOrbitBodiesCurrentElementsInfo();
        }

        private void UpdateGameState()
        {
            _orbitBodyDataHandler.SetAllPopulationsTerraformInfo(_allTerraforming);
            _allCurrentElementValues = _orbitBodyDataHandler.GetAllOrbitBodiesCurrentElementsInfo();
        }
    }
}
