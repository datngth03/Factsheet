using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyBranchs
{
    public abstract class TbCompanyBranchsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyBranchsAppService _tbCompanyBranchsAppService;
        private readonly IRepository<TbCompanyBranch, int> _tbCompanyBranchRepository;

        public TbCompanyBranchsAppServiceTests()
        {
            _tbCompanyBranchsAppService = GetRequiredService<ITbCompanyBranchsAppService>();
            _tbCompanyBranchRepository = GetRequiredService<IRepository<TbCompanyBranch, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyBranchsAppService.GetListAsync(new GetTbCompanyBranchsInput());

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
            var result = await _tbCompanyBranchsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyBranchCreateDto
            {
                CompanyId = 2113474092,
                BranchName = "2c7f4616b843",
                BranchAddress = "8e46310057754b4f9b3fde5d0385",
                BranchCode = "df92fddf279a4b1e8dab5795e4c6b791005430ac6f8d4dbeb8dedd068c8dd08cc4fbbdd20fc34158a4bb8e161f5e59bf8",
                ContactPerson = "6417c9f1cfbf4ce0ac18eb6d25b410c865beeb0509b942be80610a59c536905b77b",
                ContactPhone = "59427bda0263404d90742ac737eef22edbaab7712e5b495390ec98174fabf5396dab2f6bec544303830a58d12a507",
                Email = "9bf1b3",
                isActive = true
            };

            // Act
            var serviceResult = await _tbCompanyBranchsAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyBranchRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(2113474092);
            result.BranchName.ShouldBe("2c7f4616b843");
            result.BranchAddress.ShouldBe("8e46310057754b4f9b3fde5d0385");
            result.BranchCode.ShouldBe("df92fddf279a4b1e8dab5795e4c6b791005430ac6f8d4dbeb8dedd068c8dd08cc4fbbdd20fc34158a4bb8e161f5e59bf8");
            result.ContactPerson.ShouldBe("6417c9f1cfbf4ce0ac18eb6d25b410c865beeb0509b942be80610a59c536905b77b");
            result.ContactPhone.ShouldBe("59427bda0263404d90742ac737eef22edbaab7712e5b495390ec98174fabf5396dab2f6bec544303830a58d12a507");
            result.Email.ShouldBe("9bf1b3");
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyBranchUpdateDto()
            {
                CompanyId = 1938418886,
                BranchName = "d33c18e5f78341e5805c00849fc26e",
                BranchAddress = "d72c32c8210340698a811c4d46d82d38cff5d2bfa8c047b0",
                BranchCode = "9e34696b6",
                ContactPerson = "be49e4",
                ContactPhone = "cbe3c141acec46d89214143149ed15c5170a8ea1089f4c1fa28be21a43",
                Email = "dd673b83dda041ecb",
                isActive = true
            };

            // Act
            var serviceResult = await _tbCompanyBranchsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyBranchRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1938418886);
            result.BranchName.ShouldBe("d33c18e5f78341e5805c00849fc26e");
            result.BranchAddress.ShouldBe("d72c32c8210340698a811c4d46d82d38cff5d2bfa8c047b0");
            result.BranchCode.ShouldBe("9e34696b6");
            result.ContactPerson.ShouldBe("be49e4");
            result.ContactPhone.ShouldBe("cbe3c141acec46d89214143149ed15c5170a8ea1089f4c1fa28be21a43");
            result.Email.ShouldBe("dd673b83dda041ecb");
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyBranchsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyBranchRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}