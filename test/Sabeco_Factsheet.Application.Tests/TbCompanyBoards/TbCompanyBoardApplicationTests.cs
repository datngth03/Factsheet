using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyBoards
{
    public abstract class TbCompanyBoardsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyBoardsAppService _tbCompanyBoardsAppService;
        private readonly IRepository<TbCompanyBoard, int> _tbCompanyBoardRepository;

        public TbCompanyBoardsAppServiceTests()
        {
            _tbCompanyBoardsAppService = GetRequiredService<ITbCompanyBoardsAppService>();
            _tbCompanyBoardRepository = GetRequiredService<IRepository<TbCompanyBoard, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyBoardsAppService.GetListAsync(new GetTbCompanyBoardsInput());

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
            var result = await _tbCompanyBoardsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyBoardCreateDto
            {
                BranchCode = "81f2cbca25",
                CompanyCode = "70c92cb049f34b84b61e",
                PersonCode = "6c3ea0d8117246569647",
                FromDate = new DateTime(2007, 9, 9),
                ToDate = new DateTime(2013, 3, 26),
                PositionCode = "dc3f05c6b07e448c8a1e",
                PersonalValue = 1998545663,
                OwnerValue = 1486382740,
                Note = "0cef1c9b56ac44d8bb19d719174d52eb5f3b6e814dad4a6bb94eca5f21e75a7b5f09e652fd6942c5936a0e5e2462c7bf4ea3b58e6d22432eb16d4f5e12d1a5c3a6d2af1b39e447d2b409bda1f29294fbb3c3aa36a22449fca4d2aa17f56d27b43a49dfa2cdb942599c0c666ef545329140d67e1fad474596a3d4409a84",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbCompanyBoardsAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyBoardRepository.FindAsync(c => c.BranchCode == serviceResult.BranchCode);

            result.ShouldNotBe(null);
            result.BranchCode.ShouldBe("81f2cbca25");
            result.CompanyCode.ShouldBe("70c92cb049f34b84b61e");
            result.PersonCode.ShouldBe("6c3ea0d8117246569647");
            result.FromDate.ShouldBe(new DateTime(2007, 9, 9));
            result.ToDate.ShouldBe(new DateTime(2013, 3, 26));
            result.PositionCode.ShouldBe("dc3f05c6b07e448c8a1e");
            result.PersonalValue.ShouldBe(1998545663);
            result.OwnerValue.ShouldBe(1486382740);
            result.Note.ShouldBe("0cef1c9b56ac44d8bb19d719174d52eb5f3b6e814dad4a6bb94eca5f21e75a7b5f09e652fd6942c5936a0e5e2462c7bf4ea3b58e6d22432eb16d4f5e12d1a5c3a6d2af1b39e447d2b409bda1f29294fbb3c3aa36a22449fca4d2aa17f56d27b43a49dfa2cdb942599c0c666ef545329140d67e1fad474596a3d4409a84");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyBoardUpdateDto()
            {
                BranchCode = "2c64ee3271",
                CompanyCode = "302d85cf2e064723ba10",
                PersonCode = "b3903b83549e4d058388",
                FromDate = new DateTime(2009, 3, 9),
                ToDate = new DateTime(2013, 11, 1),
                PositionCode = "3aeb96cc375b40ab8815",
                PersonalValue = 1571446359,
                OwnerValue = 1380727087,
                Note = "5ed34cb758c54748ac06318a85de1f183989340cacf54ab097cd2afe6d101077b338443f20dd4dc2b857b34ff150466985fc0c54cf3e46e6becc6d93541764235f59250598384b34ad8b24307c2d5c484af8ceec4a1540cba3d77a66156b5acbd0970408d2234965acb95d481910883e448a378d492c470fa58fd0bc66",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbCompanyBoardsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyBoardRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.BranchCode.ShouldBe("2c64ee3271");
            result.CompanyCode.ShouldBe("302d85cf2e064723ba10");
            result.PersonCode.ShouldBe("b3903b83549e4d058388");
            result.FromDate.ShouldBe(new DateTime(2009, 3, 9));
            result.ToDate.ShouldBe(new DateTime(2013, 11, 1));
            result.PositionCode.ShouldBe("3aeb96cc375b40ab8815");
            result.PersonalValue.ShouldBe(1571446359);
            result.OwnerValue.ShouldBe(1380727087);
            result.Note.ShouldBe("5ed34cb758c54748ac06318a85de1f183989340cacf54ab097cd2afe6d101077b338443f20dd4dc2b857b34ff150466985fc0c54cf3e46e6becc6d93541764235f59250598384b34ad8b24307c2d5c484af8ceec4a1540cba3d77a66156b5acbd0970408d2234965acb95d481910883e448a378d492c470fa58fd0bc66");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyBoardsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyBoardRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}