using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public abstract class TbUserMappingCompaniesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbUserMappingCompaniesAppService _tbUserMappingCompaniesAppService;
        private readonly IRepository<TbUserMappingCompany, int> _tbUserMappingCompanyRepository;

        public TbUserMappingCompaniesAppServiceTests()
        {
            _tbUserMappingCompaniesAppService = GetRequiredService<ITbUserMappingCompaniesAppService>();
            _tbUserMappingCompanyRepository = GetRequiredService<IRepository<TbUserMappingCompany, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbUserMappingCompaniesAppService.GetListAsync(new GetTbUserMappingCompaniesInput());

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
            var result = await _tbUserMappingCompaniesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbUserMappingCompanyCreateDto
            {
                userid = 754989998,
                companyid = 1742251181,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbUserMappingCompaniesAppService.CreateAsync(input);

            // Assert
            var result = await _tbUserMappingCompanyRepository.FindAsync(c => c.userid == serviceResult.userid);

            result.ShouldNotBe(null);
            result.userid.ShouldBe(754989998);
            result.companyid.ShouldBe(1742251181);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbUserMappingCompanyUpdateDto()
            {
                userid = 984138365,
                companyid = 384079856,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbUserMappingCompaniesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbUserMappingCompanyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.userid.ShouldBe(984138365);
            result.companyid.ShouldBe(384079856);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbUserMappingCompaniesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbUserMappingCompanyRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}