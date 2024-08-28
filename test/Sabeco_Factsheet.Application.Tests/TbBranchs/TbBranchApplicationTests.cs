using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbBranchs
{
    public abstract class TbBranchsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbBranchsAppService _tbBranchsAppService;
        private readonly IRepository<TbBranch, int> _tbBranchRepository;

        public TbBranchsAppServiceTests()
        {
            _tbBranchsAppService = GetRequiredService<ITbBranchsAppService>();
            _tbBranchRepository = GetRequiredService<IRepository<TbBranch, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbBranchsAppService.GetListAsync(new GetTbBranchsInput());

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
            var result = await _tbBranchsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbBranchCreateDto
            {
                Code = "7903c92ca0",
                BriefName = "d35df3b650a844e4a4d4adbde4d90669ce06104f00424d36b1",
                Name = "75e354a36adb4ed18eb91049cb1e3640226c4c89331246a791db9670cb65b367f0a07bac591b4c83a93945efbc55dabb3c5ab0a5856a4962a985d095a6f99f7225f2cceec4134662aa76d9251bb2ad1c86bc874ea21343d6975999a733a22901986420fa4e2f46b2a5ea0b61fdb3832047f00ef4a6454dbfad556fafca",
                Name_EN = "edcaae16fe5948d7802e47c3f3dddcd3b2124aa9c4894c359cc022ea6d2a598913cf116d24534c12a67ed583947e0e3329e698ad887d4e5885f8089554436735ff8eceadc79e460c9d6690a4c5164a9a3032cbf0c8ea4c1fb5583829051ea1803b27646ba6ea499e9274ce914dd76b6b25b4772eb11d4d19830bde88ec",
                CompanyCode = "aa910a064478430989f1",
                Description = "cd80ac158b58416eade3581b15a395a85e67fa07e0c7411f8c8b8c48742b07c6f6396cb714c64e17aeaec25397d5b2682cf78e1fbde643ac8ddcfa32709f40d16298a70f63e64279b58e0d1b9c55c736680dddecc6d34540bdfa4f975acdab36acf30841089c4a7e987b8d64de2bc0f0b744d81659834f4ead1dbc8376",
                IsActive = true,
                Crt_Date = new DateTime(2004, 10, 22)
            };

            // Act
            var serviceResult = await _tbBranchsAppService.CreateAsync(input);

            // Assert
            var result = await _tbBranchRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("7903c92ca0");
            result.BriefName.ShouldBe("d35df3b650a844e4a4d4adbde4d90669ce06104f00424d36b1");
            result.Name.ShouldBe("75e354a36adb4ed18eb91049cb1e3640226c4c89331246a791db9670cb65b367f0a07bac591b4c83a93945efbc55dabb3c5ab0a5856a4962a985d095a6f99f7225f2cceec4134662aa76d9251bb2ad1c86bc874ea21343d6975999a733a22901986420fa4e2f46b2a5ea0b61fdb3832047f00ef4a6454dbfad556fafca");
            result.Name_EN.ShouldBe("edcaae16fe5948d7802e47c3f3dddcd3b2124aa9c4894c359cc022ea6d2a598913cf116d24534c12a67ed583947e0e3329e698ad887d4e5885f8089554436735ff8eceadc79e460c9d6690a4c5164a9a3032cbf0c8ea4c1fb5583829051ea1803b27646ba6ea499e9274ce914dd76b6b25b4772eb11d4d19830bde88ec");
            result.CompanyCode.ShouldBe("aa910a064478430989f1");
            result.Description.ShouldBe("cd80ac158b58416eade3581b15a395a85e67fa07e0c7411f8c8b8c48742b07c6f6396cb714c64e17aeaec25397d5b2682cf78e1fbde643ac8ddcfa32709f40d16298a70f63e64279b58e0d1b9c55c736680dddecc6d34540bdfa4f975acdab36acf30841089c4a7e987b8d64de2bc0f0b744d81659834f4ead1dbc8376");
            result.IsActive.ShouldBe(true);
            result.Crt_Date.ShouldBe(new DateTime(2004, 10, 22));
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbBranchUpdateDto()
            {
                Code = "cc645fc0ce",
                BriefName = "be0fdb4af74b4820b914d7677996b984c196d7fa73944f6185",
                Name = "31162ed7c261427f921c050d527959985d25a5b6770f4934b577d98d96df26db0aef8ace6d9647848d21831a1b7bb2fa153ee6bbc0414c6db6caaba8e7cdb9871e77e8b455344cebad51c6631e3b171f44f49e19576b49bc95da2b643360b69f4762e2b9e553485fb18850df865bb3109811e2eedbe442fe9d05a20f4d",
                Name_EN = "c83a51a390f849489067c9fcdf4faaa53d0332ae87c84279b51bc780f49fa5450e6c729b273c49efb6b052e6d05f14557dfe4f4f32fd44dbb0ac7d6c22a242e97ee0537e7e92441f9bb2d783ef45e14630ce8058d58745c9aff4f5674096e5841385433070a64aad852ff05cd74b55cc40902c965ede4954b8930f4e1f",
                CompanyCode = "50b84758fd9147f784b6",
                Description = "f2ec537615424bcaa82f907407fc35d5aafa2f22395d4caaba5f8846bb9cd1378a43ff88595a406b8ee186f066911d094d41161328684226bd0d57c9dc657cdca145511c1ca944cdb33b3b6c040e21cec1b9272383ef4a609b20d56c5b1a879fb24c256e5bad4a4a84222c634f77416b01bdd4783fdd4bdc836e3c2692",
                IsActive = true,
                Crt_Date = new DateTime(2011, 1, 4)
            };

            // Act
            var serviceResult = await _tbBranchsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbBranchRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("cc645fc0ce");
            result.BriefName.ShouldBe("be0fdb4af74b4820b914d7677996b984c196d7fa73944f6185");
            result.Name.ShouldBe("31162ed7c261427f921c050d527959985d25a5b6770f4934b577d98d96df26db0aef8ace6d9647848d21831a1b7bb2fa153ee6bbc0414c6db6caaba8e7cdb9871e77e8b455344cebad51c6631e3b171f44f49e19576b49bc95da2b643360b69f4762e2b9e553485fb18850df865bb3109811e2eedbe442fe9d05a20f4d");
            result.Name_EN.ShouldBe("c83a51a390f849489067c9fcdf4faaa53d0332ae87c84279b51bc780f49fa5450e6c729b273c49efb6b052e6d05f14557dfe4f4f32fd44dbb0ac7d6c22a242e97ee0537e7e92441f9bb2d783ef45e14630ce8058d58745c9aff4f5674096e5841385433070a64aad852ff05cd74b55cc40902c965ede4954b8930f4e1f");
            result.CompanyCode.ShouldBe("50b84758fd9147f784b6");
            result.Description.ShouldBe("f2ec537615424bcaa82f907407fc35d5aafa2f22395d4caaba5f8846bb9cd1378a43ff88595a406b8ee186f066911d094d41161328684226bd0d57c9dc657cdca145511c1ca944cdb33b3b6c040e21cec1b9272383ef4a609b20d56c5b1a879fb24c256e5bad4a4a84222c634f77416b01bdd4783fdd4bdc836e3c2692");
            result.IsActive.ShouldBe(true);
            result.Crt_Date.ShouldBe(new DateTime(2011, 1, 4));
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbBranchsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbBranchRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}