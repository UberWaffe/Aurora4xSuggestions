using Aurora.AddIns.TerraformingTargets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aurora.AddIns.TerraformingTargets.Models
{
    public class TerraformGameState
    {
        private List<OrbitBodyWithTerraformInfo> _allTerraforming { get; set; }

        private IOrbitBodyTerraformDataHandler _orbitBodyDataHandler;
        private ITerraformingManager _terraformManager;

        public TerraformGameState(IOrbitBodyTerraformDataHandler orbitBodyDataHandler, ITerraformingManager manager)
        {
            _orbitBodyDataHandler = orbitBodyDataHandler;
            _terraformManager = manager;
        }

        public void DoGameUpdate()
        {
            var deltaSecondsSinceLastUpdate = _orbitBodyDataHandler.GetDeltaTimeSinceLastGameUpdate();
            PopulateGameState();
            _allTerraforming = _terraformManager.ProcessAll(_allTerraforming, deltaSecondsSinceLastUpdate);
            UpdateGameState();
        }

        private void PopulateGameState()
        {
            _allTerraforming = _orbitBodyDataHandler.GetAllOrbitBodiesTerraformInfo();
        }

        private void UpdateGameState()
        {
            _orbitBodyDataHandler.SetAllOrbitBodiesTerraformInfo(_allTerraforming);
        }
    }
}
