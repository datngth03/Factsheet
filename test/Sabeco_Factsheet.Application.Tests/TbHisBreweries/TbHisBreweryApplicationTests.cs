using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbHisBreweries
{
    public abstract class TbHisBreweriesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbHisBreweriesAppService _tbHisBreweriesAppService;
        private readonly IRepository<TbHisBrewery, int> _tbHisBreweryRepository;

        public TbHisBreweriesAppServiceTests()
        {
            _tbHisBreweriesAppService = GetRequiredService<ITbHisBreweriesAppService>();
            _tbHisBreweryRepository = GetRequiredService<IRepository<TbHisBrewery, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbHisBreweriesAppService.GetListAsync(new GetTbHisBreweriesInput());

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
            var result = await _tbHisBreweriesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbHisBreweryCreateDto
            {
                IsSendMail = true,
                DateSendMail = new DateTime(2003, 8, 23),
                InsertDate = new DateTime(2009, 8, 18),
                Type = 1800142978,
                IdBrewery = 1335969684,
                BreweryName = "c3ee1f204a7f439f8290ff0a1a6f88fbe2e25f3a358544fba970aa2bb86497b2f5bd8b74c8d74b199f28cd7e88c0de9a808f9fdbb9064a848cba723971f4d7bec34d2e25a0724efe8b1a66b39c371ed5cab70ac56c3d47e1b1ace768ce32ea58526aa978b598451c82a6c5681faa107e0c506ea7052b41879f6b457f52",
                BreweryName_EN = "96cdb1d6dc064f469aaee10ffa47e94727e877396ec649399e1693c5612ad5330506500293a848fb9bf39dcb9c0505cae6046a4f165143ecbe815343738bd0e86f3a011421be494da5853a0a6bf344aae2ecad2645a64dd8a5b8d70522ce2969a466c5c87f7145d9ba1561efb1e3003f2e967c2ba8fd40ab84573feb5b",
                BreweryAdress = "a377444f8c34474db9fe6d9359bd4e83e15aeb6a30834af881ad739cbab97ebb24b33f8474664e52b12146952ed3d155d1",
                BriefName = "8ede058cfb884adf911ef",
                CompanyId = 1693182223,
                CapacityVolume = 207899956,
                DeliveryVolume = 1428971819,
                Note = "9ee22c3bbb7c41e69d5acfd92bbf02da17d752b75a7d4fb4987",
                DocStatus = 1,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbHisBreweriesAppService.CreateAsync(input);

            // Assert
            var result = await _tbHisBreweryRepository.FindAsync(c => c.IsSendMail == serviceResult.IsSendMail);

            result.ShouldNotBe(null);
            result.IsSendMail.ShouldBe(true);
            result.DateSendMail.ShouldBe(new DateTime(2003, 8, 23));
            result.InsertDate.ShouldBe(new DateTime(2009, 8, 18));
            result.Type.ShouldBe(1800142978);
            result.IdBrewery.ShouldBe(1335969684);
            result.BreweryName.ShouldBe("c3ee1f204a7f439f8290ff0a1a6f88fbe2e25f3a358544fba970aa2bb86497b2f5bd8b74c8d74b199f28cd7e88c0de9a808f9fdbb9064a848cba723971f4d7bec34d2e25a0724efe8b1a66b39c371ed5cab70ac56c3d47e1b1ace768ce32ea58526aa978b598451c82a6c5681faa107e0c506ea7052b41879f6b457f52");
            result.BreweryName_EN.ShouldBe("96cdb1d6dc064f469aaee10ffa47e94727e877396ec649399e1693c5612ad5330506500293a848fb9bf39dcb9c0505cae6046a4f165143ecbe815343738bd0e86f3a011421be494da5853a0a6bf344aae2ecad2645a64dd8a5b8d70522ce2969a466c5c87f7145d9ba1561efb1e3003f2e967c2ba8fd40ab84573feb5b");
            result.BreweryAdress.ShouldBe("a377444f8c34474db9fe6d9359bd4e83e15aeb6a30834af881ad739cbab97ebb24b33f8474664e52b12146952ed3d155d1");
            result.BriefName.ShouldBe("8ede058cfb884adf911ef");
            result.CompanyId.ShouldBe(1693182223);
            result.CapacityVolume.ShouldBe(207899956);
            result.DeliveryVolume.ShouldBe(1428971819);
            result.Note.ShouldBe("9ee22c3bbb7c41e69d5acfd92bbf02da17d752b75a7d4fb4987");
            result.DocStatus.ShouldBe((byte?)1);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbHisBreweryUpdateDto()
            {
                IsSendMail = true,
                DateSendMail = new DateTime(2004, 10, 22),
                InsertDate = new DateTime(2019, 10, 4),
                Type = 2136360371,
                IdBrewery = 306739806,
                BreweryName = "a7609403fd914a0e8a8c449381000a0c9b24cd6e66504f5d9ee0c03b17190d6a3e839090aa774aacbf898afbcbbd637759c75f5a73b24fae86be5df00555c52152a1fb8ffeef450692ad1a18579345c86befc7577f3d4dfd8e9f9b454c52e50b9f3b5272b62a4fa7bb381e2d5189d775736582f7a9cd4938b465d2d5cc",
                BreweryName_EN = "e4a502cae77d450baa11fec6b6e55dcc154dd87fbca140b98dcf58a72ee2b84d68a141cb2e58410f841a262aefd39e7cf2a3a143c6704031882818c2f5c3b1e113935e5203154db4b8732f172f236f9a47e6bd23b88a4a48ae7c7b7464e5b1d307b6bd3b3ee34b7f9813ac5ad8cfd983d0984008feaa4ffd841130cb2f",
                BreweryAdress = "e23415cad69b46b990f07b9dfec0f9d28e71b08377544c0cb9d20536dde5",
                BriefName = "3e064b8c746441c6a5f3838e6fa1f64908040b2dca404001a7abde46ad6c24b756b46075bd15",
                CompanyId = 1590836343,
                CapacityVolume = 1724741388,
                DeliveryVolume = 1879012433,
                Note = "33d229cc2ccc46a8943b6f8adcc82125981b8b7d79434bda923ddb3d6136e6a82ff5678b750b44ec9b",
                DocStatus = 8,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbHisBreweriesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbHisBreweryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.IsSendMail.ShouldBe(true);
            result.DateSendMail.ShouldBe(new DateTime(2004, 10, 22));
            result.InsertDate.ShouldBe(new DateTime(2019, 10, 4));
            result.Type.ShouldBe(2136360371);
            result.IdBrewery.ShouldBe(306739806);
            result.BreweryName.ShouldBe("a7609403fd914a0e8a8c449381000a0c9b24cd6e66504f5d9ee0c03b17190d6a3e839090aa774aacbf898afbcbbd637759c75f5a73b24fae86be5df00555c52152a1fb8ffeef450692ad1a18579345c86befc7577f3d4dfd8e9f9b454c52e50b9f3b5272b62a4fa7bb381e2d5189d775736582f7a9cd4938b465d2d5cc");
            result.BreweryName_EN.ShouldBe("e4a502cae77d450baa11fec6b6e55dcc154dd87fbca140b98dcf58a72ee2b84d68a141cb2e58410f841a262aefd39e7cf2a3a143c6704031882818c2f5c3b1e113935e5203154db4b8732f172f236f9a47e6bd23b88a4a48ae7c7b7464e5b1d307b6bd3b3ee34b7f9813ac5ad8cfd983d0984008feaa4ffd841130cb2f");
            result.BreweryAdress.ShouldBe("e23415cad69b46b990f07b9dfec0f9d28e71b08377544c0cb9d20536dde5");
            result.BriefName.ShouldBe("3e064b8c746441c6a5f3838e6fa1f64908040b2dca404001a7abde46ad6c24b756b46075bd15");
            result.CompanyId.ShouldBe(1590836343);
            result.CapacityVolume.ShouldBe(1724741388);
            result.DeliveryVolume.ShouldBe(1879012433);
            result.Note.ShouldBe("33d229cc2ccc46a8943b6f8adcc82125981b8b7d79434bda923ddb3d6136e6a82ff5678b750b44ec9b");
            result.DocStatus.ShouldBe((byte?)8);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbHisBreweriesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbHisBreweryRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}