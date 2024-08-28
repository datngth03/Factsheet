using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbBrewerySkuTemps;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbBrewerySkuTemps
{
    public class TbBrewerySkuTempRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbBrewerySkuTempRepository _tbBrewerySkuTempRepository;

        public TbBrewerySkuTempRepositoryTests()
        {
            _tbBrewerySkuTempRepository = GetRequiredService<ITbBrewerySkuTempRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbBrewerySkuTempRepository.GetListAsync(
                    breweryCode: "f05d6bd7962542ce9c1a",
                    sKUCode: "c689f85d00fb4670",
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
                var result = await _tbBrewerySkuTempRepository.GetCountAsync(
                    breweryCode: "85d93e58cb2f4befa11b",
                    sKUCode: "c52fdd641bd240a6",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}