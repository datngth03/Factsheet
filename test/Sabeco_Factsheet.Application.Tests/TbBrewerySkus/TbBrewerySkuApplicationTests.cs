using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbBrewerySkus
{
    public abstract class TbBrewerySkusAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbBrewerySkusAppService _tbBrewerySkusAppService;
        private readonly IRepository<TbBrewerySku, int> _tbBrewerySkuRepository;

        public TbBrewerySkusAppServiceTests()
        {
            _tbBrewerySkusAppService = GetRequiredService<ITbBrewerySkusAppService>();
            _tbBrewerySkuRepository = GetRequiredService<IRepository<TbBrewerySku, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbBrewerySkusAppService.GetListAsync(new GetTbBrewerySkusInput());

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
            var result = await _tbBrewerySkusAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbBrewerySkuCreateDto
            {
                Year = 1238182974,
                BreweryCode = "ea5b3e57f6234641a59a",
                SKUCode = "da0e7c5e64974322",
                ProductionVolume = 288744232,
                DocStatus = 45,
                IsActive = true,
                BreweryId = 158928240,
                SKUId = 1760307168
            };

            // Act
            var serviceResult = await _tbBrewerySkusAppService.CreateAsync(input);

            // Assert
            var result = await _tbBrewerySkuRepository.FindAsync(c => c.Year == serviceResult.Year);

            result.ShouldNotBe(null);
            result.Year.ShouldBe(1238182974);
            result.BreweryCode.ShouldBe("ea5b3e57f6234641a59a");
            result.SKUCode.ShouldBe("da0e7c5e64974322");
            result.ProductionVolume.ShouldBe(288744232);
            result.DocStatus.ShouldBe((byte?)45);
            result.IsActive.ShouldBe(true);
            result.BreweryId.ShouldBe(158928240);
            result.SKUId.ShouldBe(1760307168);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbBrewerySkuUpdateDto()
            {
                Year = 416056534,
                BreweryCode = "c42dc79cbaef453a9abe",
                SKUCode = "bd95a94dde1246a4",
                ProductionVolume = 1592711373,
                DocStatus = 87,
                IsActive = true,
                BreweryId = 1960219357,
                SKUId = 775435605
            };

            // Act
            var serviceResult = await _tbBrewerySkusAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbBrewerySkuRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Year.ShouldBe(416056534);
            result.BreweryCode.ShouldBe("c42dc79cbaef453a9abe");
            result.SKUCode.ShouldBe("bd95a94dde1246a4");
            result.ProductionVolume.ShouldBe(1592711373);
            result.DocStatus.ShouldBe((byte?)87);
            result.IsActive.ShouldBe(true);
            result.BreweryId.ShouldBe(1960219357);
            result.SKUId.ShouldBe(775435605);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbBrewerySkusAppService.DeleteAsync(1);

            // Assert
            var result = await _tbBrewerySkuRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}