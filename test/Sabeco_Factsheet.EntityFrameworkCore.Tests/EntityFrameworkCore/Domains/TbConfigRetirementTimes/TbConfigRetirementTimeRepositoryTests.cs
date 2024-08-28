using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbConfigRetirementTimes;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbConfigRetirementTimes
{
    public class TbConfigRetirementTimeRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbConfigRetirementTimeRepository _tbConfigRetirementTimeRepository;

        public TbConfigRetirementTimeRepositoryTests()
        {
            _tbConfigRetirementTimeRepository = GetRequiredService<ITbConfigRetirementTimeRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbConfigRetirementTimeRepository.GetListAsync(
                    code: "ece4be9c97c64be6a4e621fae6124b8edd3ad8e40cad4ae3b0f35aa82b2384238af83601f7ca4ef0aabc9089c98de9",
                    note: "9a89616d566a4ae699583f3dff873283976b4752423b40ecb852c446f7ab29094136e09419734fc09a7a149e881397"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(1);
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbConfigRetirementTimeRepository.GetCountAsync(
                    code: "1e84d7",
                    note: "c9e3ffff39f34c21864f6d2050054b8d3d1a05dcd"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}