using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public abstract class TbCompanyMemberCouncilTermsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyMemberCouncilTermsAppService _tbCompanyMemberCouncilTermsAppService;
        private readonly IRepository<TbCompanyMemberCouncilTerm, int> _tbCompanyMemberCouncilTermRepository;

        public TbCompanyMemberCouncilTermsAppServiceTests()
        {
            _tbCompanyMemberCouncilTermsAppService = GetRequiredService<ITbCompanyMemberCouncilTermsAppService>();
            _tbCompanyMemberCouncilTermRepository = GetRequiredService<IRepository<TbCompanyMemberCouncilTerm, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyMemberCouncilTermsAppService.GetListAsync(new GetTbCompanyMemberCouncilTermsInput());

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
            var result = await _tbCompanyMemberCouncilTermsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyMemberCouncilTermCreateDto
            {
                CompanyId = 1535835697,
                TermFrom = 1218442949,
                TermEnd = 842186409
            };

            // Act
            var serviceResult = await _tbCompanyMemberCouncilTermsAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyMemberCouncilTermRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1535835697);
            result.TermFrom.ShouldBe(1218442949);
            result.TermEnd.ShouldBe(842186409);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyMemberCouncilTermUpdateDto()
            {
                CompanyId = 1773157486,
                TermFrom = 1502216794,
                TermEnd = 971922652
            };

            // Act
            var serviceResult = await _tbCompanyMemberCouncilTermsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyMemberCouncilTermRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1773157486);
            result.TermFrom.ShouldBe(1502216794);
            result.TermEnd.ShouldBe(971922652);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyMemberCouncilTermsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyMemberCouncilTermRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}