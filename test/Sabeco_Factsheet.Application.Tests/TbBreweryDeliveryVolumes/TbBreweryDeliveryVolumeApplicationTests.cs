using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{
    public abstract class TbBreweryDeliveryVolumesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbBreweryDeliveryVolumesAppService _tbBreweryDeliveryVolumesAppService;
        private readonly IRepository<TbBreweryDeliveryVolume, int> _tbBreweryDeliveryVolumeRepository;

        public TbBreweryDeliveryVolumesAppServiceTests()
        {
            _tbBreweryDeliveryVolumesAppService = GetRequiredService<ITbBreweryDeliveryVolumesAppService>();
            _tbBreweryDeliveryVolumeRepository = GetRequiredService<IRepository<TbBreweryDeliveryVolume, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbBreweryDeliveryVolumesAppService.GetListAsync(new GetTbBreweryDeliveryVolumesInput());

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
            var result = await _tbBreweryDeliveryVolumesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbBreweryDeliveryVolumeCreateDto
            {
                BreweryId = 1564073004,
                BreweryCode = "6c8e53db267044cbb7ba",
                Year = 1428502505,
                DeliveryVolume = 240331288,
                isActive = true
            };

            // Act
            var serviceResult = await _tbBreweryDeliveryVolumesAppService.CreateAsync(input);

            // Assert
            var result = await _tbBreweryDeliveryVolumeRepository.FindAsync(c => c.BreweryId == serviceResult.BreweryId);

            result.ShouldNotBe(null);
            result.BreweryId.ShouldBe(1564073004);
            result.BreweryCode.ShouldBe("6c8e53db267044cbb7ba");
            result.Year.ShouldBe(1428502505);
            result.DeliveryVolume.ShouldBe(240331288);
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbBreweryDeliveryVolumeUpdateDto()
            {
                BreweryId = 660402780,
                BreweryCode = "010bb239ef4e42179c0e",
                Year = 200069753,
                DeliveryVolume = 1879516944,
                isActive = true
            };

            // Act
            var serviceResult = await _tbBreweryDeliveryVolumesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbBreweryDeliveryVolumeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.BreweryId.ShouldBe(660402780);
            result.BreweryCode.ShouldBe("010bb239ef4e42179c0e");
            result.Year.ShouldBe(200069753);
            result.DeliveryVolume.ShouldBe(1879516944);
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbBreweryDeliveryVolumesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbBreweryDeliveryVolumeRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}