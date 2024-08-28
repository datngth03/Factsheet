using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbBrewerySkus;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbBrewerySkus
{
    public class TbBrewerySkuRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbBrewerySkuRepository _tbBrewerySkuRepository;

        public TbBrewerySkuRepositoryTests()
        {
            _tbBrewerySkuRepository = GetRequiredService<ITbBrewerySkuRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbBrewerySkuRepository.GetListAsync(
                    breweryCode: "e5fbd0c96fe942d3b5ad",
                    sKUCode: "b1caf89d6738454a",
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
                var result = await _tbBrewerySkuRepository.GetCountAsync(
                    breweryCode: "192a96c32ac5472f90ad",
                    sKUCode: "47a2517d22724399",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}