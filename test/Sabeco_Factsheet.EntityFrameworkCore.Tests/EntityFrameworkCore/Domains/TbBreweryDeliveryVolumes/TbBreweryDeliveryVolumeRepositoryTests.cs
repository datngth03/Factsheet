using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbBreweryDeliveryVolumes;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbBreweryDeliveryVolumes
{
    public class TbBreweryDeliveryVolumeRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbBreweryDeliveryVolumeRepository _tbBreweryDeliveryVolumeRepository;

        public TbBreweryDeliveryVolumeRepositoryTests()
        {
            _tbBreweryDeliveryVolumeRepository = GetRequiredService<ITbBreweryDeliveryVolumeRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbBreweryDeliveryVolumeRepository.GetListAsync(
                    breweryCode: "ec07a9ecda204227b695",
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
                var result = await _tbBreweryDeliveryVolumeRepository.GetCountAsync(
                    breweryCode: "fcd519eb07854a34a66d",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}