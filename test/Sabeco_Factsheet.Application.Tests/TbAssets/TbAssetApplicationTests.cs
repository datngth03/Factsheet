using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbAssets
{
    public abstract class TbAssetsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbAssetsAppService _tbAssetsAppService;
        private readonly IRepository<TbAsset, int> _tbAssetRepository;

        public TbAssetsAppServiceTests()
        {
            _tbAssetsAppService = GetRequiredService<ITbAssetsAppService>();
            _tbAssetRepository = GetRequiredService<IRepository<TbAsset, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbAssetsAppService.GetListAsync(new GetTbAssetsInput());

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
            var result = await _tbAssetsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbAssetCreateDto
            {
                CompanyId = 412437254,
                AssetType = "c7f1ce8268a04177974131ee3eca59ff9693a4e522ac4309bf7d7fb2289923f2913b91217af049d88b3e0f7cc2030b3586fb2d3f4d8543f1848e73fec9a7419a978cc3789c224cd0b691b7",
                AssetItem = "9cd78fdda3374ec8912898fec85d2165a0429f2b24d04cbb918ab705ff31f551dbfacf9af2604d09a827ddbe5aa425cbcac5bedf807841f4a4ebec4d02233ebcbe2da2674b594b9d90c0c546e552151ad3b222f0905e4e0898203e211fbdf5a2371b4a472cf94649ac91143d82dc0747c534c7ba0bc44ab7a3212ee087",
                AssetAddress = "6d7a20f1831a434998e6cdefd494cc432d22fa0743a44adc9efd0d89f0405a92b5075adf76aa4abb916e007fff46f4e156033ed27b3042d2bebd23c6184592b6dfd759afbace42cb866dd5f3f3ce04ecf8067a5a502d4d708379f51174743456dc175aeb330d4a5c8fdadf5576f9cbde2204426b416f4093afe6cacb68",
                Quantity = 1913984596,
                DocNo = "fb3ccdf4c92d4a7aa3d7ac7192a547aa464ab76e6e2c4fb7b0",
                DocDate = new DateTime(2018, 6, 20),
                ExpireDate = new DateTime(2011, 3, 8),
                Description = "19984d06138e482f88391c7c8bf044f057e03385d0284fc29f1f7b7e52ad07cf9661be4ce41241fa86bb7a74ac301e4136d9315433e046b5b15d412db0bf177487fdd621558147eda44ad98f2ef5bc4bb9695a65c79b45f5a54288288077480946058a1aef4b49e4876daf543a6328972201d5b853724310bf8c49f047",
                DocStatus = 11,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbAssetsAppService.CreateAsync(input);

            // Assert
            var result = await _tbAssetRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(412437254);
            result.AssetType.ShouldBe("c7f1ce8268a04177974131ee3eca59ff9693a4e522ac4309bf7d7fb2289923f2913b91217af049d88b3e0f7cc2030b3586fb2d3f4d8543f1848e73fec9a7419a978cc3789c224cd0b691b7");
            result.AssetItem.ShouldBe("9cd78fdda3374ec8912898fec85d2165a0429f2b24d04cbb918ab705ff31f551dbfacf9af2604d09a827ddbe5aa425cbcac5bedf807841f4a4ebec4d02233ebcbe2da2674b594b9d90c0c546e552151ad3b222f0905e4e0898203e211fbdf5a2371b4a472cf94649ac91143d82dc0747c534c7ba0bc44ab7a3212ee087");
            result.AssetAddress.ShouldBe("6d7a20f1831a434998e6cdefd494cc432d22fa0743a44adc9efd0d89f0405a92b5075adf76aa4abb916e007fff46f4e156033ed27b3042d2bebd23c6184592b6dfd759afbace42cb866dd5f3f3ce04ecf8067a5a502d4d708379f51174743456dc175aeb330d4a5c8fdadf5576f9cbde2204426b416f4093afe6cacb68");
            result.Quantity.ShouldBe(1913984596);
            result.DocNo.ShouldBe("fb3ccdf4c92d4a7aa3d7ac7192a547aa464ab76e6e2c4fb7b0");
            result.DocDate.ShouldBe(new DateTime(2018, 6, 20));
            result.ExpireDate.ShouldBe(new DateTime(2011, 3, 8));
            result.Description.ShouldBe("19984d06138e482f88391c7c8bf044f057e03385d0284fc29f1f7b7e52ad07cf9661be4ce41241fa86bb7a74ac301e4136d9315433e046b5b15d412db0bf177487fdd621558147eda44ad98f2ef5bc4bb9695a65c79b45f5a54288288077480946058a1aef4b49e4876daf543a6328972201d5b853724310bf8c49f047");
            result.DocStatus.ShouldBe((byte?)11);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbAssetUpdateDto()
            {
                CompanyId = 1987756594,
                AssetType = "24df3435856b42149331b7c7acca21a3619dbed10cfa4a598af3a16847666fe0fbc2f7f6d1e042f0b6da2ecd61e6b371beac413434824c0aa5ed5eaf27c0271baaa8e15b5f96422b866fd6",
                AssetItem = "f89267ca94fb485ead03762919692a7f745434bf3d404b7f820f018be132bd0cb3b5cf88e15f4e3989f950443a07506fe81aa47c9ea5450fba3e2729fc3ff5256e64e4a4c1a84a5da80a3fc28762a3e4daf48364dfa745758c7939aba0c778ecbce5a2dd93304704b6a573a6cf40f0dbe11cb9de1cf141038bea357ac4",
                AssetAddress = "943b62d35ac54010b747493eb31d8dc8fc48e7ac9a7d41da93d932e9e9aebedae9b51305ca554b748362e3a2ef698bdc10ab47210930445994b46e8d8cbe30be6b2ae381ffe5452e842269d73ba71da921a6071c8b0a4f11a48d8a7ee073f262b6088bbee3c34e1897679946ab8b65b4e694dd0c276f4cb494e0e8bd8b",
                Quantity = 125350908,
                DocNo = "09950e6c7c8f4aaab518e1d6c2d82cb0ffa1c40d86524c9383",
                DocDate = new DateTime(2016, 2, 2),
                ExpireDate = new DateTime(2001, 1, 18),
                Description = "078e42d4ebe74d11945a50fa9f07664e1084b1c8b9bf4219aa62e79c40691f2b77c8008e9dae442781439fd5c7c2866bd75c73ab8957495882434c68cefbc63b74e1627a808546d3b2110d4d257235a0f00eb3f2133147f78aae08564463300b81e6514c7ddb402583264f1b5bb8ee7e2ade1fbe12ac4de7947be972da",
                DocStatus = 59,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbAssetsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbAssetRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1987756594);
            result.AssetType.ShouldBe("24df3435856b42149331b7c7acca21a3619dbed10cfa4a598af3a16847666fe0fbc2f7f6d1e042f0b6da2ecd61e6b371beac413434824c0aa5ed5eaf27c0271baaa8e15b5f96422b866fd6");
            result.AssetItem.ShouldBe("f89267ca94fb485ead03762919692a7f745434bf3d404b7f820f018be132bd0cb3b5cf88e15f4e3989f950443a07506fe81aa47c9ea5450fba3e2729fc3ff5256e64e4a4c1a84a5da80a3fc28762a3e4daf48364dfa745758c7939aba0c778ecbce5a2dd93304704b6a573a6cf40f0dbe11cb9de1cf141038bea357ac4");
            result.AssetAddress.ShouldBe("943b62d35ac54010b747493eb31d8dc8fc48e7ac9a7d41da93d932e9e9aebedae9b51305ca554b748362e3a2ef698bdc10ab47210930445994b46e8d8cbe30be6b2ae381ffe5452e842269d73ba71da921a6071c8b0a4f11a48d8a7ee073f262b6088bbee3c34e1897679946ab8b65b4e694dd0c276f4cb494e0e8bd8b");
            result.Quantity.ShouldBe(125350908);
            result.DocNo.ShouldBe("09950e6c7c8f4aaab518e1d6c2d82cb0ffa1c40d86524c9383");
            result.DocDate.ShouldBe(new DateTime(2016, 2, 2));
            result.ExpireDate.ShouldBe(new DateTime(2001, 1, 18));
            result.Description.ShouldBe("078e42d4ebe74d11945a50fa9f07664e1084b1c8b9bf4219aa62e79c40691f2b77c8008e9dae442781439fd5c7c2866bd75c73ab8957495882434c68cefbc63b74e1627a808546d3b2110d4d257235a0f00eb3f2133147f78aae08564463300b81e6514c7ddb402583264f1b5bb8ee7e2ade1fbe12ac4de7947be972da");
            result.DocStatus.ShouldBe((byte?)59);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbAssetsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbAssetRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}