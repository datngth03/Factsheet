using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbBreweryDeliveryVolumeTemps
{
    public class TbBreweryDeliveryVolumeTempRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbBreweryDeliveryVolumeTempRepository _tbBreweryDeliveryVolumeTempRepository;

        public TbBreweryDeliveryVolumeTempRepositoryTests()
        {
            _tbBreweryDeliveryVolumeTempRepository = GetRequiredService<ITbBreweryDeliveryVolumeTempRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbBreweryDeliveryVolumeTempRepository.GetListAsync(
                    breweryCode: "5cc52628d93e4cd999d3",
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
                var result = await _tbBreweryDeliveryVolumeTempRepository.GetCountAsync(
                    breweryCode: "ec42b415f32045339520",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}