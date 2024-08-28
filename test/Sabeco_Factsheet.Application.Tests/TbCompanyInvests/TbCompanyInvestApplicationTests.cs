using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyInvests
{
    public abstract class TbCompanyInvestsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyInvestsAppService _tbCompanyInvestsAppService;
        private readonly IRepository<TbCompanyInvest, int> _tbCompanyInvestRepository;

        public TbCompanyInvestsAppServiceTests()
        {
            _tbCompanyInvestsAppService = GetRequiredService<ITbCompanyInvestsAppService>();
            _tbCompanyInvestRepository = GetRequiredService<IRepository<TbCompanyInvest, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyInvestsAppService.GetListAsync(new GetTbCompanyInvestsInput());

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
            var result = await _tbCompanyInvestsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyInvestCreateDto
            {
                CompanyId = 975304166,
                CompanyName = "66d83a66fde44c8da8dd634a367dafc18e2409b2198",
                Shares = 1136019906,
                Holding = 464180252,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbCompanyInvestsAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyInvestRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(975304166);
            result.CompanyName.ShouldBe("66d83a66fde44c8da8dd634a367dafc18e2409b2198");
            result.Shares.ShouldBe(1136019906);
            result.Holding.ShouldBe(464180252);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyInvestUpdateDto()
            {
                CompanyId = 1656474063,
                CompanyName = "d77bd1428ebb446f91",
                Shares = 1160095912,
                Holding = 558268186,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbCompanyInvestsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyInvestRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1656474063);
            result.CompanyName.ShouldBe("d77bd1428ebb446f91");
            result.Shares.ShouldBe(1160095912);
            result.Holding.ShouldBe(558268186);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyInvestsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyInvestRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}