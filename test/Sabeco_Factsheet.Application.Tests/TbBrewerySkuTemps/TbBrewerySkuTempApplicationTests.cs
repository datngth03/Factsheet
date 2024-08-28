using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbBrewerySkuTemps
{
    public abstract class TbBrewerySkuTempsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbBrewerySkuTempsAppService _tbBrewerySkuTempsAppService;
        private readonly IRepository<TbBrewerySkuTemp, int> _tbBrewerySkuTempRepository;

        public TbBrewerySkuTempsAppServiceTests()
        {
            _tbBrewerySkuTempsAppService = GetRequiredService<ITbBrewerySkuTempsAppService>();
            _tbBrewerySkuTempRepository = GetRequiredService<IRepository<TbBrewerySkuTemp, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbBrewerySkuTempsAppService.GetListAsync(new GetTbBrewerySkuTempsInput());

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
            var result = await _tbBrewerySkuTempsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbBrewerySkuTempCreateDto
            {
                idBrewerySKU = 1889056957,
                Year = 1217554491,
                BreweryCode = "823ce8cc019c4988a3e3",
                SKUCode = "c9201add7be84bee",
                ProductionVolume = 923144289,
                DocStatus = 10,
                IsActive = true,
                BreweryId = 1113028828,
                SKUId = 1052643587
            };

            // Act
            var serviceResult = await _tbBrewerySkuTempsAppService.CreateAsync(input);

            // Assert
            var result = await _tbBrewerySkuTempRepository.FindAsync(c => c.idBrewerySKU == serviceResult.idBrewerySKU);

            result.ShouldNotBe(null);
            result.idBrewerySKU.ShouldBe(1889056957);
            result.Year.ShouldBe(1217554491);
            result.BreweryCode.ShouldBe("823ce8cc019c4988a3e3");
            result.SKUCode.ShouldBe("c9201add7be84bee");
            result.ProductionVolume.ShouldBe(923144289);
            result.DocStatus.ShouldBe((byte?)10);
            result.IsActive.ShouldBe(true);
            result.BreweryId.ShouldBe(1113028828);
            result.SKUId.ShouldBe(1052643587);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbBrewerySkuTempUpdateDto()
            {
                idBrewerySKU = 1738679235,
                Year = 1219191391,
                BreweryCode = "fd7cafc350b64dd8bbba",
                SKUCode = "1392654c94eb4df5",
                ProductionVolume = 844918964,
                DocStatus = 106,
                IsActive = true,
                BreweryId = 1830742123,
                SKUId = 2116161047
            };

            // Act
            var serviceResult = await _tbBrewerySkuTempsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbBrewerySkuTempRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.idBrewerySKU.ShouldBe(1738679235);
            result.Year.ShouldBe(1219191391);
            result.BreweryCode.ShouldBe("fd7cafc350b64dd8bbba");
            result.SKUCode.ShouldBe("1392654c94eb4df5");
            result.ProductionVolume.ShouldBe(844918964);
            result.DocStatus.ShouldBe((byte?)106);
            result.IsActive.ShouldBe(true);
            result.BreweryId.ShouldBe(1830742123);
            result.SKUId.ShouldBe(2116161047);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbBrewerySkuTempsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbBrewerySkuTempRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}