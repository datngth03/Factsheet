using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyTemps
{
    public abstract class TbCompanyTempsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyTempsAppService _tbCompanyTempsAppService;
        private readonly IRepository<TbCompanyTemp, int> _tbCompanyTempRepository;

        public TbCompanyTempsAppServiceTests()
        {
            _tbCompanyTempsAppService = GetRequiredService<ITbCompanyTempsAppService>();
            _tbCompanyTempRepository = GetRequiredService<IRepository<TbCompanyTemp, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyTempsAppService.GetListAsync(new GetTbCompanyTempsInput());

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
            var result = await _tbCompanyTempsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyTempCreateDto
            {
                idCompany = 1053474556,
                ParentId = 1001457930,
                IsGroup = true,
                Code = "151af3ebcd5a459d9681",
                Name = "11d38a818aec418b9e60cfada229eb72c6efc9a2d3c54e688def413dfd528a4b393397e344c14469a7d7da54b63810be079c1ce249e0451d967dc27f24321789f7fc62f4af9b4e37aaa91340a89ebe01a20dcc386a854755a99e71f011c30941e131e76e5f0a4fd2bf90c14dd3302491b147d525be314bef84ab2fd818",
                Name_EN = "cd896cd43b3d44cd80cdb0854b84f6a64201b8992d22458f94e640d255d0f458414f5eb460ce485f86598999e146ed80f3c3e612bf4f4216a1f6332291eb74b7cc48300a655b4cf488204639ed2ddc535d4bc48d79d24d13b435acb292d85fb3ad6c5672acbe4671b600d719f65fa86060f130789c3c4f05bc87b17865",
                BriefName = "c05a92ff240a4bcda4e06ab74de5357b08577cc60d704679a120474980a2f8dcaa4a59cbeaf543a6a77a4369142d52736d30",
                ContactInfo_01 = "aac18d87c1004878a51d3ce6728fc9e3e4d493f75c78471bbc3ba28547ea74182e7e13515830404894189367d8128c066d991317fab3411382536678b3b2129153ec20e072324c8ebb7ae6bc77eaf08c66403c10405f46109f8d66f461908f1d66ca343845f0450c8805b12bfb5f362d1ed1846aa27e4ceebc020e45fa",
                ContactInfo_02 = "c9754d5ee78f443a8cb6a812c317b03209a2c77f9aca4b78a5",
                ContactInfo_03 = "f801f778b76847148b6d9e205575c66a2089d5ca17d04e0196",
                ContactInfo_04 = "5bb6c001e2c044fb8684d4f09ddda3906f859fb5f9e1423e8fc65b913831cd7c06db6a2c46f44844a5317559a5456664a0760c6778f24cbc9847c1238646afa84137eafee92146f6b4dc8c",
                ContactInfo_05 = "76bbb00452294efa803b780555730c67c79df206c25848da93af74c8af84fee9f9310616bce141b794c4c3c0fd1df5ac9b8f5fadd55b4ee4ada2056560e58e605d6b814b89f44b04a3c76cf57b9aa39902c01e2fb95a47619b734ee76ecbc7510f577e5e861844f09bf072f2c26e2e2e4de070e4e83e4bfa92569a85a6",
                ContactInfo_06 = "c8958a49edda4af",
                StockCode = "cb386",
                StockExchange = "6bd2b8f251",
                StockRegistrationDate = new DateTime(2015, 4, 27),
                IsPublicCompany = true,
                LicenseNo = "ceff977dcd5843678477",
                License = "bea31c6e02bc4edaa82d",
                RegistrationOrder = 117,
                RegistrationDate0 = new DateTime(2001, 7, 14),
                RegistrationDate = new DateTime(2007, 11, 4),
                LatestAmendment = new DateTime(2004, 9, 22),
                LegalRepresent = "c04fac4f65b54704b5a11c85abf489cb50e1f7d450094a1aa5542063a5b0bb4e573d5bff154841d382d63a57cef5af55ceb502d503be4750aa7ef3fd0432ffdbd6efe813759c44af8323226df9b34f8bfe10943b811144cc86f39b7c29c716a4d782b42bdbda47b2b84faf362a7d275e1eb162eb5ee84ea9b5d97f17e0",
                CompanyType = "6081b",
                CharteredCapital = 56696166,
                TotalShare = 398425144,
                ListedShare = 1179036644,
                ParValue = 1507364674,
                ContactName1 = "2128c6639ec14e7fbf49839ecaa31ad112d63f36c9844610985b667c1cd9ff773554f7d1ae6f4b6ab1c8c7a3de25c1d98517e829b9bd4f839c98a537e9a94599a515cbb720204ecbbe2c28",
                ContactDept1 = "91a6c17a3ac049b4b66cfda56bcee9b0f2616eaca12440e9bc69b4afb7fd9a800351bcb8ed4b4b849d14b00672b5a49200b5ff72810b41fcaa5bdcab61fb4a61157dc6dd29e14d2397c14f",
                ContactMail1 = "b13e9724c31447669c76ce29a090378f40975ebac67944f996e3aa0408dea44a7805cb79aeb2453698b6e91dea1bc808d8953b49194b4284abdc6323d6a2443054f8d66ce66e4b57a7e38e",
                ContactPosition1 = "ae2b878989a94d6890b2f6091f82df40cef01fcda9d24d2ebf60defd23646a8be7f53702c1ba4842b6c54f1cb5c2517af54acc0359f74dbaba1853418482c4567e4783258b27412cbb24cba2f7a579d45190fcea32344ff8b2fb12c238057480bdf92f4c48dc4018a5ac0c8c7bdda7b5b6db28feee48426f8195741152",
                ContactPhone1 = "78427d05e92e44f9917be87c0989274b7169fda4a5774e5c97",
                ContactName2 = "756846e334f349d79357f96417035d608a5be3768f7749ddabd535f104464d30ab59258aeef14621973fe9f889fad206fada12051fe041b0b63aa352b432e45cfe8571d2807f4446bdf738",
                ContactDept2 = "767ee8b6608e4709ab8f222507b1426da3b84022c7424e0fa7f3463e6f497ee7cab328038528441aa5a633550a021c4e2f340130859d43e3a77b4f059696e495a6affa09158449b5815bbe",
                ContactMail2 = "0d4174d901b842b6b12507bef5daf52944259fcf07a04e08a36c55dd2dffc53c04dd4c7ad6d94eb9b91ec8728b79effc91c40a4a75594c53a874d2359435b5c8d32f3e4b14dc49a083b788",
                ContactPosition2 = "10929c67c5df4a0c9cfd85f00757bf7592ebc62f820a46a59d1a42c9bb02eab9ee43ffd9f95141f9b3b4a29176851156746e63294fe74dbe84e49a95b7f0ac305928b3aa67924308b4858397a218f082e85caf6f8d314bcc8dc9c820c84e555f69988fcd92be4065bd149b33a8506eeb5bbc7c15ae6549cfb40aba8b31",
                ContactPhone2 = "cefcfc41a6a5432a91bb7ddc7b1042d54e931af999e64c2da8",
                longtitude = 192431210,
                latitude = 1319976627,
                Note = "9153657471684028a4c7d12a463172d1eee601c9188a4caa9c0f08b6502e8f4f00159c73cd0a4a3e97e88158aef6f5ca44d1514e7614414781919950b7ff9a302f98644bf68c4c269c99281236580d1fe45b9c9673fa459ea4cc0b9181601963b0afe881119140b7a270a89d058ebe4e1a17b066feb24af490c6137221",
                DocStatus = 89,
                DirectShareholding = 1069478068,
                ConsolidatedShareholding = 1146162804,
                ConsolidateNoted = "eeb6812baab34cb8b7969977b19f0d841bc5a97aca60",
                VotingRightDirect = 160930807,
                VotingRightTotal = 1155821001,
                Image = "cf5866f61a9e42a582eff0321a5e2560f39f0bf013154f6da9eb64337b5a001a3d60b12bebf64a11b98d4508f4c47",
                IsActive = true,
                BravoCode = "146bd",
                LegacyCode = "79fd0cce747c446d"
            };

            // Act
            var serviceResult = await _tbCompanyTempsAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyTempRepository.FindAsync(c => c.idCompany == serviceResult.idCompany);

            result.ShouldNotBe(null);
            result.idCompany.ShouldBe(1053474556);
            result.ParentId.ShouldBe(1001457930);
            result.IsGroup.ShouldBe(true);
            result.Code.ShouldBe("151af3ebcd5a459d9681");
            result.Name.ShouldBe("11d38a818aec418b9e60cfada229eb72c6efc9a2d3c54e688def413dfd528a4b393397e344c14469a7d7da54b63810be079c1ce249e0451d967dc27f24321789f7fc62f4af9b4e37aaa91340a89ebe01a20dcc386a854755a99e71f011c30941e131e76e5f0a4fd2bf90c14dd3302491b147d525be314bef84ab2fd818");
            result.Name_EN.ShouldBe("cd896cd43b3d44cd80cdb0854b84f6a64201b8992d22458f94e640d255d0f458414f5eb460ce485f86598999e146ed80f3c3e612bf4f4216a1f6332291eb74b7cc48300a655b4cf488204639ed2ddc535d4bc48d79d24d13b435acb292d85fb3ad6c5672acbe4671b600d719f65fa86060f130789c3c4f05bc87b17865");
            result.BriefName.ShouldBe("c05a92ff240a4bcda4e06ab74de5357b08577cc60d704679a120474980a2f8dcaa4a59cbeaf543a6a77a4369142d52736d30");
            result.ContactInfo_01.ShouldBe("aac18d87c1004878a51d3ce6728fc9e3e4d493f75c78471bbc3ba28547ea74182e7e13515830404894189367d8128c066d991317fab3411382536678b3b2129153ec20e072324c8ebb7ae6bc77eaf08c66403c10405f46109f8d66f461908f1d66ca343845f0450c8805b12bfb5f362d1ed1846aa27e4ceebc020e45fa");
            result.ContactInfo_02.ShouldBe("c9754d5ee78f443a8cb6a812c317b03209a2c77f9aca4b78a5");
            result.ContactInfo_03.ShouldBe("f801f778b76847148b6d9e205575c66a2089d5ca17d04e0196");
            result.ContactInfo_04.ShouldBe("5bb6c001e2c044fb8684d4f09ddda3906f859fb5f9e1423e8fc65b913831cd7c06db6a2c46f44844a5317559a5456664a0760c6778f24cbc9847c1238646afa84137eafee92146f6b4dc8c");
            result.ContactInfo_05.ShouldBe("76bbb00452294efa803b780555730c67c79df206c25848da93af74c8af84fee9f9310616bce141b794c4c3c0fd1df5ac9b8f5fadd55b4ee4ada2056560e58e605d6b814b89f44b04a3c76cf57b9aa39902c01e2fb95a47619b734ee76ecbc7510f577e5e861844f09bf072f2c26e2e2e4de070e4e83e4bfa92569a85a6");
            result.ContactInfo_06.ShouldBe("c8958a49edda4af");
            result.StockCode.ShouldBe("cb386");
            result.StockExchange.ShouldBe("6bd2b8f251");
            result.StockRegistrationDate.ShouldBe(new DateTime(2015, 4, 27));
            result.IsPublicCompany.ShouldBe(true);
            result.LicenseNo.ShouldBe("ceff977dcd5843678477");
            result.License.ShouldBe("bea31c6e02bc4edaa82d");
            result.RegistrationOrder.ShouldBe((byte?)117);
            result.RegistrationDate0.ShouldBe(new DateTime(2001, 7, 14));
            result.RegistrationDate.ShouldBe(new DateTime(2007, 11, 4));
            result.LatestAmendment.ShouldBe(new DateTime(2004, 9, 22));
            result.LegalRepresent.ShouldBe("c04fac4f65b54704b5a11c85abf489cb50e1f7d450094a1aa5542063a5b0bb4e573d5bff154841d382d63a57cef5af55ceb502d503be4750aa7ef3fd0432ffdbd6efe813759c44af8323226df9b34f8bfe10943b811144cc86f39b7c29c716a4d782b42bdbda47b2b84faf362a7d275e1eb162eb5ee84ea9b5d97f17e0");
            result.CompanyType.ShouldBe("6081b");
            result.CharteredCapital.ShouldBe(56696166);
            result.TotalShare.ShouldBe(398425144);
            result.ListedShare.ShouldBe(1179036644);
            result.ParValue.ShouldBe(1507364674);
            result.ContactName1.ShouldBe("2128c6639ec14e7fbf49839ecaa31ad112d63f36c9844610985b667c1cd9ff773554f7d1ae6f4b6ab1c8c7a3de25c1d98517e829b9bd4f839c98a537e9a94599a515cbb720204ecbbe2c28");
            result.ContactDept1.ShouldBe("91a6c17a3ac049b4b66cfda56bcee9b0f2616eaca12440e9bc69b4afb7fd9a800351bcb8ed4b4b849d14b00672b5a49200b5ff72810b41fcaa5bdcab61fb4a61157dc6dd29e14d2397c14f");
            result.ContactMail1.ShouldBe("b13e9724c31447669c76ce29a090378f40975ebac67944f996e3aa0408dea44a7805cb79aeb2453698b6e91dea1bc808d8953b49194b4284abdc6323d6a2443054f8d66ce66e4b57a7e38e");
            result.ContactPosition1.ShouldBe("ae2b878989a94d6890b2f6091f82df40cef01fcda9d24d2ebf60defd23646a8be7f53702c1ba4842b6c54f1cb5c2517af54acc0359f74dbaba1853418482c4567e4783258b27412cbb24cba2f7a579d45190fcea32344ff8b2fb12c238057480bdf92f4c48dc4018a5ac0c8c7bdda7b5b6db28feee48426f8195741152");
            result.ContactPhone1.ShouldBe("78427d05e92e44f9917be87c0989274b7169fda4a5774e5c97");
            result.ContactName2.ShouldBe("756846e334f349d79357f96417035d608a5be3768f7749ddabd535f104464d30ab59258aeef14621973fe9f889fad206fada12051fe041b0b63aa352b432e45cfe8571d2807f4446bdf738");
            result.ContactDept2.ShouldBe("767ee8b6608e4709ab8f222507b1426da3b84022c7424e0fa7f3463e6f497ee7cab328038528441aa5a633550a021c4e2f340130859d43e3a77b4f059696e495a6affa09158449b5815bbe");
            result.ContactMail2.ShouldBe("0d4174d901b842b6b12507bef5daf52944259fcf07a04e08a36c55dd2dffc53c04dd4c7ad6d94eb9b91ec8728b79effc91c40a4a75594c53a874d2359435b5c8d32f3e4b14dc49a083b788");
            result.ContactPosition2.ShouldBe("10929c67c5df4a0c9cfd85f00757bf7592ebc62f820a46a59d1a42c9bb02eab9ee43ffd9f95141f9b3b4a29176851156746e63294fe74dbe84e49a95b7f0ac305928b3aa67924308b4858397a218f082e85caf6f8d314bcc8dc9c820c84e555f69988fcd92be4065bd149b33a8506eeb5bbc7c15ae6549cfb40aba8b31");
            result.ContactPhone2.ShouldBe("cefcfc41a6a5432a91bb7ddc7b1042d54e931af999e64c2da8");
            result.longtitude.ShouldBe(192431210);
            result.latitude.ShouldBe(1319976627);
            result.Note.ShouldBe("9153657471684028a4c7d12a463172d1eee601c9188a4caa9c0f08b6502e8f4f00159c73cd0a4a3e97e88158aef6f5ca44d1514e7614414781919950b7ff9a302f98644bf68c4c269c99281236580d1fe45b9c9673fa459ea4cc0b9181601963b0afe881119140b7a270a89d058ebe4e1a17b066feb24af490c6137221");
            result.DocStatus.ShouldBe((byte?)89);
            result.DirectShareholding.ShouldBe(1069478068);
            result.ConsolidatedShareholding.ShouldBe(1146162804);
            result.ConsolidateNoted.ShouldBe("eeb6812baab34cb8b7969977b19f0d841bc5a97aca60");
            result.VotingRightDirect.ShouldBe(160930807);
            result.VotingRightTotal.ShouldBe(1155821001);
            result.Image.ShouldBe("cf5866f61a9e42a582eff0321a5e2560f39f0bf013154f6da9eb64337b5a001a3d60b12bebf64a11b98d4508f4c47");
            result.IsActive.ShouldBe(true);
            result.BravoCode.ShouldBe("146bd");
            result.LegacyCode.ShouldBe("79fd0cce747c446d");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyTempUpdateDto()
            {
                idCompany = 88601344,
                ParentId = 1962823914,
                IsGroup = true,
                Code = "85745ffd51714875bb89",
                Name = "5e8a73f0a92b49ed9c8d68ca1898b9ef9319aeb2be4d49fa841bf22bb6eb0b59ac524805f35e42f785a36274bd1a3ea449717793af76420a8e3233d1a69fa195745e317e7442480d8495b4dc587e0e08d48cf37b97f84c43904053ced81c3ad22d564f60a5914511b41c7530d80f0ce9eb9cd3863088486d870f3ff65d",
                Name_EN = "bd90b40c3bc2481a86faf55678671fa97fe5789a511643df8c68ad8082a75b393cbb7cf67e2c47e2bb92c2780958fdebac0dde9384224681899b7346f5d4d38158ba3e4d2ac345a295af8ec3a429446357f81be2b1f44beaad1e5707e586c11d401d445c2ec744709fd935e8b1be9a71e29f95e46eb344a48ace86ddb6",
                BriefName = "50a5c3e8aaa6471e8130645985734e56cccca10df47c4314a7b29f60dfa3fd6909a459f4b40f4e438de2183eea3054421032",
                ContactInfo_01 = "1e86257c68c445d485f522887a603d97106ee4b9532f44b5be79e7243a855453d02205f8086b4eda96801c790b2a8465db52d530c03d4d5d8351dd56680a906d3c1dc2efcb804264ab5b382837dc9fe05a1aee08b04e47cbabb7a0735a8528b8e2f4a1e00597446c9b2c6335685e7d6ae81e26a467e245e39cb3d85e0a",
                ContactInfo_02 = "33bebf5074ad4fd28a11657df57f368f06acdf518df14a98ac",
                ContactInfo_03 = "475ea71932fe466cbbabbaf6516c9a08618203aed9fa4c839c",
                ContactInfo_04 = "2cc7df3a9e9d437d841e475f6ee2406f426e7d33362d49b2bf45cb9dde897bc2dac85445acf24f66910140b80322d2d25d2ac3b71db94469b9624ffc80d458912638df75f42f40749c5011",
                ContactInfo_05 = "17c19222fdd8459d8ef94fabfa5da3881ffccac13df54e8eaf7e9d93fd3ff92b507d3d1fe99b43a1912133eb877b274ac35def3510734330aa6c5c678a7b58661f6cdd0e766842649c879acff0277467c44aa88c1896488c8c36378d6bb1df65ee3753c3105248d08dc4883709c4fa1d5938f14f92584b44a5809f7582",
                ContactInfo_06 = "c6b305305e6040d",
                StockCode = "82fbf",
                StockExchange = "f7cf5bae10",
                StockRegistrationDate = new DateTime(2009, 9, 26),
                IsPublicCompany = true,
                LicenseNo = "a7447a05e69a4ebb8ae4",
                License = "60a15f2d53574f7bb794",
                RegistrationOrder = 14,
                RegistrationDate0 = new DateTime(2020, 9, 22),
                RegistrationDate = new DateTime(2003, 11, 14),
                LatestAmendment = new DateTime(2006, 5, 7),
                LegalRepresent = "9f2c9acd976948519b55715c80c7c9ce606fed1b39f34060a22e977b5faad3bd4006e147a08846e9ab4dbb0fe23a8b999a24481c94b641b08f2ed5cd77bbfbf10a3269d97c934c7da73eca076597a60fe9f63a3d8d704a1392f4d8278d5f1bc3639eeeed67074815ae2c00b9cfbd32c8d75e62d15f1341ce96e6be969c",
                CompanyType = "be8a7",
                CharteredCapital = 1772607044,
                TotalShare = 1885791864,
                ListedShare = 927875408,
                ParValue = 1514768989,
                ContactName1 = "3f39da4ba18343b2ba8ffe2cba47252d5c04e0b3ffcd429e9e5f78074c5ea75f950a86ce7579419ebcd427cb43888c52b50355af97e244ea8f91a3fd28b03f4fa2f28f6f47eb42acbbc35b",
                ContactDept1 = "92bd696e2fca4ba1a7c9315cfe523db5ca7fff7fdb5d4f98be90fb0788f1db13a53412c3d0674a5b9149dda117a92e6e950e7dce79fc4dfdb8625c2b0d75a886daed855ca123494bba3117",
                ContactMail1 = "cb5e9a224d064967ba6a4348f3c8d6be77b1949356e444caba2c38227a91bad2204931d30033438ea336f2f2f1594d67623253576f604118acd2dcc4d76a701c3c7a9b23b53e44f48b4d25",
                ContactPosition1 = "4a91923191d8491280117b80bc785560d9e60e13144749ef9bdf19372267437289b78d7630d24df9a3882e4092ca8a0e9749d8534f4c47609f3cbf2bbbd457006bdc60b6381e4541a1ebb5068e03764f7291ac10359a480d8d292221565e9fbc5bd2d2a9c068414196bfbdb069f6b1785609ec4e4d884b6cbc7269a837",
                ContactPhone1 = "3d931da1ce754fc8b85cfff36cae126297fa308d5c164498bf",
                ContactName2 = "2ad2bafd6a4c400bb4854ec0c78ec87eeb267b9945dc400cb1132cb956e50f69200f1c70980b4f7ca1a9abf2d5edd69c57d9d9c41ad4490ba39b292f453938f4a5f38fa3f5874a579bc25d",
                ContactDept2 = "49665618744a4c1090aeec3ac4c6122c5bae1a94ebff4a0fb997255280ea3ae0fb0be3e47bc24300b65bb61e859385b68f22063776d743518012c9b6c69338982cedfce09d4b40a59c9ffc",
                ContactMail2 = "f4c0541ac8fe4d09a9ea4a49f5535f67f31f0da08bb745929e038dc8a79b47cf90a96030eb2d463a9b64b2d4a6d153d938332335c60044c7aa99a4887dd40815c4e41f8d33d7492c9c6a14",
                ContactPosition2 = "6a9367f10a5e4e78aafc86817a3aa0cb842b5f1eecde455abb620c36c93cbc8d8536e655707f47659f0bda5d15dbbb2d8663912d6a8f4f7a9c392dd51868d1c486b71e27395840a5a4cbe48d5d077e5d394e8a6cff124011823446b1ff68f5117971d62455f34d3896c9af4147d4b7ad5b6d663dc4234343a9f8527f9f",
                ContactPhone2 = "0780cd6e1d1b4691931b48938518ac6c6dfebbbf8c3e426f8c",
                longtitude = 170242974,
                latitude = 1907904283,
                Note = "59f798106b14465f9acaada08bacbbbcffd5f41ca6da41ed9ccc284097ab89c9c2247ce97c9f447e835bcefa401786059ae177556f4d417cb8cca960c02493e669edbd5d28114479b19a2634c3ae9b2659d5f424415947ac81e547d5bb30809f9c9e72bf8560400e9e3e919a9339c4280dfd43ee0962429586a67a9680",
                DocStatus = 74,
                DirectShareholding = 439512185,
                ConsolidatedShareholding = 5827588,
                ConsolidateNoted = "6bca9e4c424f49e18a4b",
                VotingRightDirect = 462413969,
                VotingRightTotal = 1642035726,
                Image = "06b781cd8e2543f3a21e759a",
                IsActive = true,
                BravoCode = "e5824",
                LegacyCode = "d0535828b3754962"
            };

            // Act
            var serviceResult = await _tbCompanyTempsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyTempRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.idCompany.ShouldBe(88601344);
            result.ParentId.ShouldBe(1962823914);
            result.IsGroup.ShouldBe(true);
            result.Code.ShouldBe("85745ffd51714875bb89");
            result.Name.ShouldBe("5e8a73f0a92b49ed9c8d68ca1898b9ef9319aeb2be4d49fa841bf22bb6eb0b59ac524805f35e42f785a36274bd1a3ea449717793af76420a8e3233d1a69fa195745e317e7442480d8495b4dc587e0e08d48cf37b97f84c43904053ced81c3ad22d564f60a5914511b41c7530d80f0ce9eb9cd3863088486d870f3ff65d");
            result.Name_EN.ShouldBe("bd90b40c3bc2481a86faf55678671fa97fe5789a511643df8c68ad8082a75b393cbb7cf67e2c47e2bb92c2780958fdebac0dde9384224681899b7346f5d4d38158ba3e4d2ac345a295af8ec3a429446357f81be2b1f44beaad1e5707e586c11d401d445c2ec744709fd935e8b1be9a71e29f95e46eb344a48ace86ddb6");
            result.BriefName.ShouldBe("50a5c3e8aaa6471e8130645985734e56cccca10df47c4314a7b29f60dfa3fd6909a459f4b40f4e438de2183eea3054421032");
            result.ContactInfo_01.ShouldBe("1e86257c68c445d485f522887a603d97106ee4b9532f44b5be79e7243a855453d02205f8086b4eda96801c790b2a8465db52d530c03d4d5d8351dd56680a906d3c1dc2efcb804264ab5b382837dc9fe05a1aee08b04e47cbabb7a0735a8528b8e2f4a1e00597446c9b2c6335685e7d6ae81e26a467e245e39cb3d85e0a");
            result.ContactInfo_02.ShouldBe("33bebf5074ad4fd28a11657df57f368f06acdf518df14a98ac");
            result.ContactInfo_03.ShouldBe("475ea71932fe466cbbabbaf6516c9a08618203aed9fa4c839c");
            result.ContactInfo_04.ShouldBe("2cc7df3a9e9d437d841e475f6ee2406f426e7d33362d49b2bf45cb9dde897bc2dac85445acf24f66910140b80322d2d25d2ac3b71db94469b9624ffc80d458912638df75f42f40749c5011");
            result.ContactInfo_05.ShouldBe("17c19222fdd8459d8ef94fabfa5da3881ffccac13df54e8eaf7e9d93fd3ff92b507d3d1fe99b43a1912133eb877b274ac35def3510734330aa6c5c678a7b58661f6cdd0e766842649c879acff0277467c44aa88c1896488c8c36378d6bb1df65ee3753c3105248d08dc4883709c4fa1d5938f14f92584b44a5809f7582");
            result.ContactInfo_06.ShouldBe("c6b305305e6040d");
            result.StockCode.ShouldBe("82fbf");
            result.StockExchange.ShouldBe("f7cf5bae10");
            result.StockRegistrationDate.ShouldBe(new DateTime(2009, 9, 26));
            result.IsPublicCompany.ShouldBe(true);
            result.LicenseNo.ShouldBe("a7447a05e69a4ebb8ae4");
            result.License.ShouldBe("60a15f2d53574f7bb794");
            result.RegistrationOrder.ShouldBe((byte?)14);
            result.RegistrationDate0.ShouldBe(new DateTime(2020, 9, 22));
            result.RegistrationDate.ShouldBe(new DateTime(2003, 11, 14));
            result.LatestAmendment.ShouldBe(new DateTime(2006, 5, 7));
            result.LegalRepresent.ShouldBe("9f2c9acd976948519b55715c80c7c9ce606fed1b39f34060a22e977b5faad3bd4006e147a08846e9ab4dbb0fe23a8b999a24481c94b641b08f2ed5cd77bbfbf10a3269d97c934c7da73eca076597a60fe9f63a3d8d704a1392f4d8278d5f1bc3639eeeed67074815ae2c00b9cfbd32c8d75e62d15f1341ce96e6be969c");
            result.CompanyType.ShouldBe("be8a7");
            result.CharteredCapital.ShouldBe(1772607044);
            result.TotalShare.ShouldBe(1885791864);
            result.ListedShare.ShouldBe(927875408);
            result.ParValue.ShouldBe(1514768989);
            result.ContactName1.ShouldBe("3f39da4ba18343b2ba8ffe2cba47252d5c04e0b3ffcd429e9e5f78074c5ea75f950a86ce7579419ebcd427cb43888c52b50355af97e244ea8f91a3fd28b03f4fa2f28f6f47eb42acbbc35b");
            result.ContactDept1.ShouldBe("92bd696e2fca4ba1a7c9315cfe523db5ca7fff7fdb5d4f98be90fb0788f1db13a53412c3d0674a5b9149dda117a92e6e950e7dce79fc4dfdb8625c2b0d75a886daed855ca123494bba3117");
            result.ContactMail1.ShouldBe("cb5e9a224d064967ba6a4348f3c8d6be77b1949356e444caba2c38227a91bad2204931d30033438ea336f2f2f1594d67623253576f604118acd2dcc4d76a701c3c7a9b23b53e44f48b4d25");
            result.ContactPosition1.ShouldBe("4a91923191d8491280117b80bc785560d9e60e13144749ef9bdf19372267437289b78d7630d24df9a3882e4092ca8a0e9749d8534f4c47609f3cbf2bbbd457006bdc60b6381e4541a1ebb5068e03764f7291ac10359a480d8d292221565e9fbc5bd2d2a9c068414196bfbdb069f6b1785609ec4e4d884b6cbc7269a837");
            result.ContactPhone1.ShouldBe("3d931da1ce754fc8b85cfff36cae126297fa308d5c164498bf");
            result.ContactName2.ShouldBe("2ad2bafd6a4c400bb4854ec0c78ec87eeb267b9945dc400cb1132cb956e50f69200f1c70980b4f7ca1a9abf2d5edd69c57d9d9c41ad4490ba39b292f453938f4a5f38fa3f5874a579bc25d");
            result.ContactDept2.ShouldBe("49665618744a4c1090aeec3ac4c6122c5bae1a94ebff4a0fb997255280ea3ae0fb0be3e47bc24300b65bb61e859385b68f22063776d743518012c9b6c69338982cedfce09d4b40a59c9ffc");
            result.ContactMail2.ShouldBe("f4c0541ac8fe4d09a9ea4a49f5535f67f31f0da08bb745929e038dc8a79b47cf90a96030eb2d463a9b64b2d4a6d153d938332335c60044c7aa99a4887dd40815c4e41f8d33d7492c9c6a14");
            result.ContactPosition2.ShouldBe("6a9367f10a5e4e78aafc86817a3aa0cb842b5f1eecde455abb620c36c93cbc8d8536e655707f47659f0bda5d15dbbb2d8663912d6a8f4f7a9c392dd51868d1c486b71e27395840a5a4cbe48d5d077e5d394e8a6cff124011823446b1ff68f5117971d62455f34d3896c9af4147d4b7ad5b6d663dc4234343a9f8527f9f");
            result.ContactPhone2.ShouldBe("0780cd6e1d1b4691931b48938518ac6c6dfebbbf8c3e426f8c");
            result.longtitude.ShouldBe(170242974);
            result.latitude.ShouldBe(1907904283);
            result.Note.ShouldBe("59f798106b14465f9acaada08bacbbbcffd5f41ca6da41ed9ccc284097ab89c9c2247ce97c9f447e835bcefa401786059ae177556f4d417cb8cca960c02493e669edbd5d28114479b19a2634c3ae9b2659d5f424415947ac81e547d5bb30809f9c9e72bf8560400e9e3e919a9339c4280dfd43ee0962429586a67a9680");
            result.DocStatus.ShouldBe((byte?)74);
            result.DirectShareholding.ShouldBe(439512185);
            result.ConsolidatedShareholding.ShouldBe(5827588);
            result.ConsolidateNoted.ShouldBe("6bca9e4c424f49e18a4b");
            result.VotingRightDirect.ShouldBe(462413969);
            result.VotingRightTotal.ShouldBe(1642035726);
            result.Image.ShouldBe("06b781cd8e2543f3a21e759a");
            result.IsActive.ShouldBe(true);
            result.BravoCode.ShouldBe("e5824");
            result.LegacyCode.ShouldBe("d0535828b3754962");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyTempsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyTempRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}