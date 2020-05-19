using Aurora.AddIns.TerraformingTargets.Models;

namespace Aurora.AddIns.TerraformingTargets.Interfaces
{
    public interface ITerraformGameState
    {
        void DoGameUpdate();
        bool SetNewTargetFor(int orbitBodyId, int populationId, int elementId, double targetAmount);
        bool DeleteTargetFor(int orbitBodyId, int populationId, int elementId);
        OrbitBodyWithTerraformInfo GetTargetsFor(int orbitBodyId, int populationId);
    }
}