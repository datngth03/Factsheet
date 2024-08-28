using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbAdditionInfos
{
    public abstract class TbAdditionInfosAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbAdditionInfosAppService _tbAdditionInfosAppService;
        private readonly IRepository<TbAdditionInfo, int> _tbAdditionInfoRepository;

        public TbAdditionInfosAppServiceTests()
        {
            _tbAdditionInfosAppService = GetRequiredService<ITbAdditionInfosAppService>();
            _tbAdditionInfoRepository = GetRequiredService<IRepository<TbAdditionInfo, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbAdditionInfosAppService.GetListAsync(new GetTbAdditionInfosInput());

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
            var result = await _tbAdditionInfosAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbAdditionInfoCreateDto
            {
                CompanyId = 346941513,
                DocDate = new DateTime(2015, 11, 12),
                TypeOfGroup = "41afa6cfd44c4394a4339f437d2074d672afd9333e884a70b7",
                TypeOfEvent = "293c1a4785d14494ac6a1487416c36ea5e46229296894daabd0c994ab87bb5",
                Description = "7057c48d814444dba795fb0b73b90e0b0e09bc380a",
                NoOfDocument = "85f4cc21bb4a4bacbe0f1cb554784f3978b8320be11d46e58282be87947a",
                Remark = "68629cc1582f4e44b37f43f7c6d97af335b169743db843e0bced30a955dcd0a065272d8c92b34ba1",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbAdditionInfosAppService.CreateAsync(input);

            // Assert
            var result = await _tbAdditionInfoRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(346941513);
            result.DocDate.ShouldBe(new DateTime(2015, 11, 12));
            result.TypeOfGroup.ShouldBe("41afa6cfd44c4394a4339f437d2074d672afd9333e884a70b7");
            result.TypeOfEvent.ShouldBe("293c1a4785d14494ac6a1487416c36ea5e46229296894daabd0c994ab87bb5");
            result.Description.ShouldBe("7057c48d814444dba795fb0b73b90e0b0e09bc380a");
            result.NoOfDocument.ShouldBe("85f4cc21bb4a4bacbe0f1cb554784f3978b8320be11d46e58282be87947a");
            result.Remark.ShouldBe("68629cc1582f4e44b37f43f7c6d97af335b169743db843e0bced30a955dcd0a065272d8c92b34ba1");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbAdditionInfoUpdateDto()
            {
                CompanyId = 495807208,
                DocDate = new DateTime(2004, 4, 20),
                TypeOfGroup = "bf964bfa279e45a9a76ca7be49efb574e052c945bac44b09a1",
                TypeOfEvent = "8c7c2de378a04fa",
                Description = "9475e66819fe4836871587d6002629db6a5",
                NoOfDocument = "6541343117e24eeb847d12550feda5bef999daabe2224039adfaa56f25f4606212fdf6ed75ba40809",
                Remark = "5f3868b",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbAdditionInfosAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbAdditionInfoRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(495807208);
            result.DocDate.ShouldBe(new DateTime(2004, 4, 20));
            result.TypeOfGroup.ShouldBe("bf964bfa279e45a9a76ca7be49efb574e052c945bac44b09a1");
            result.TypeOfEvent.ShouldBe("8c7c2de378a04fa");
            result.Description.ShouldBe("9475e66819fe4836871587d6002629db6a5");
            result.NoOfDocument.ShouldBe("6541343117e24eeb847d12550feda5bef999daabe2224039adfaa56f25f4606212fdf6ed75ba40809");
            result.Remark.ShouldBe("5f3868b");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbAdditionInfosAppService.DeleteAsync(1);

            // Assert
            var result = await _tbAdditionInfoRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}