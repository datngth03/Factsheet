using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbPersonTemps
{
    public abstract class TbPersonTempsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbPersonTempsAppService _tbPersonTempsAppService;
        private readonly IRepository<TbPersonTemp, int> _tbPersonTempRepository;

        public TbPersonTempsAppServiceTests()
        {
            _tbPersonTempsAppService = GetRequiredService<ITbPersonTempsAppService>();
            _tbPersonTempRepository = GetRequiredService<IRepository<TbPersonTemp, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbPersonTempsAppService.GetListAsync(new GetTbPersonTempsInput());

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
            var result = await _tbPersonTempsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbPersonTempCreateDto
            {
                idPerson = 1636428762,
                Code = "cbd42f6c6431462b8eba",
                CompanyId = 1787341962,
                FullName = "14e9ea3f66cd4498bf4d1c38039425c381d05fea0539409ba035665c4db90bc7cab17be7276a4a33a6ac4f1c79d64f1f26ff35778df3494bbc6d777b5aa7bfc84ce07ab16af64dda93c16b",
                BirthDate = new DateTime(2013, 11, 25),
                BirthPlace = "b7794fdff6dc41f8bd1f338d541d46e892f4c56a355143c4ba540116e995ffe6420d2f8dd4c8429e8d9a72c58f35f8b427be44fa1a1543d684e4ffe834ba37e933450d0e51d744469384be",
                Address = "1fc4863778654019af236a021d106bd050e1f9aef8d24a61813adc6bc2de0c5fc7cb46a2bc524b0880433cdc7c0b8647e7887219941047ff97506441b42f55284f9aabab79644a14a7466e",
                IDCardNo = "3b60e5592893487bb7dc",
                IDCardDate = new DateTime(2006, 10, 18),
                IdCardIssuePlace = "b63e015d2f3849d582c90eecb133db3e96e7c3a4cf694294b1269a6225c20a06ac9e9b77f9e64b9a983287256947f5dded1cb82e5caf48b183256137997bece59e98e231c5ee4cf3bc6646",
                Ethnicity = "deb0b569678d4e59af6dd581e35bdc01b5e4fe46cd854684887c538498633a269d82fadc1a114df6b8af22877682e58a5c9088606b1646948e5f213b63e0d29a297681a756324f67a33dc0",
                Religion = "05a4c8ad933547c9a2ccc7a74f6c6973f1b5b78abc2245568a7a1733c33fdb522802feafca774cff95bb3142b9a3df0dda7a3547745d4b28ab58c97bc5d62d1b25ffd5ebc39d4064b806f3",
                NationalityCode = "dbc",
                Gender = "075",
                Phone = "fe1c3db4c247442ea9702134d66e7900dd320c1ce3ea4f589d",
                Email = "a1ed19e7e8ce4f5aa854c8ad0320363c54daa1bb1e1b480585c52843216f83837eaaa855238b4e01af7cde944e50338c10e4e928fb1d4da6a5f25c9a1d7a27502f49ade26309479fa923e1",
                Note = "0fb785809a1047de8c8d2058139826fed24b18568c9348ec94d5ca490422e169dd52b625ed034853b708867a9fd5a1d2cd36a7ed7edb4ec39c9b77857045436072b81dd58d4a45edad91e50e1ef6a453d28edc701c8b41e2a37a517ee1eb3f3f25286ae6d1ba4a6684e849ec2c0d7c6f681c3e4a9fa64f369a91c0431a",
                Image = "00595a0",
                IsActive = true,
                DocStatus = 82,
                IsCheckRetirement = true,
                IsCheckTermEnd = true,
                OldCode = "40044a0b8e7249e0a4d2"
            };

            // Act
            var serviceResult = await _tbPersonTempsAppService.CreateAsync(input);

            // Assert
            var result = await _tbPersonTempRepository.FindAsync(c => c.idPerson == serviceResult.idPerson);

            result.ShouldNotBe(null);
            result.idPerson.ShouldBe(1636428762);
            result.Code.ShouldBe("cbd42f6c6431462b8eba");
            result.CompanyId.ShouldBe(1787341962);
            result.FullName.ShouldBe("14e9ea3f66cd4498bf4d1c38039425c381d05fea0539409ba035665c4db90bc7cab17be7276a4a33a6ac4f1c79d64f1f26ff35778df3494bbc6d777b5aa7bfc84ce07ab16af64dda93c16b");
            result.BirthDate.ShouldBe(new DateTime(2013, 11, 25));
            result.BirthPlace.ShouldBe("b7794fdff6dc41f8bd1f338d541d46e892f4c56a355143c4ba540116e995ffe6420d2f8dd4c8429e8d9a72c58f35f8b427be44fa1a1543d684e4ffe834ba37e933450d0e51d744469384be");
            result.Address.ShouldBe("1fc4863778654019af236a021d106bd050e1f9aef8d24a61813adc6bc2de0c5fc7cb46a2bc524b0880433cdc7c0b8647e7887219941047ff97506441b42f55284f9aabab79644a14a7466e");
            result.IDCardNo.ShouldBe("3b60e5592893487bb7dc");
            result.IDCardDate.ShouldBe(new DateTime(2006, 10, 18));
            result.IdCardIssuePlace.ShouldBe("b63e015d2f3849d582c90eecb133db3e96e7c3a4cf694294b1269a6225c20a06ac9e9b77f9e64b9a983287256947f5dded1cb82e5caf48b183256137997bece59e98e231c5ee4cf3bc6646");
            result.Ethnicity.ShouldBe("deb0b569678d4e59af6dd581e35bdc01b5e4fe46cd854684887c538498633a269d82fadc1a114df6b8af22877682e58a5c9088606b1646948e5f213b63e0d29a297681a756324f67a33dc0");
            result.Religion.ShouldBe("05a4c8ad933547c9a2ccc7a74f6c6973f1b5b78abc2245568a7a1733c33fdb522802feafca774cff95bb3142b9a3df0dda7a3547745d4b28ab58c97bc5d62d1b25ffd5ebc39d4064b806f3");
            result.NationalityCode.ShouldBe("dbc");
            result.Gender.ShouldBe("075");
            result.Phone.ShouldBe("fe1c3db4c247442ea9702134d66e7900dd320c1ce3ea4f589d");
            result.Email.ShouldBe("a1ed19e7e8ce4f5aa854c8ad0320363c54daa1bb1e1b480585c52843216f83837eaaa855238b4e01af7cde944e50338c10e4e928fb1d4da6a5f25c9a1d7a27502f49ade26309479fa923e1");
            result.Note.ShouldBe("0fb785809a1047de8c8d2058139826fed24b18568c9348ec94d5ca490422e169dd52b625ed034853b708867a9fd5a1d2cd36a7ed7edb4ec39c9b77857045436072b81dd58d4a45edad91e50e1ef6a453d28edc701c8b41e2a37a517ee1eb3f3f25286ae6d1ba4a6684e849ec2c0d7c6f681c3e4a9fa64f369a91c0431a");
            result.Image.ShouldBe("00595a0");
            result.IsActive.ShouldBe(true);
            result.DocStatus.ShouldBe((byte?)82);
            result.IsCheckRetirement.ShouldBe(true);
            result.IsCheckTermEnd.ShouldBe(true);
            result.OldCode.ShouldBe("40044a0b8e7249e0a4d2");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbPersonTempUpdateDto()
            {
                idPerson = 1291707982,
                Code = "ce5fd8d60a244b239ccb",
                CompanyId = 2085499704,
                FullName = "afa02c740ae543849547b514c54850d3a2139028a7894e6ab16b2e8e03982160abb13dd4d80b446dba01731aa952018a55e7ef39eeb646fcb12040856027b45eace16c0df3b449b6ad34e5",
                BirthDate = new DateTime(2017, 6, 11),
                BirthPlace = "a09110ca417747cc97cdbc17accec60403545e86062f490c9ddafe20e5549fdfca5cfa0558514741a49120dd081ffbd54d28b8ddd69e40c694aa664c39ab8d4bc10c29b4dec74df48df3a7",
                Address = "bd018500e3f34224b49148b58f30481e886736c1263f44bbb8c73c06eff82ea13185e94df5e0447eaa1b60885eada70df4d1886a15a64503afbc285666a2da4cb8d8eda398764303933c3f",
                IDCardNo = "de835b42c12441929b49",
                IDCardDate = new DateTime(2021, 8, 27),
                IdCardIssuePlace = "873dbaa9bbcd478baae226368bafe767872e25b80e194aaaad59a1623818898f4ede0ef8bcd24fabab526c9bfcb9eeeed3c80a3e21204c77a2a0ff5c1c9788bff6789080761c447796f321",
                Ethnicity = "b465db8156c54b0e9303a17e6d9f299c3ff53603a14c46a4a7824aff13376b352f279d87038a469a9f6c2de11d8067dc4ab3d771dfe5450da873e016f09a26334887de3f854f4f2d93e404",
                Religion = "f4abab0dc27449d5986c90b5afbd4917bb32171642f74c279ded6d9ba19e014b4be02d5e7da0463a8751d46edcd8c8dbe818ae62c2144af9b1d8c58e7572b042ee21a1aeef6c434baeacdf",
                NationalityCode = "636",
                Gender = "11c",
                Phone = "9226c8bba8154f0caa28592f712e175e107a7b78669f4cf7a9",
                Email = "1debadd3015d460a8f2d6a5a48cfcf80bebdb432054f445e94af7a202162fcf5ac04b629773e4e5390bac54cc5a80096be0c3c4c075e4b5e93e88d970f065c6852509ae012e84955b2928d",
                Note = "fda0128d3c9e46e0b212ab1fe42a61cbc603c96472ac43bba3dd3bd17079ff4f780a50789a5e4991b650aab31b4add7a85ffb7a841ae441e8bb68bfde249a995be15971b9e57475faa9c72393d9b97edf265bc6ee2cc4dd5a715ddb6f1b78e8600e83c73251d4ae683548a4c8ada139071a4e3697b1e4508bba6c7f4db",
                Image = "0e839d40",
                IsActive = true,
                DocStatus = 31,
                IsCheckRetirement = true,
                IsCheckTermEnd = true,
                OldCode = "b623b3401a9b43dabeb3"
            };

            // Act
            var serviceResult = await _tbPersonTempsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbPersonTempRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.idPerson.ShouldBe(1291707982);
            result.Code.ShouldBe("ce5fd8d60a244b239ccb");
            result.CompanyId.ShouldBe(2085499704);
            result.FullName.ShouldBe("afa02c740ae543849547b514c54850d3a2139028a7894e6ab16b2e8e03982160abb13dd4d80b446dba01731aa952018a55e7ef39eeb646fcb12040856027b45eace16c0df3b449b6ad34e5");
            result.BirthDate.ShouldBe(new DateTime(2017, 6, 11));
            result.BirthPlace.ShouldBe("a09110ca417747cc97cdbc17accec60403545e86062f490c9ddafe20e5549fdfca5cfa0558514741a49120dd081ffbd54d28b8ddd69e40c694aa664c39ab8d4bc10c29b4dec74df48df3a7");
            result.Address.ShouldBe("bd018500e3f34224b49148b58f30481e886736c1263f44bbb8c73c06eff82ea13185e94df5e0447eaa1b60885eada70df4d1886a15a64503afbc285666a2da4cb8d8eda398764303933c3f");
            result.IDCardNo.ShouldBe("de835b42c12441929b49");
            result.IDCardDate.ShouldBe(new DateTime(2021, 8, 27));
            result.IdCardIssuePlace.ShouldBe("873dbaa9bbcd478baae226368bafe767872e25b80e194aaaad59a1623818898f4ede0ef8bcd24fabab526c9bfcb9eeeed3c80a3e21204c77a2a0ff5c1c9788bff6789080761c447796f321");
            result.Ethnicity.ShouldBe("b465db8156c54b0e9303a17e6d9f299c3ff53603a14c46a4a7824aff13376b352f279d87038a469a9f6c2de11d8067dc4ab3d771dfe5450da873e016f09a26334887de3f854f4f2d93e404");
            result.Religion.ShouldBe("f4abab0dc27449d5986c90b5afbd4917bb32171642f74c279ded6d9ba19e014b4be02d5e7da0463a8751d46edcd8c8dbe818ae62c2144af9b1d8c58e7572b042ee21a1aeef6c434baeacdf");
            result.NationalityCode.ShouldBe("636");
            result.Gender.ShouldBe("11c");
            result.Phone.ShouldBe("9226c8bba8154f0caa28592f712e175e107a7b78669f4cf7a9");
            result.Email.ShouldBe("1debadd3015d460a8f2d6a5a48cfcf80bebdb432054f445e94af7a202162fcf5ac04b629773e4e5390bac54cc5a80096be0c3c4c075e4b5e93e88d970f065c6852509ae012e84955b2928d");
            result.Note.ShouldBe("fda0128d3c9e46e0b212ab1fe42a61cbc603c96472ac43bba3dd3bd17079ff4f780a50789a5e4991b650aab31b4add7a85ffb7a841ae441e8bb68bfde249a995be15971b9e57475faa9c72393d9b97edf265bc6ee2cc4dd5a715ddb6f1b78e8600e83c73251d4ae683548a4c8ada139071a4e3697b1e4508bba6c7f4db");
            result.Image.ShouldBe("0e839d40");
            result.IsActive.ShouldBe(true);
            result.DocStatus.ShouldBe((byte?)31);
            result.IsCheckRetirement.ShouldBe(true);
            result.IsCheckTermEnd.ShouldBe(true);
            result.OldCode.ShouldBe("b623b3401a9b43dabeb3");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbPersonTempsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbPersonTempRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}