using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbNationalities
{
    public abstract class TbNationalitiesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbNationalitiesAppService _tbNationalitiesAppService;
        private readonly IRepository<TbNationality, int> _tbNationalityRepository;

        public TbNationalitiesAppServiceTests()
        {
            _tbNationalitiesAppService = GetRequiredService<ITbNationalitiesAppService>();
            _tbNationalityRepository = GetRequiredService<IRepository<TbNationality, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbNationalitiesAppService.GetListAsync(new GetTbNationalitiesInput());

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
            var result = await _tbNationalitiesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbNationalityCreateDto
            {
                Code = "c40",
                Code2 = "4a",
                Name_en = "59e0ee8b33a9452a9d745e5f146ca2f2b8d5da92c5d24da7b4cd38eac31ca41a45dbdd4cd89d4ae0b97663cd3e66ed425cb615d1f8fb4054b20c161de610c990b494e6cc33634c84b9fe3064ee71d4504790e06bb81e437f8848131d6fecc23d4f02c5bf81ee4c4daaa3f4944ea57766e495ae05aa674a7fafc4ed9b81d269d",
                Name_vn = "c22895ff5f6244ada2e5a15f166c4f1993345605c3464b58b524f717cca15c312cf0b26f25ef4c44a616cdb93d2655e6cc1cea094f714dffa93d56105d3de7bfbba1003632964d05afb8b6f77e0dd4c66242c8243df9446584c1ac2372f0084225dd6b0d6f3543d6aec7badf00eb5ad795befa70a9694bfabf1e5269e0add40",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbNationalitiesAppService.CreateAsync(input);

            // Assert
            var result = await _tbNationalityRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("c40");
            result.Code2.ShouldBe("4a");
            result.Name_en.ShouldBe("59e0ee8b33a9452a9d745e5f146ca2f2b8d5da92c5d24da7b4cd38eac31ca41a45dbdd4cd89d4ae0b97663cd3e66ed425cb615d1f8fb4054b20c161de610c990b494e6cc33634c84b9fe3064ee71d4504790e06bb81e437f8848131d6fecc23d4f02c5bf81ee4c4daaa3f4944ea57766e495ae05aa674a7fafc4ed9b81d269d");
            result.Name_vn.ShouldBe("c22895ff5f6244ada2e5a15f166c4f1993345605c3464b58b524f717cca15c312cf0b26f25ef4c44a616cdb93d2655e6cc1cea094f714dffa93d56105d3de7bfbba1003632964d05afb8b6f77e0dd4c66242c8243df9446584c1ac2372f0084225dd6b0d6f3543d6aec7badf00eb5ad795befa70a9694bfabf1e5269e0add40");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbNationalityUpdateDto()
            {
                Code = "0a6",
                Code2 = "a1",
                Name_en = "d46709f0405f441f8f3b40493ac5e0cb574c98e81d884a0ca5f333ee3017a824ac19d8a69e8f4a4eaec722b648b8f4a3514efb94ea3a4eb29121183043b30070eae3390351754273aeeb80e43428661d92eb608ac4124592aa6e0cd111afe466e7d4fc8cea174fb0ae8d983319032f70ccd88d682b484858908fd7add070b56",
                Name_vn = "1bd57729209c46da8aa3c3028f7a90d5a27d391f33e2422daf98e35650231b862ed83064c9214b32a5a4665e4567f5c2e2dd7ef5682a437e83fe3a77f19dca15a4673880fdfd47ec929490f7e638a6a2c3b9ef50608343e6a19870a76074ec1a57b0403efb9f49c5b7179b5dd0459f14a705a056bdf447d6aa5f2e0f1ff7094",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbNationalitiesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbNationalityRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("0a6");
            result.Code2.ShouldBe("a1");
            result.Name_en.ShouldBe("d46709f0405f441f8f3b40493ac5e0cb574c98e81d884a0ca5f333ee3017a824ac19d8a69e8f4a4eaec722b648b8f4a3514efb94ea3a4eb29121183043b30070eae3390351754273aeeb80e43428661d92eb608ac4124592aa6e0cd111afe466e7d4fc8cea174fb0ae8d983319032f70ccd88d682b484858908fd7add070b56");
            result.Name_vn.ShouldBe("1bd57729209c46da8aa3c3028f7a90d5a27d391f33e2422daf98e35650231b862ed83064c9214b32a5a4665e4567f5c2e2dd7ef5682a437e83fe3a77f19dca15a4673880fdfd47ec929490f7e638a6a2c3b9ef50608343e6a19870a76074ec1a57b0403efb9f49c5b7179b5dd0459f14a705a056bdf447d6aa5f2e0f1ff7094");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbNationalitiesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbNationalityRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}