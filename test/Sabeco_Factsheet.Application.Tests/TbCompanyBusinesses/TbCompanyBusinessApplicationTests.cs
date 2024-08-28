using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyBusinesses
{
    public abstract class TbCompanyBusinessesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyBusinessesAppService _tbCompanyBusinessesAppService;
        private readonly IRepository<TbCompanyBusiness, int> _tbCompanyBusinessRepository;

        public TbCompanyBusinessesAppServiceTests()
        {
            _tbCompanyBusinessesAppService = GetRequiredService<ITbCompanyBusinessesAppService>();
            _tbCompanyBusinessRepository = GetRequiredService<IRepository<TbCompanyBusiness, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyBusinessesAppService.GetListAsync(new GetTbCompanyBusinessesInput());

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
            var result = await _tbCompanyBusinessesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyBusinessCreateDto
            {
                CompanyId = 954721393,
                License = "795619d1c3354972b884",
                RegistrationNo = 122,
                RegistrationDate = new DateTime(2013, 6, 9),
                CompanyName = "f4f829342116413f9c3c49c65ae22754301c3a65f3a44cdfb925514753940beeed829d992f064fcfa5426520151971952d1e2e55d0cb4b27a2be89daee99fabe833523a1028846e7987aa801ced72eb2281b1971282e49e2a6972106473489a4903dc9ab815b4d91a1c338bcdfbdc05c7c97ec3e7b1646bb98b48c9b19",
                CompanyAddress = "775a6ad7ee3240eb9de31d690bc8c1e80c429fec2fb74c27b13ae1e2b645dd7e695897c487a14e6cb5c337763d3a77755ef349de3836473b9fd3f7cbd25f47411e609c76b3664f87b4a65b313bf35c4bc4b6e39324a6463997265ff2d9a5a4559894931b6848404ca25a5fbfe5401db6ae72fa5880594a80a182a87489",
                LegalRepresent = "84acc62ab24e48cabeaa9753d2f6e1d9ae52d1e095a94c3f9b78948dc5465af72e5887a0b9a745dba09a120993acc40c50503d3c055446af975cf2f8402558fb4194649276854c019eaf80a5d12b15fc545e135e2ff1484fb467e69a9a61314c2f0180386747472da3fd530e59b9751f5c23e08578804b31995a872fff",
                CompanyType = "6f305e88737442ea8d8a3abf3e551a7efa5fa8726f024bc7b57cca35c115818caed47dc0bae24006bcaceaf613aa7214e1936b43fd664877bb08e4e819c65438b85b76154f754b569b9cdd449d30075e002e25eb8c4f428684552e5b74a77ce6c9455f381dc641f0909bf50ecd04fcf2719de02a3921462d852d53b4c2",
                MajorBusiness = "de68aeb3c97a437796918a2f17866020e88612c19949470aa4524fd8a86a8f5c014984e2fbbf4736902764bc81bdee194ca63e642f7141da94763f5f9f5c1e2a6714274cf0c74053910db9b08f3a5a47c129666185524698b991ce2080657ab7e14ca16124d94c6f800fddb88cff63984dde728cf0684757b1bcecbe50",
                OtherActivity = "4f0b4dd8846d4581937d0f506246ccc21d24c59da9d047b4b2497147023d357eb9e4f172dacb4923aeb7e276af9a8b5f96fc128a8ef54719a327f7c64581976ef7d769e617d94acaa97e6431f7422a2dc6b29bcdbd7746eaad0e0489087d8aa5bc796be76ee4447084c3e4f354a158a5790f5c15798d4534b988e0f91fb2bac63d4daf270d0c481d9aafc20f322eade10b0ca6a793be4335bc9109695fae8218065299bafeb0496cab8d49e97f2090b918721e0b6fcf45a186111e51f21b6bdcde8c860f5da244d1baaabca3076b42aa6a517b8cdc3d4dccb3e183ce91f404d62d91885a085346fea5f77af004faa8d90627c7a6ae804f3484fe",
                Note = "74485088e9384f1abc2c9edad42604c64a8420d9eb704321b7854f708dfd8e48b5ce756eb7b04fa1a828ae9ce09dc3e047bad0b4e7664e8e936d296ea07a8d6c2417147f1dbd40d8b0e9312e4b3b63c4cd2ee9c338874b3d87eabdcde966bcdd2c9fcf8857084e91aab4330b48baaad9016ade3f2b224aafac82735aa7",
                IsActive = true,
                LatestAmendment = new DateTime(2021, 3, 4)
            };

            // Act
            var serviceResult = await _tbCompanyBusinessesAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyBusinessRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(954721393);
            result.License.ShouldBe("795619d1c3354972b884");
            result.RegistrationNo.ShouldBe((byte)122);
            result.RegistrationDate.ShouldBe(new DateTime(2013, 6, 9));
            result.CompanyName.ShouldBe("f4f829342116413f9c3c49c65ae22754301c3a65f3a44cdfb925514753940beeed829d992f064fcfa5426520151971952d1e2e55d0cb4b27a2be89daee99fabe833523a1028846e7987aa801ced72eb2281b1971282e49e2a6972106473489a4903dc9ab815b4d91a1c338bcdfbdc05c7c97ec3e7b1646bb98b48c9b19");
            result.CompanyAddress.ShouldBe("775a6ad7ee3240eb9de31d690bc8c1e80c429fec2fb74c27b13ae1e2b645dd7e695897c487a14e6cb5c337763d3a77755ef349de3836473b9fd3f7cbd25f47411e609c76b3664f87b4a65b313bf35c4bc4b6e39324a6463997265ff2d9a5a4559894931b6848404ca25a5fbfe5401db6ae72fa5880594a80a182a87489");
            result.LegalRepresent.ShouldBe("84acc62ab24e48cabeaa9753d2f6e1d9ae52d1e095a94c3f9b78948dc5465af72e5887a0b9a745dba09a120993acc40c50503d3c055446af975cf2f8402558fb4194649276854c019eaf80a5d12b15fc545e135e2ff1484fb467e69a9a61314c2f0180386747472da3fd530e59b9751f5c23e08578804b31995a872fff");
            result.CompanyType.ShouldBe("6f305e88737442ea8d8a3abf3e551a7efa5fa8726f024bc7b57cca35c115818caed47dc0bae24006bcaceaf613aa7214e1936b43fd664877bb08e4e819c65438b85b76154f754b569b9cdd449d30075e002e25eb8c4f428684552e5b74a77ce6c9455f381dc641f0909bf50ecd04fcf2719de02a3921462d852d53b4c2");
            result.MajorBusiness.ShouldBe("de68aeb3c97a437796918a2f17866020e88612c19949470aa4524fd8a86a8f5c014984e2fbbf4736902764bc81bdee194ca63e642f7141da94763f5f9f5c1e2a6714274cf0c74053910db9b08f3a5a47c129666185524698b991ce2080657ab7e14ca16124d94c6f800fddb88cff63984dde728cf0684757b1bcecbe50");
            result.OtherActivity.ShouldBe("4f0b4dd8846d4581937d0f506246ccc21d24c59da9d047b4b2497147023d357eb9e4f172dacb4923aeb7e276af9a8b5f96fc128a8ef54719a327f7c64581976ef7d769e617d94acaa97e6431f7422a2dc6b29bcdbd7746eaad0e0489087d8aa5bc796be76ee4447084c3e4f354a158a5790f5c15798d4534b988e0f91fb2bac63d4daf270d0c481d9aafc20f322eade10b0ca6a793be4335bc9109695fae8218065299bafeb0496cab8d49e97f2090b918721e0b6fcf45a186111e51f21b6bdcde8c860f5da244d1baaabca3076b42aa6a517b8cdc3d4dccb3e183ce91f404d62d91885a085346fea5f77af004faa8d90627c7a6ae804f3484fe");
            result.Note.ShouldBe("74485088e9384f1abc2c9edad42604c64a8420d9eb704321b7854f708dfd8e48b5ce756eb7b04fa1a828ae9ce09dc3e047bad0b4e7664e8e936d296ea07a8d6c2417147f1dbd40d8b0e9312e4b3b63c4cd2ee9c338874b3d87eabdcde966bcdd2c9fcf8857084e91aab4330b48baaad9016ade3f2b224aafac82735aa7");
            result.IsActive.ShouldBe(true);
            result.LatestAmendment.ShouldBe(new DateTime(2021, 3, 4));
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyBusinessUpdateDto()
            {
                CompanyId = 1547432352,
                License = "1fc129837f10479eb195",
                RegistrationNo = 106,
                RegistrationDate = new DateTime(2007, 8, 13),
                CompanyName = "90d584b47d72474387c7388aed134fecc489df7c7d9647e2a3dfcebdc6a9bd438d0cc6c7403a49a3a54ad392ecc418226d00c8b1bb0f48aaaafbda2fe516d684a79ed9fd9b20493e8cb170f81c647a35ffc43ffab87748b2975b8b9916dd00f89abc676c93b940539dcc76b280609990d38c76e02e2a46e48381f75f3c",
                CompanyAddress = "4a9f24161cde4518887067293ac30277247ddc60768240548b4e0ef9b698ff5b5b64967253744e26b0a9d82a86a42ff145d9f618bea740fba7716110e0614dd15bc4efe00cfe4379b71e7db3cc8aca1977cdea4e47114cbca195e3d6832dd7af26e6177e376547bb8599698abf07af4a3962c86a5a9447729612d97484",
                LegalRepresent = "6123408b49a94a47acceb701e6b1c1c226c8b4d332744ba18a40c1d53adad3a84bf89e3d8a5c4770aa8638189e7e38807c3b18a6e2334d68a74c94e78e8116c30efb91ba4809412f95c2506f6b9917c64e5ed8cfdb20425eaeac49aa979ee796d4f232453c364cf5b084e6ab4e858deb5f024b915ca446abba322d5a9f",
                CompanyType = "072230e47ad243d698bbf7e81b697f40b038eb65e19c41d396670a9bcfc174ff46fe3bb3dd31471798aa605d79c6eeecdb497ac77281468b8ab5400c8956c5404540c94c43eb49b9ba9a62d5ebd22c93e05e9ad422bd4751b7990831b7a70a3443ba8c1d2fa64ff38f77ac6977f115ec438cf8332cd147fbad33c4eb7d",
                MajorBusiness = "e44a5b4a118b42f4b6492827b3c12b2fe9cd767c541943f7be213688d060cdb82a706f17a42c4851839da97ae63fb476fa76f5844a384d569d2dd8d32a5031a360aec84b4e184142b152b3b32ac94b3ceba2a88337b94a3a899a874e8b3338a2d0fad30ca72548fbb4474672878253396d83201769c54a51b814f92500",
                OtherActivity = "85c36fb4ab8f4afbb44571e20a29488d9c293b8fdcf74ab1b8e21ae5e97a6078576a720c7cf145b4ab7731a5092fcc725b94ce9886844de7b1750b2b5e335f304cf43f267c8c4bc7b946a793c76b30f0cfcdca6ebcf34dc5bf940d20289bdc948c4f3c764f2c4de092d1be6d4cc1aee89236176f48a04efd8e6628b4733f20ebc64bb61abb114d9ba61bd1248787d953e917100f76814bf2bf8f50186e1e8b5b89716e78906543cb86b2715ce6deef9a62238d78c7fa4aa4b445dec55871e5b56648b32602bb44598b642ed559ca20f7d584136cbda74fdd85b037e897531cce7954417966ae41cab0f69276a4622476736314d3c6e04e5cb141",
                Note = "271682d613744f028a20ab4ac38af60cfe88252548fe4852b3691668c04674391c2ff82cbb484318a2c66e51d4e00d4de4dc3e10139540fc8943c7f092caf0e00a056da1cdb448ff9d2b27a8530cada21dad308b629a48049264db65d47cd9fbe841d4fa0db94d8a8b1da31837cd1f338f0ab7dfb914413880b011b8e0",
                IsActive = true,
                LatestAmendment = new DateTime(2009, 9, 16)
            };

            // Act
            var serviceResult = await _tbCompanyBusinessesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyBusinessRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1547432352);
            result.License.ShouldBe("1fc129837f10479eb195");
            result.RegistrationNo.ShouldBe((byte)106);
            result.RegistrationDate.ShouldBe(new DateTime(2007, 8, 13));
            result.CompanyName.ShouldBe("90d584b47d72474387c7388aed134fecc489df7c7d9647e2a3dfcebdc6a9bd438d0cc6c7403a49a3a54ad392ecc418226d00c8b1bb0f48aaaafbda2fe516d684a79ed9fd9b20493e8cb170f81c647a35ffc43ffab87748b2975b8b9916dd00f89abc676c93b940539dcc76b280609990d38c76e02e2a46e48381f75f3c");
            result.CompanyAddress.ShouldBe("4a9f24161cde4518887067293ac30277247ddc60768240548b4e0ef9b698ff5b5b64967253744e26b0a9d82a86a42ff145d9f618bea740fba7716110e0614dd15bc4efe00cfe4379b71e7db3cc8aca1977cdea4e47114cbca195e3d6832dd7af26e6177e376547bb8599698abf07af4a3962c86a5a9447729612d97484");
            result.LegalRepresent.ShouldBe("6123408b49a94a47acceb701e6b1c1c226c8b4d332744ba18a40c1d53adad3a84bf89e3d8a5c4770aa8638189e7e38807c3b18a6e2334d68a74c94e78e8116c30efb91ba4809412f95c2506f6b9917c64e5ed8cfdb20425eaeac49aa979ee796d4f232453c364cf5b084e6ab4e858deb5f024b915ca446abba322d5a9f");
            result.CompanyType.ShouldBe("072230e47ad243d698bbf7e81b697f40b038eb65e19c41d396670a9bcfc174ff46fe3bb3dd31471798aa605d79c6eeecdb497ac77281468b8ab5400c8956c5404540c94c43eb49b9ba9a62d5ebd22c93e05e9ad422bd4751b7990831b7a70a3443ba8c1d2fa64ff38f77ac6977f115ec438cf8332cd147fbad33c4eb7d");
            result.MajorBusiness.ShouldBe("e44a5b4a118b42f4b6492827b3c12b2fe9cd767c541943f7be213688d060cdb82a706f17a42c4851839da97ae63fb476fa76f5844a384d569d2dd8d32a5031a360aec84b4e184142b152b3b32ac94b3ceba2a88337b94a3a899a874e8b3338a2d0fad30ca72548fbb4474672878253396d83201769c54a51b814f92500");
            result.OtherActivity.ShouldBe("85c36fb4ab8f4afbb44571e20a29488d9c293b8fdcf74ab1b8e21ae5e97a6078576a720c7cf145b4ab7731a5092fcc725b94ce9886844de7b1750b2b5e335f304cf43f267c8c4bc7b946a793c76b30f0cfcdca6ebcf34dc5bf940d20289bdc948c4f3c764f2c4de092d1be6d4cc1aee89236176f48a04efd8e6628b4733f20ebc64bb61abb114d9ba61bd1248787d953e917100f76814bf2bf8f50186e1e8b5b89716e78906543cb86b2715ce6deef9a62238d78c7fa4aa4b445dec55871e5b56648b32602bb44598b642ed559ca20f7d584136cbda74fdd85b037e897531cce7954417966ae41cab0f69276a4622476736314d3c6e04e5cb141");
            result.Note.ShouldBe("271682d613744f028a20ab4ac38af60cfe88252548fe4852b3691668c04674391c2ff82cbb484318a2c66e51d4e00d4de4dc3e10139540fc8943c7f092caf0e00a056da1cdb448ff9d2b27a8530cada21dad308b629a48049264db65d47cd9fbe841d4fa0db94d8a8b1da31837cd1f338f0ab7dfb914413880b011b8e0");
            result.IsActive.ShouldBe(true);
            result.LatestAmendment.ShouldBe(new DateTime(2009, 9, 16));
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyBusinessesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyBusinessRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}