using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyMappings
{
    public abstract class TbCompanyMappingsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyMappingsAppService _tbCompanyMappingsAppService;
        private readonly IRepository<TbCompanyMapping, int> _tbCompanyMappingRepository;

        public TbCompanyMappingsAppServiceTests()
        {
            _tbCompanyMappingsAppService = GetRequiredService<ITbCompanyMappingsAppService>();
            _tbCompanyMappingRepository = GetRequiredService<IRepository<TbCompanyMapping, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyMappingsAppService.GetListAsync(new GetTbCompanyMappingsInput());

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
            var result = await _tbCompanyMappingsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyMappingCreateDto
            {
                CompanyId = 1580315792,
                CompanyTypeShareholdingCode = "a1c4745efec64ca2b1f983655c55186d07e29c52dba5498d816c2",
                CompanyTypesCode = "e4b7ca2421794eda",
                Note = "387a867",
                idCompanyTypeShareholdingCode = 1507794161,
                idCompanyTypesCode = 1196894008
            };

            // Act
            var serviceResult = await _tbCompanyMappingsAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyMappingRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1580315792);
            result.CompanyTypeShareholdingCode.ShouldBe("a1c4745efec64ca2b1f983655c55186d07e29c52dba5498d816c2");
            result.CompanyTypesCode.ShouldBe("e4b7ca2421794eda");
            result.Note.ShouldBe("387a867");
            result.idCompanyTypeShareholdingCode.ShouldBe(1507794161);
            result.idCompanyTypesCode.ShouldBe(1196894008);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyMappingUpdateDto()
            {
                CompanyId = 1813318450,
                CompanyTypeShareholdingCode = "d98425bd5a04497496bb3828969f7d0135d3f0d0429b49cc8c00f07092c3",
                CompanyTypesCode = "2d214bd2bfde4937a0dd235c7c8861ea7fb2099aafc646d7bdc5823d14f2be7e3033c41",
                Note = "ba544967dc1a468181d131ac7cd2bbdb3c4b4c1ab72547ceaa31c",
                idCompanyTypeShareholdingCode = 2084164646,
                idCompanyTypesCode = 244814990
            };

            // Act
            var serviceResult = await _tbCompanyMappingsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyMappingRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1813318450);
            result.CompanyTypeShareholdingCode.ShouldBe("d98425bd5a04497496bb3828969f7d0135d3f0d0429b49cc8c00f07092c3");
            result.CompanyTypesCode.ShouldBe("2d214bd2bfde4937a0dd235c7c8861ea7fb2099aafc646d7bdc5823d14f2be7e3033c41");
            result.Note.ShouldBe("ba544967dc1a468181d131ac7cd2bbdb3c4b4c1ab72547ceaa31c");
            result.idCompanyTypeShareholdingCode.ShouldBe(2084164646);
            result.idCompanyTypesCode.ShouldBe(244814990);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyMappingsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyMappingRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}