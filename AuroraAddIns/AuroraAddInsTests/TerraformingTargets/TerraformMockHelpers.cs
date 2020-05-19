using Aurora.AddIns.TerraformingTargets.Interfaces;
using Aurora.AddIns.TerraformingTargets.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddIns.Tests.TerraformingTargets
{
    public static class TerraformMockHelpers
    {
        public static Mock<IPopulationTerraformCapacity> SetupMock_IPopulationTerraformCapacity(double capToReturn)
        {
            var mockCapacity = new Mock<IPopulationTerraformCapacity>();

            mockCapacity.Setup(
                m => m.GetTotalTerraformingDeltaForPopulation(1099, It.IsAny<long>())
                ).Returns(capToReturn);

            mockCapacity.Setup(
                m => m.GetTotalTerraformingDeltaForPopulation(1100, It.IsAny<long>())
                ).Returns(capToReturn * 2);

            return mockCapacity;
        }

        public static Mock<IOrbitBodyTerraformDataHandler> SetupMock_IOrbitBodyTerraformDataHandler(List<OrbitBodyWithTerraformInfo> data)
        {
            var mockGameState = new Mock<IOrbitBodyTerraformDataHandler>();

            mockGameState.Setup(
                m => m.GetAllPopulationsTerraformInfo()
                ).Returns(data);

            mockGameState.Setup(
                m => m.SetAllPopulationsTerraformInfo(It.IsAny<List<OrbitBodyWithTerraformInfo>>())
                ).Verifiable();

            mockGameState.Setup(
                m => m.GetDeltaTimeSinceLastGameUpdate()
                ).Returns(3600 * 24 * 5);

            return mockGameState;
        }

        public static Mock<ITerraformingManager> SetupMock_ITerraformingManager(ProcessedTerraformingListResult data)
        {
            var mockManager = new Mock<ITerraformingManager>();

            mockManager.Setup(
                m => m.ProcessAll(It.IsAny<List<OrbitBodyWithTerraformInfo>>(), It.IsAny<List<OrbitBodyWithCurrentElementInfo>>(), It.IsAny<long>())
                ).Returns(data);

            return mockManager;
        }

        public static List<OrbitBodyWithTerraformInfo> Setup_MockGameStateData_Targets()
        {
            var getDataResult = new List<OrbitBodyWithTerraformInfo>();

            var targets = new TerraformElementsSet();
            targets.Set(1, 1.1);
            targets.Set(2, 2.2);
            targets.Set(3, 3.3);

            getDataResult.Add(new OrbitBodyWithTerraformInfo(5000, 1000)
            {
                DesiredTargets = targets
            });

            targets = new TerraformElementsSet();
            targets.Set(4, 2.0);
            targets.Set(5, 2.5);
            targets.Set(6, 3.0);

            getDataResult.Add(new OrbitBodyWithTerraformInfo(5001, 1001)
            {
                DesiredTargets = targets
            });

            return getDataResult;
        }

        public static List<OrbitBodyWithCurrentElementInfo> Setup_MockGameStateData_Elements()
        {
            var getElementsResult = new List<OrbitBodyWithCurrentElementInfo>();

            var currentElements = new TerraformElementsSet();
            currentElements.Set(1, 1.0);
            currentElements.Set(2, 2.0);
            currentElements.Set(3, 3.0);

            getElementsResult.Add(new OrbitBodyWithCurrentElementInfo(5000)
            {
                CurrentElements = currentElements
            });

            currentElements = new TerraformElementsSet();
            currentElements.Set(4, 4.0);
            currentElements.Set(5, 5.0);
            currentElements.Set(6, 6.0);

            getElementsResult.Add(new OrbitBodyWithCurrentElementInfo(5001)
            {
                CurrentElements = currentElements
            });

            return getElementsResult;
        }

    }
}
