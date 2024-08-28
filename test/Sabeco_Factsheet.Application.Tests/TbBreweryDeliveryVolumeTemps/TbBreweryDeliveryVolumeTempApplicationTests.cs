using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps
{
    public abstract class TbBreweryDeliveryVolumeTempsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbBreweryDeliveryVolumeTempsAppService _tbBreweryDeliveryVolumeTempsAppService;
        private readonly IRepository<TbBreweryDeliveryVolumeTemp, int> _tbBreweryDeliveryVolumeTempRepository;

        public TbBreweryDeliveryVolumeTempsAppServiceTests()
        {
            _tbBreweryDeliveryVolumeTempsAppService = GetRequiredService<ITbBreweryDeliveryVolumeTempsAppService>();
            _tbBreweryDeliveryVolumeTempRepository = GetRequiredService<IRepository<TbBreweryDeliveryVolumeTemp, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbBreweryDeliveryVolumeTempsAppService.GetListAsync(new GetTbBreweryDeliveryVolumeTempsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == 1).ShouldBe(true);
            result.Items.Any(x => x.Id == 2).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tbBreweryDeliveryVolumeTempsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbBreweryDeliveryVolumeTempCreateDto
            {
                idBreweryDeliveryVolume = 714459984,
                BreweryId = 1920850130,
                BreweryCode = "cce9e519eff64a26a20b",
                Year = 982882987,
                DeliveryVolume = 1131622811,
                isActive = true
            };

            // Act
            var serviceResult = await _tbBreweryDeliveryVolumeTempsAppService.CreateAsync(input);

            // Assert
            var result = await _tbBreweryDeliveryVolumeTempRepository.FindAsync(c => c.idBreweryDeliveryVolume == serviceResult.idBreweryDeliveryVolume);

            result.ShouldNotBe(null);
            result.idBreweryDeliveryVolume.ShouldBe(714459984);
            result.BreweryId.ShouldBe(1920850130);
            result.BreweryCode.ShouldBe("cce9e519eff64a26a20b");
            result.Year.ShouldBe(982882987);
            result.DeliveryVolume.ShouldBe(1131622811);
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbBreweryDeliveryVolumeTempUpdateDto()
            {
                idBreweryDeliveryVolume = 2046342878,
                BreweryId = 1153717664,
                BreweryCode = "de2f4a0194164252a6a6",
                Year = 1311325146,
                DeliveryVolume = 58824622,
                isActive = true
            };

            // Act
            var serviceResult = await _tbBreweryDeliveryVolumeTempsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbBreweryDeliveryVolumeTempRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.idBreweryDeliveryVolume.ShouldBe(2046342878);
            result.BreweryId.ShouldBe(1153717664);
            result.BreweryCode.ShouldBe("de2f4a0194164252a6a6");
            result.Year.ShouldBe(1311325146);
            result.DeliveryVolume.ShouldBe(58824622);
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbBreweryDeliveryVolumeTempsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbBreweryDeliveryVolumeTempRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}