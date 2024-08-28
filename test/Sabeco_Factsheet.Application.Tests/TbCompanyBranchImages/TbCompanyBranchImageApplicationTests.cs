using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyBranchImages
{
    public abstract class TbCompanyBranchImagesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyBranchImagesAppService _tbCompanyBranchImagesAppService;
        private readonly IRepository<TbCompanyBranchImage, int> _tbCompanyBranchImageRepository;

        public TbCompanyBranchImagesAppServiceTests()
        {
            _tbCompanyBranchImagesAppService = GetRequiredService<ITbCompanyBranchImagesAppService>();
            _tbCompanyBranchImageRepository = GetRequiredService<IRepository<TbCompanyBranchImage, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyBranchImagesAppService.GetListAsync(new GetTbCompanyBranchImagesInput());

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
            var result = await _tbCompanyBranchImagesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyBranchImageCreateDto
            {
                CompanyId = 276648397,
                BranchImage = "bd2d8807e44946b1a2e09cc997b22c9cc6b9e273f10d40e2a902f4054",
                ImageLink = "1371aff9383844508c4f6c820921e5683c002c22c1384d039fc3adda5e4bbfbcc9d9231f55a84614b4f5661b0c4",
                isActive = true
            };

            // Act
            var serviceResult = await _tbCompanyBranchImagesAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyBranchImageRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(276648397);
            result.BranchImage.ShouldBe("bd2d8807e44946b1a2e09cc997b22c9cc6b9e273f10d40e2a902f4054");
            result.ImageLink.ShouldBe("1371aff9383844508c4f6c820921e5683c002c22c1384d039fc3adda5e4bbfbcc9d9231f55a84614b4f5661b0c4");
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyBranchImageUpdateDto()
            {
                CompanyId = 146712030,
                BranchImage = "d52bcfcacec4468e9a5610a389a568a182f3b7d36c834959a5b5712",
                ImageLink = "0208abf4289d45fa85314aa44fe2b1914138846089f64c19a0a2fdfdd8521a9a3c0673242ec747b4ba556b0069dd",
                isActive = true
            };

            // Act
            var serviceResult = await _tbCompanyBranchImagesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyBranchImageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(146712030);
            result.BranchImage.ShouldBe("d52bcfcacec4468e9a5610a389a568a182f3b7d36c834959a5b5712");
            result.ImageLink.ShouldBe("0208abf4289d45fa85314aa44fe2b1914138846089f64c19a0a2fdfdd8521a9a3c0673242ec747b4ba556b0069dd");
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyBranchImagesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyBranchImageRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}