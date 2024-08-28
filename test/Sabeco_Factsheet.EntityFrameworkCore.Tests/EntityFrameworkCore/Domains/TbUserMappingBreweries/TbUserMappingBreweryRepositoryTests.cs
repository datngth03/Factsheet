using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbUserMappingBreweries;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbUserMappingBreweries
{
    public class TbUserMappingBreweryRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbUserMappingBreweryRepository _tbUserMappingBreweryRepository;

        public TbUserMappingBreweryRepositoryTests()
        {
            _tbUserMappingBreweryRepository = GetRequiredService<ITbUserMappingBreweryRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbUserMappingBreweryRepository.GetListAsync(
                    isActive: true
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
                var result = await _tbUserMappingBreweryRepository.GetCountAsync(
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}