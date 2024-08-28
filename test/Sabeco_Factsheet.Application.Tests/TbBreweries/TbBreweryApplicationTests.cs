using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbBreweries
{
    public abstract class TbBreweriesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbBreweriesAppService _tbBreweriesAppService;
        private readonly IRepository<TbBrewery, int> _tbBreweryRepository;

        public TbBreweriesAppServiceTests()
        {
            _tbBreweriesAppService = GetRequiredService<ITbBreweriesAppService>();
            _tbBreweryRepository = GetRequiredService<IRepository<TbBrewery, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbBreweriesAppService.GetListAsync(new GetTbBreweriesInput());

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
            var result = await _tbBreweriesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbBreweryCreateDto
            {
                BreweryCode = "3ca8269066ea46dfa668",
                BreweryName = "a82c26416ff84f4f937dc2e4ff67a8bdc611cc3bb92f41159e42e0331d64fb5bc000dd29baa74b3cb52fb6fea003bedbf50608c6c48646f2ac10df0fa237f1aa1e5e61cb1b3046baa2c681f0cefbb6d3cb24021fd55d47139d328f5cdb431048bd087e8d99c7475eb9d1ae57b0bc2020f0362c8709d647b0861062594e",
                BreweryName_EN = "bef147673ea348b88c5f8e35ed4cfc6a7a83993b3f2f4a28b699cf9537a3dfc33818abc4024642229e248ff30d55abb0d0229580577145d6b1cb09a56a69c51caea7517236344f7ab2c8bad36ef4a75fa35f93c5f5ab4adcbcd29fee6241bbd2c51ee97411fb42b0a68ae71cb3f1aec9316a5f682c7d4c559d3118e278",
                BriefName = "9a278369932b44d793c5efda02653223b20d00240c504733a750b0e6dbd4766e2dbb59858b7c4fbdb11f49df0f9065",
                BreweryAdress = "52c1cc9fdbb24cf2a45208a03c2af34b9cab74c373324c5daebcafcd65a13f6d27a2b901c0",
                CompanyId = 2100410099,
                CapacityVolume = 105301281,
                DeliveryVolume = 1857137480,
                Note = "63fc47147aca",
                DocStatus = 59,
                isActive = true
            };

            // Act
            var serviceResult = await _tbBreweriesAppService.CreateAsync(input);

            // Assert
            var result = await _tbBreweryRepository.FindAsync(c => c.BreweryCode == serviceResult.BreweryCode);

            result.ShouldNotBe(null);
            result.BreweryCode.ShouldBe("3ca8269066ea46dfa668");
            result.BreweryName.ShouldBe("a82c26416ff84f4f937dc2e4ff67a8bdc611cc3bb92f41159e42e0331d64fb5bc000dd29baa74b3cb52fb6fea003bedbf50608c6c48646f2ac10df0fa237f1aa1e5e61cb1b3046baa2c681f0cefbb6d3cb24021fd55d47139d328f5cdb431048bd087e8d99c7475eb9d1ae57b0bc2020f0362c8709d647b0861062594e");
            result.BreweryName_EN.ShouldBe("bef147673ea348b88c5f8e35ed4cfc6a7a83993b3f2f4a28b699cf9537a3dfc33818abc4024642229e248ff30d55abb0d0229580577145d6b1cb09a56a69c51caea7517236344f7ab2c8bad36ef4a75fa35f93c5f5ab4adcbcd29fee6241bbd2c51ee97411fb42b0a68ae71cb3f1aec9316a5f682c7d4c559d3118e278");
            result.BriefName.ShouldBe("9a278369932b44d793c5efda02653223b20d00240c504733a750b0e6dbd4766e2dbb59858b7c4fbdb11f49df0f9065");
            result.BreweryAdress.ShouldBe("52c1cc9fdbb24cf2a45208a03c2af34b9cab74c373324c5daebcafcd65a13f6d27a2b901c0");
            result.CompanyId.ShouldBe(2100410099);
            result.CapacityVolume.ShouldBe(105301281);
            result.DeliveryVolume.ShouldBe(1857137480);
            result.Note.ShouldBe("63fc47147aca");
            result.DocStatus.ShouldBe((byte?)59);
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbBreweryUpdateDto()
            {
                BreweryCode = "1fb56281696349a6a7c1",
                BreweryName = "1d13b9fee8404cd2af8403fd7ec49954149fbdd8b7c44cebaf189fd9ea556032fa50c9c9edc74de999b33639cb33a742804f506a2fb04861b87f15dc1c2e61114d0a9778c4a8446cabf832987455782d0ea9b154a3fd481fa2642932d3d10735a85ca5a46ead439980663a8be65aa5668b44e3423b2e441da556910825",
                BreweryName_EN = "1ec099b4eca94288b0725ffba1bf3bb02134292153724e47bf588fe2b48a8e5f23aea86efa9a4a4eaaf070187f2208b81362282e2b22460f9d2fb86535304467f424dcb9c47a40b49f6001ffc8fea7090aa9e70c40fc4904b8269a16693470c8be18213b0e0e4cfeb50b6cd520bd0ab49fb32ba991fe4a5cab57dc5d8b",
                BriefName = "082ed69b0d7146118545a35b4c987ade5974f05e39c",
                BreweryAdress = "2e6baf9f090e43bfb7b399980aa9e602f69bc507672c4d2cba0842f00327100c15e47c5",
                CompanyId = 1441913000,
                CapacityVolume = 180838354,
                DeliveryVolume = 1051879093,
                Note = "84db956450904773b3e78892d73d5be8de94c5b25e3a4b2bacf53dd0",
                DocStatus = 109,
                isActive = true
            };

            // Act
            var serviceResult = await _tbBreweriesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbBreweryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.BreweryCode.ShouldBe("1fb56281696349a6a7c1");
            result.BreweryName.ShouldBe("1d13b9fee8404cd2af8403fd7ec49954149fbdd8b7c44cebaf189fd9ea556032fa50c9c9edc74de999b33639cb33a742804f506a2fb04861b87f15dc1c2e61114d0a9778c4a8446cabf832987455782d0ea9b154a3fd481fa2642932d3d10735a85ca5a46ead439980663a8be65aa5668b44e3423b2e441da556910825");
            result.BreweryName_EN.ShouldBe("1ec099b4eca94288b0725ffba1bf3bb02134292153724e47bf588fe2b48a8e5f23aea86efa9a4a4eaaf070187f2208b81362282e2b22460f9d2fb86535304467f424dcb9c47a40b49f6001ffc8fea7090aa9e70c40fc4904b8269a16693470c8be18213b0e0e4cfeb50b6cd520bd0ab49fb32ba991fe4a5cab57dc5d8b");
            result.BriefName.ShouldBe("082ed69b0d7146118545a35b4c987ade5974f05e39c");
            result.BreweryAdress.ShouldBe("2e6baf9f090e43bfb7b399980aa9e602f69bc507672c4d2cba0842f00327100c15e47c5");
            result.CompanyId.ShouldBe(1441913000);
            result.CapacityVolume.ShouldBe(180838354);
            result.DeliveryVolume.ShouldBe(1051879093);
            result.Note.ShouldBe("84db956450904773b3e78892d73d5be8de94c5b25e3a4b2bacf53dd0");
            result.DocStatus.ShouldBe((byte?)109);
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbBreweriesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbBreweryRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}