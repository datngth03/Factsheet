using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbInvests
{
    public abstract class TbInvestsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbInvestsAppService _tbInvestsAppService;
        private readonly IRepository<TbInvest, int> _tbInvestRepository;

        public TbInvestsAppServiceTests()
        {
            _tbInvestsAppService = GetRequiredService<ITbInvestsAppService>();
            _tbInvestRepository = GetRequiredService<IRepository<TbInvest, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbInvestsAppService.GetListAsync(new GetTbInvestsInput());

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
            var result = await _tbInvestsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbInvestCreateDto
            {
                BranchCode = "73b6feca8eb74eadb9cf",
                BranchId = 8531052,
                CompanyId = 2116066068,
                CompanyCode = "68b5386fc0094beca350",
                ShareNumTotal = 1259276757,
                ShareValueTotal = 1058421630,
                Note = "87b3c5b336eb406a8ef9f3e883e35c29dae6835b66c3460d83f1026dde12a53d677109da7d0b4797b84474295564ab19fed8de2d720349fcad658fea136b0d4b94b3a62ceb06404880bbf9fd3365bbed5f7e4831c2a34f098e28b938706d7d0ea57a88a425e34aa4bf082b872f2bbc4fadfed070d1644fbea03077f87e",
                DocStatus = 28,
                InvestGroup = true,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbInvestsAppService.CreateAsync(input);

            // Assert
            var result = await _tbInvestRepository.FindAsync(c => c.BranchCode == serviceResult.BranchCode);

            result.ShouldNotBe(null);
            result.BranchCode.ShouldBe("73b6feca8eb74eadb9cf");
            result.BranchId.ShouldBe(8531052);
            result.CompanyId.ShouldBe(2116066068);
            result.CompanyCode.ShouldBe("68b5386fc0094beca350");
            result.ShareNumTotal.ShouldBe(1259276757);
            result.ShareValueTotal.ShouldBe(1058421630);
            result.Note.ShouldBe("87b3c5b336eb406a8ef9f3e883e35c29dae6835b66c3460d83f1026dde12a53d677109da7d0b4797b84474295564ab19fed8de2d720349fcad658fea136b0d4b94b3a62ceb06404880bbf9fd3365bbed5f7e4831c2a34f098e28b938706d7d0ea57a88a425e34aa4bf082b872f2bbc4fadfed070d1644fbea03077f87e");
            result.DocStatus.ShouldBe((byte?)28);
            result.InvestGroup.ShouldBe(true);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbInvestUpdateDto()
            {
                BranchCode = "807937a7c56c4f809e22",
                BranchId = 1776663868,
                CompanyId = 77235596,
                CompanyCode = "ecd6db995feb4576b72b",
                ShareNumTotal = 691190098,
                ShareValueTotal = 739856451,
                Note = "fde239e6ce8040a9b00db2257eb34ca193f46fea9d114276b758ed3ccc9a83e6e99bf7f2dbea465d94ba7120e6eb17cc1380492ccfb24f948180d820fbf49b5f7097d696396d46f3ab8464a0f469ca0c4d575a8c9b6840be97e0a5080bd6d600de21f9e064c24b99819006375cb42eb9fbaf04074fae406d843220816a",
                DocStatus = 121,
                InvestGroup = true,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbInvestsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbInvestRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.BranchCode.ShouldBe("807937a7c56c4f809e22");
            result.BranchId.ShouldBe(1776663868);
            result.CompanyId.ShouldBe(77235596);
            result.CompanyCode.ShouldBe("ecd6db995feb4576b72b");
            result.ShareNumTotal.ShouldBe(691190098);
            result.ShareValueTotal.ShouldBe(739856451);
            result.Note.ShouldBe("fde239e6ce8040a9b00db2257eb34ca193f46fea9d114276b758ed3ccc9a83e6e99bf7f2dbea465d94ba7120e6eb17cc1380492ccfb24f948180d820fbf49b5f7097d696396d46f3ab8464a0f469ca0c4d575a8c9b6840be97e0a5080bd6d600de21f9e064c24b99819006375cb42eb9fbaf04074fae406d843220816a");
            result.DocStatus.ShouldBe((byte?)121);
            result.InvestGroup.ShouldBe(true);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbInvestsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbInvestRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}