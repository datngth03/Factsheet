using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanies;

namespace Sabeco_Factsheet.TbCompanies
{
    public class TbCompaniesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyRepository _tbCompanyRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompaniesDataSeedContributor(ITbCompanyRepository tbCompanyRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyRepository = tbCompanyRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyRepository.InsertAsync(new TbCompany
            (
                parentId: 191968159,
                isGroup: true,
                code: "f56dea1e298a45d7b5f5",
                name: "fa0383775db2411ea11e508b258f24ef3f0fef496ea3447fb6e56ce717a7f7e9ae1224eeb24b43b29d5a4bb80a893b3fffacc93db8e741bfa44ccc125bc726e379604c925a7c420385ffff3e5fa9cfa706ba3df434e54713a6920568572740da5fef6c3e532a4ebd9ed8999dc4c2b85a3bbedb88bae74922a9ca7e5aa0",
                name_EN: "68459582853645ccb7940032e4d2b1437da6dee973274ed8aeb07c14a79d86b2e65acf8c517c47528b09f831ae22335548c2dfd46c2145adb836a3ecd815c2ac4aedf7c363ab4f5eb139dbfe0e9a74b8fd6a7f781b0c41a5993df0fed94836c7fbe62e8c862648a0a6d0b0d20b8e603f22989b803b0e48baaf813bbda9",
                briefName: "7dac742e3008493ab1a5edd8d6733224e5704396fd5a49a3b62e954375cff42eecb97f0496594699a4aa68b7e3a7eede15db",
                contactInfo_01: "3a873ec8c59243039fe8f9774db81113c817fb0126bd47dcbe954f1cca0f426a6ca081f2ebef4c97b8fd58575d4dcba8459ba7fddb154e509e9699fa4a6a83720aedec6b05b74909a93930b469def8b6eab9507dd0864d7f8d03dbd77ecb273010ecad7b795542e2a75fa536cdacc213726894df097645cabcf9fc6d96",
                contactInfo_02: "0d739a9c7a3e461c87673ca7476cd32f38f971205f494c3f89",
                contactInfo_03: "41bb44c9d7a440d49d4220f656b9de74c2b4e88290f44e1f8d",
                contactInfo_04: "6a3f3645e9284f13b976281ae199c77a73ac421e36b7496db559cbb92f2b0cb6abea64510ef94761bec634f5c047c78de432ca65734c4093ad921c42b4a6eeef7aee753a65b347ab95143d",
                contactInfo_05: "c7ea2b906f944ed5a92fb76236fe74696cb3633e33264dc58acef16b35fc8f65f4b8d499405948aba47b675cc5b1a02e5c0467a7831a478a8aa1571172c65a177cf0b8a79200445db28ccf4c5708a5422ef9db278bbd4f589bdc9580684b46e9d9d8dde411454985843bdae5f54818a8245d7cc805d647bbb6a0f36b68",
                contactInfo_06: "1115b47347a14d3",
                stockCode: "6563e",
                stockExchange: "12cc89f5c4",
                stockRegistrationDate: new DateTime(2010, 11, 18),
                isPublicCompany: true,
                licenseNo: "3a9385ba665442769e27",
                license: "8b1f3e9afe5248ec867b",
                registrationOrder: 126,
                registrationDate0: new DateTime(2023, 7, 3),
                registrationDate: new DateTime(2004, 3, 5),
                latestAmendment: new DateTime(2017, 5, 7),
                legalRepresent: "7df29409aa9f4d7d83b03bc65b671deea42eb2356c874e47915fe792db56877f1e67fb0a93c2403586f3ca7cb51b27a384a8f5fa20cd49ec9f144fcf2c19fb18c0057b79c5d145f78171f8b2564f0c0e8cb9fc30cb40422eb032f9adf0c5967d5b2f7019680746a8954b77ba6b03bfecc09d60c23c7c482a971858cac8",
                companyType: "da068",
                charteredCapital: 876760270,
                totalShare: 581706173,
                listedShare: 1950925364,
                parValue: 1369609351,
                contactName1: "5fe5d9e29c204b80b13b1ee39d5e75057e50801856b7490c83712ec528d1b723b072ab688f45441cb6dec57a3be9fe037c5df6ba3d0748e792e44287b735d44089f83b53c4ca4e4db5c617",
                contactDept1: "2af0a56299e84fa999cd647fb5cd006e28ba46062b594359a3770849d74834c0408e84f77fb04057932844b88e09f167568b8cbc0e1444569b604d6f2a3112a77a0ff1c188e54ec6b76816",
                contactMail1: "89064ec966904bf0bedd82c7afc451e99db500add2e74fea80429db466437accf3b9472b8b2d4788baffdff616ebea0777d2e43d797542b896aaf116a1addf95e71fc23e5dc84c35b061e2",
                contactPosition1: "252a2bc0cdb04b71b6f7e58c030d90191ca208d790a64fa08ba9f49edd944ce26b13d81a36314af0850f6acf9631a3410af6a512cdce440ab256661d4bc94d62b652bc85e96f41ccb9794f6e60c44abd2e6c56000d8d47d1b921aebf08b235275b2844b2eba94c8c95355512dc01d369b23b273ef58e48f1a6be4755b1",
                contactPhone1: "08462871f5ef470abd646e75e587d7f5b288a742334a4c7088",
                contactName2: "e2d348a01c4c4dbcb2403d3d7a659e81eb440f76ae634bd09de4d46541d70da3b342d016b9674d3d8877bb2ea4995eb00e753efc0ba14618af29b6b8d90e8727dd9ea6e508884ec0a78ba4",
                contactDept2: "b6ab4a4143644585a4b48aa22c183790ef1fe98d0eb94e199f9dd4ab2abb97a7d46757e71a064606b6579db682ad6d4d0e589be988ae4d56af0b10bc6ac98b8491f39a185fe34f1e975f80",
                contactMail2: "0ec6558ad80147c0b2760f927820578c3ef53a9af6ab43a5b92de47b03f16bdd070d3639d12a4e40bd56305d052da07ef18502d675d244a686c491259913ba4c88dd20fec9b74b7d911118",
                contactPosition2: "66682eb2d46f41f99532e1e35e84595eb0ab61d1abe7455db38af20a654566069260db768c19478e88e5e1d470f2a19b95addc72bf14425ca9075f08970be531c3dc8a84819a4a08ace0c379efb96e0d515071db9c234a3b89858aef494e0aeeb30be8a06be741fa9cdf4fbb55cb40066839a1e5cf404fc3a86ca13e52",
                contactPhone2: "1ef54c6e33474af185bc83df37b13ed468a236b85bf2438280",
                longtitude: 1544072860,
                latitude: 1597880625,
                note: "dd164e4e79e241b5a62f8086f34d259f8f1cc2d48f824de3a6f30e1182aa5be10345d6c07efd40dca0c909d51e986cabed09bed34b734f578775c9469108ea92955fd3e6f9674e62893fde33bbf1566f50b8942566064bbd92c5265999b2aadb480c2a3e87c944d7bfb5125739d4795d78d8b7d09d37406790b8ede26c",
                docStatus: 26,
                directShareholding: 66651130,
                consolidatedShareholding: 1743120482,
                consolidateNoted: "f08fe0aaf0444455b2833f7ae82453522e9c0ed9669a46318a0d1bfb17efa367b0518285582f496abb0c",
                votingRightDirect: 1528013073,
                votingRightTotal: 2011189648,
                image: "44a9aac115e84fa9ab12e3a6d3e602a4045f28f1466146e894e965634e940d3c1746c9e51e584dc093f547324dee7bad",
                isActive: true,
                bravoCode: "49a36",
                legacyCode: "f6c87ad979444457",
                idCompanyType: 799042096
            ));

            await _tbCompanyRepository.InsertAsync(new TbCompany
            (
                parentId: 1397165275,
                isGroup: true,
                code: "b7e096d6f4364de9b313",
                name: "0873dac18fb74e22bd48ed51578857c36d1781d99aa342d787d319ac8f4a2286a9e3d470573f4cb6a9ef14baa248dca7b01ae32f90ee4ee7b90695171286f79de94fdee6ef7d4b5aa2cb5315b3de7988a9a474632b1e4c6dada848ad32deb8116c8d0160d68846698e1b7a096735c30df84d67f42bec4462b4b547f17e",
                name_EN: "48cc173885ac42e08dc8da4eae37750af6839f3d47ee4085a0dda04bef567d831c3e8b07ab744ce0aeba699894ffcf1165d172d85ae0491c8d8aa2e1409f30f70d4d4f668e9f4020b1693594c660c09f6b29b8771a854dbb9f3ce0ab33d88256e120426420954a2b93461db7d2582513f14c98e91e9c49bcb80c090574",
                briefName: "7ccca18a212d40ef98483993a422fa7d5ffcb3e55b8f468bbe221fd6da87105c5a7201e547044cca848c286981446fd223ed",
                contactInfo_01: "96746711d0914bba8c1b13c4d98edcdd0c04062f212f401e95e6be8fb7b147d404e11328b8a9494cadce595ce64edc0f6d1c31ac5f524795bc1352cb32e14671ed3b7db17883462eadac8d134dce275767cb050a352c474f84cf01a547ebfb23cfdb37730f0845e082f66685df3455e1713db4ab7a2d4715b9070abd98",
                contactInfo_02: "be7733fac3854632b77f7b08c76fc4e0ef73f218f3b845e998",
                contactInfo_03: "7de52fd3a3e141aa927d7a1c3b9af15a32a8716f39da420f99",
                contactInfo_04: "f6f4a7ae55394d5eaaca54ccfe18fbcd49579e843a674e51ab8b1fde4e81d95d32fcb3d9bc154f4bb9d06ccac3720fdc5c6f011c489e4941809f982def4dc28037dd33ca6d9940cbb0f52a",
                contactInfo_05: "ae79b797b3b944b0950bf6b3bc48be2eb4dd040f3be348708079bee5692c31c8f0a95c35aaf64fc189c054035d5a40c6cf55768da2a149aa9956b33d9a31f517c58d695a34c04edda1ce5ed9f551894128f7c440d8b0438ab48431384766c600a33a297e7feb4ae4a34ea1bb94a09f2a2217ecf27d3a43a99d5f6aa9b4",
                contactInfo_06: "3c3b73c9976f495",
                stockCode: "10134",
                stockExchange: "2d43d8769b",
                stockRegistrationDate: new DateTime(2005, 5, 19),
                isPublicCompany: true,
                licenseNo: "d1f1e102e784440087c3",
                license: "f97e7e76063a49a6bab6",
                registrationOrder: 73,
                registrationDate0: new DateTime(2021, 7, 17),
                registrationDate: new DateTime(2016, 3, 11),
                latestAmendment: new DateTime(2003, 9, 11),
                legalRepresent: "c1a303cc08ba454b9c2ce0acba87a953a4dac3afc2ad40d9bc6158e1437523f38c2304606a7a4ab4b5b009b94b3d367e8f7bb664933b4c3583fe1e771b0d7cec298a4c98ad134b09a6c3f627f51ad639de0d9f0041ad4baa9466ddbc9cf70497381133e57d334e8c8d45afcdcf6e63ee74441e1e1cb24b3f8cc69e3eef",
                companyType: "8dce8",
                charteredCapital: 752195193,
                totalShare: 1360805121,
                listedShare: 194218502,
                parValue: 1175031204,
                contactName1: "2347699d36004003881b4c7b5c0aa3a0c94c0fded3644f359fd39f79b4d93f12d65a80f6633c459294d9472e2b4c0e2d3308fa7cec774c5a9b35d78106361d6f35e7d305186c4912ad4c63",
                contactDept1: "3fcc5f6f0e734ccd8a799f78490822c1b093a80cc09749a783215e13f661aaa0971e8f11dda241f085cd1fb3fafdf9d55ca1c63a29d24611b3428ca5fcd407f9a5b0583a92ef4f3681f459",
                contactMail1: "097aa390b85a49acafd47524942924eb8af9a09e807447f685a1be1219b67a3155696449b7fb41cdbc00811e35368d01969cb03399f346558d3d93538fba214750d74eb043f9430ba171cf",
                contactPosition1: "1131917063e64924b8a36e617d88f87765ef156da6594bd684226da563efe37e4502fa185b004f64b7d8f0bf313213851565c308dece40538ea5f5974718ca6a42e23870ee6c4e7e8eb0908d1d57931726e604a6c8a64aa5a885ac70f99f703a41d1e105e6e944d987e24a8d703cf8c4af595adf6ed344d197d2115426",
                contactPhone1: "be4336bc7ae849249d0e01e6aff857f08f8942eaaca44316bd",
                contactName2: "8a10cc8142a0491a8383d76ee61516c2411df4f36e014e66b9aaf669c97669aed136b5e4a9a643c98984b84233dbd5ef179655b84cdc485c987d5f75337ab9404f469e17ef8346b888cc32",
                contactDept2: "82adb1b319d84938a8b8975780f96ed791f96af0cdaf437c813ea60f5108651ca9f81518b4144ca780d3d25274807374a077bd49c7634c0aab5a0229907aef4c245acfca006c4641a12371",
                contactMail2: "081cb94043654aea978308ebf0ef660f88864883bd504a9584d8afbf1493aebcaee85108cbb04e268adef1ca7f9e2189926ed6860cf74765b125972066c3254df9104418fe0d4bb293ca97",
                contactPosition2: "cf02123aa29d40dc89a54cf36c26fee20b81c4cd09794f859bbbdc287514eca58214113f83984a99a57627905a7316d2affd94964677471b9cbd37b8aac51817e50400bb810448c684c9a699db87be4ec55e74b3a291416884eb15d9d5b6da7d16e13f3075cb4853b00043645bbf989fe1629d0d03e54ec78766e7a39d",
                contactPhone2: "507a2be27c784828ab5afbf08486d67ae85d045785d941fc93",
                longtitude: 2016378211,
                latitude: 1121227279,
                note: "75c66dad018741459cfa10ce727b1ee2c0e51d8b4c854cd7a89c6c994528d605cc781c859f6148048c5cb99b4f4547d8d6a8be00534143e2af534aaf41b8fa6f2d358b37c6184cdaa769c85cdc3d69a5ae6854aba77f4901baef2d447c2270126089e8ab15114aecbb0c52ce1f2fecc73d5d22b08df9433896eed5f53b",
                docStatus: 102,
                directShareholding: 1286927387,
                consolidatedShareholding: 913769013,
                consolidateNoted: "911d2272c96d4c1883c5cee2d54716afd728de6689b24f43acbeea6e399a595e0898",
                votingRightDirect: 1639423840,
                votingRightTotal: 679234578,
                image: "c9fedae18ef34f3ba835f28d579a8e54d35f102294c54776aee2581004908c990a98e89",
                isActive: true,
                bravoCode: "cde19",
                legacyCode: "4fee2deeee58425a",
                idCompanyType: 326698656
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}