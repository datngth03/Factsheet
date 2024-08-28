using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbBreweryImages
{
    public abstract class TbBreweryImagesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbBreweryImagesAppService _tbBreweryImagesAppService;
        private readonly IRepository<TbBreweryImage, int> _tbBreweryImageRepository;

        public TbBreweryImagesAppServiceTests()
        {
            _tbBreweryImagesAppService = GetRequiredService<ITbBreweryImagesAppService>();
            _tbBreweryImageRepository = GetRequiredService<IRepository<TbBreweryImage, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbBreweryImagesAppService.GetListAsync(new GetTbBreweryImagesInput());

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
            var result = await _tbBreweryImagesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbBreweryImageCreateDto
            {
                CompanyId = 1936653726,
                BreweryImage = "cabc38a87bd243c2ad976b4914fe0eff8abaa2c56d1c4864bef3a8cbd270a0a8075af1f",
                ImageLink = "62881cc7a0e245f18bce76df220e",
                isActive = true
            };

            // Act
            var serviceResult = await _tbBreweryImagesAppService.CreateAsync(input);

            // Assert
            var result = await _tbBreweryImageRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1936653726);
            result.BreweryImage.ShouldBe("cabc38a87bd243c2ad976b4914fe0eff8abaa2c56d1c4864bef3a8cbd270a0a8075af1f");
            result.ImageLink.ShouldBe("62881cc7a0e245f18bce76df220e");
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbBreweryImageUpdateDto()
            {
                CompanyId = 296283942,
                BreweryImage = "221445999ea0472b",
                ImageLink = "4a5662660af24854912065fb8d56ae1e4a275de6206443bd912a314f96afb0789c3f291f8e6b",
                isActive = true
            };

            // Act
            var serviceResult = await _tbBreweryImagesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbBreweryImageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(296283942);
            result.BreweryImage.ShouldBe("221445999ea0472b");
            result.ImageLink.ShouldBe("4a5662660af24854912065fb8d56ae1e4a275de6206443bd912a314f96afb0789c3f291f8e6b");
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbBreweryImagesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbBreweryImageRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}