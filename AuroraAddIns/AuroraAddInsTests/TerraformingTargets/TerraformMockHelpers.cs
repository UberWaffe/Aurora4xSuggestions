using Aurora.AddIns.TerraformingTargets.Interfaces;
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
    }
}
