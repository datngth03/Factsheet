using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyTemps;

namespace Sabeco_Factsheet.TbCompanyTemps
{
    public class TbCompanyTempsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyTempRepository _tbCompanyTempRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyTempsDataSeedContributor(ITbCompanyTempRepository tbCompanyTempRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyTempRepository = tbCompanyTempRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyTempRepository.InsertAsync(new TbCompanyTemp
            (
                idCompany: 462339222,
                parentId: 149323290,
                isGroup: true,
                code: "c162f1faef154836854f",
                name: "eecc7c4fac2f4374806232e2d97dbbc666999aefaf91456ca9be91903e9dee097285626e05d1485b8cce958f646101b148c68592bed04ef08391cad6e9adedc752f21ffcc2f147cfae575c71454b01c28944a09f08cf4a26843a307d5c6c3359c6d862d77f01467398b042a7240eb65e0530ac10124247828f3698eb5a",
                name_EN: "4d246de05be44d6b82c29aa63bc149a1c232e7a39d2b49ed92a0b0eb91cba4418ff90d16b3e34ebd9ccc07da8997612ec2108af746a34b4897e794460f405138a7a6d04bec0740ca9ca86d9fa2d9a5c58a0a9045232444d48d58f45de842c72fc048caf261ed43f3b14530426cecd08d26877d225bb54c87910d43c8be",
                briefName: "5c525ef7b64b40efba3bd58924fd0597bfc772e96087472f84be960566cbe456c90a1df9dd0b48d8af05820041083da46b3a",
                contactInfo_01: "db345080358f47c0847eb1cf0fdd70c5d0116ed90e5d416799d696be2aeea9b692282ac8f132473aab081dfde9d17c75f412f0ecb4ac4417bc552bc6a578b0e2d94c35f66c484b4bb77ba52e2dc21bdf57564a5f978a4cba9ce18597249952ff27de435561e6497782d02a0c5b0d9facd218d59f53bf443890a232b85e",
                contactInfo_02: "dd3da9364a5a48a2a715e8472c6e0efac0da43699463415fa5",
                contactInfo_03: "aaa25ef74bd04a4ba744888c5df9bec8fc77417e54ab46d3bd",
                contactInfo_04: "16bc9f19fffa4ad99e70f4268a22b5286d47b9bbe8d44150ab1d41b3d19c642439b47b0a80414ee08b4cb5fe5ec8e4f1f16419a905724eb2b9980a315cf6e738d61db61a0755409c90e9bf",
                contactInfo_05: "aaf2ed58c12f41bca7344d57ef37858d087b4643ee24468dbb17fadbb185af0914db26aa3c87489c97821b7ca1482a23659bba38c4994198ab08140768f1d1613de54d0bba11465898cc75c1fcebb23cbe5dc3823a82490e8de952d179215b79f23f837b07604e51bbc9a0fd9f7b916dc86cd2cbcde74f5ea1347f7ff4",
                contactInfo_06: "48656c6e70ba4ff",
                stockCode: "01742",
                stockExchange: "05329ba653",
                stockRegistrationDate: new DateTime(2008, 2, 11),
                isPublicCompany: true,
                licenseNo: "2f54efcdcca94aaea206",
                license: "dd69c3de8ce94e2085d9",
                registrationOrder: 71,
                registrationDate0: new DateTime(2017, 9, 15),
                registrationDate: new DateTime(2008, 9, 6),
                latestAmendment: new DateTime(2023, 8, 22),
                legalRepresent: "48a70bacfad64f51ae882c2624569c713bdb12f99a1f4736b8d9cb9d7bb99d90170cb2c5b03445b5a5dd21dd9bd0c44081857f896cbf405bb8bef87b595a61a0dc04dd36b1bd47d0976a0e656b268a2b7f4c1b985cb848b7814a0ffdbd70a0700c32ee50bd954a3dbb44578a58230e0cf33c67e81cc04ddb99220203fd",
                companyType: "560b4",
                charteredCapital: 386197266,
                totalShare: 1425962013,
                listedShare: 1467111659,
                parValue: 801133224,
                contactName1: "efd5d676ae7749c5a779a2d74afcc278902db683cf0b4bdcb9a14cd9172a888a3d2d6d1f8ea84ac58906348a4493887ab8fe3b7fb7e4405ebc4b0b3ec84d6920d070b944ea4d4e9dbdf86d",
                contactDept1: "8820eda583d4455e8a3e6d32e49c19756be2637c1c654798b98b5619c003c4cf28e7851470fb4029ab42c5f97e4775369a94c60df6014367bf1ce07fdd4730e1858d6eb0ae1c4741b05beb",
                contactMail1: "559d8c3f9de04fdba08adb5d608002d2937804a57cff4678aec13f3436bacdf72e60214d602743639d3c2db527055d84427f68b77e99408ba5e87490ef496a85e954eea19688448ebb7757",
                contactPosition1: "3d2399d8b31e45b8a8cea5107c095991b2bbc46cee6d42668006f0510efecf6fa1405223daaa42a5a05ac2a9b5fd4d0c09bde00bcdcb4c5992cc9382fbfe5e07088f75331b7b4a028f5dafa19d138f7ffe27522dde104b68ac0a2694421caa13904d957e59e143979ba019ae088736e3420b5ce62a4744f784210ca1c5",
                contactPhone1: "cc5709efe7ce4f45a7394732ab612f501dd02ba77d4a413696",
                contactName2: "d478b26d932648dcb801d06cac89d804c48ab209d25845e1a25df187a24624783a19a4b0c405473385c871d7ce34f19ce7a0d78029fe454d8fe2b756535986d7a464863cb29d4f639fab89",
                contactDept2: "025e16edb8234730a2d5215de937809125806601639443b8aa75679c9496ed3a9be91d6cdb8e4344a71fe0c97e09900b4721bc5bbce44ddf861a156003bef5ba09031712dfb74bb6bef608",
                contactMail2: "1e3c0fa789a447c3b2cf7487f8806492b8bbd676a1ea40bca0a27191bb815aefe78620fe7b884affa5f57ec24cb89bbe7794efb9447949d299ed9c0850865ce11f1192e60b5a4d3489856f",
                contactPosition2: "a3c25849eec34e96a44878d0f05b74b93f31a5bba4164f1fad89e0c758d9d3ebfb8bd25c968a4296b50a0260b75fe32efff33b60cf2b43a4a946c572ca75798390ca8478518d473c95acd67423ff4696a2d94ff11a054ca498c3bb69194181c28f5295d63e184c5dbcf8c08eae2de821a2ad20433aa64abeb0fe1a7a6a",
                contactPhone2: "9cf400aa98a44761a283dae5da96fc32bead7045b6ac4243b4",
                longtitude: 2000031375,
                latitude: 1742890712,
                note: "89e0204f371546d1bf10b8146d0ea8a1f64145ce04bf4841950a7c5d149f3505ec8f4389897d4b6b89e54a9665554ac2666eac47c445448d825ee598f865b38c4b3664221ba341e8ad79bd2a4951ed98ad2d4141ae59413182225a0fb6ecf626941b3443188143a8ba9a871c8b41450c559ec459c2ac4e2d8a6ff78a8e",
                docStatus: 110,
                directShareholding: 190403063,
                consolidatedShareholding: 907375482,
                consolidateNoted: "cb304e5c0973456fab63211a4216a78a5cb0e8850c6b",
                votingRightDirect: 1018915995,
                votingRightTotal: 1263178521,
                image: "37dd8ace43c240faacead08f09ee3b49e4a7415f52544cfc9b63b983595e40390c370eb2ccec4db19ec4d3e874a58",
                isActive: true,
                bravoCode: "c4d89",
                legacyCode: "84ec9c4a69254dca"
            ));

            await _tbCompanyTempRepository.InsertAsync(new TbCompanyTemp
            (
                idCompany: 2007363261,
                parentId: 202039814,
                isGroup: true,
                code: "ee3c880d65a24b40b181",
                name: "9676469a3a0e40c9b3d89ca06423069c2859a042314540dbbafdfb3ecdc4b08dd1f36d1658404b22be2c961cfe36561a9f18e4bd573440fd9b46fac9734f6fdd9b89b3b937a14044b30f54d441551e3231fbe6f208414c7d94865f7fe15e44d95c0a186b635f43b69e0ea21a2ef7aa9a73dcad47a28d4d08aa5e6e5452",
                name_EN: "24825efc83844abf9c37f96c7fd2dad0212beb2dad5d44f7a5f558832667945bd6911118f3a3432da3768925f29e1042ecdf1c9300a2426ea6cef02967673f3a1122fccb9ca949d79ae01375bbbaee7d606ef6be3ce148b88687609bf92ecde46590e9db0c5d4003a0adf0cc867a2b07962f7c5cc847471f8afaeda4f9",
                briefName: "18fd3c86c2e543b08d640347ea4513163326afcc26444cb6a1bf547c269ccd63e82020709a01481aa38d4616d3be1a2177d8",
                contactInfo_01: "de9f7ebbada144d6bb8660c4c78c558436070345a999404bace11932fbbda22885a11ddf57a449e5984595a10a6fbd5cae49c0b8286f43e5874764fbf5072fa16cf73ebcbc904ddba5108869186a0219df466669bcd347c58922e3dadf53d3fc95d9263c7d6a46f6bada7bd9c7374210ba695bfe89da462eaf4a9a7fc0",
                contactInfo_02: "4dcf0caa6fcc4936abd0c4c1db96a09f907b3225ba2b4b90b5",
                contactInfo_03: "ba5a6ccdea6e4fcab21e2890dfd2cc3fc211d390be064ccdb7",
                contactInfo_04: "af4fc34500014c5d93b70f3f8d6d9cccb478ae5b81584c8a831d8694ddaeca7d363e3eac9e93467e880cff81ffb5a30091e9ee7fd32c44d69f46c1cf495266b93a3628182e7345799cf73d",
                contactInfo_05: "ee9478da8ef54bd6813aa2f02cff68c97535e08c859d48f8b295534ee5a50bc2959ef2299d5f40a78f997e4e979438096d461746939344f18b66188c88762722ce92167c786b4484a0dc8bfb6200157c8023dfa8397748098b23b1aa55515e18e13487c8742f4190bc4ad932b26a4e108368be578c5442a8a0b9e7df40",
                contactInfo_06: "e70125ec75c8413",
                stockCode: "7ef98",
                stockExchange: "a854bfa621",
                stockRegistrationDate: new DateTime(2005, 11, 2),
                isPublicCompany: true,
                licenseNo: "4e74ba783aa34b6aa385",
                license: "f12645f3bc55490e9790",
                registrationOrder: 111,
                registrationDate0: new DateTime(2014, 8, 24),
                registrationDate: new DateTime(2007, 6, 11),
                latestAmendment: new DateTime(2006, 2, 5),
                legalRepresent: "cbb21d29635c43fa873172ee75ff1653980047fb5dd541aeac669f91cc7d958e6c287d6f8adf4f3f99f013f6864a63a99e7c00388a6a4c29abef1fe42b714b7d4cd4bbae2af74ca1b0df74eebe73d33940a9a93c572241b4a8fa9f215062ffeab9ab6044268541a5beb35a2a671298de9c5e64fc38de4e5a9ecfb5e3a6",
                companyType: "80d87",
                charteredCapital: 1920788311,
                totalShare: 1177107221,
                listedShare: 279646829,
                parValue: 1421382163,
                contactName1: "3d3f35564d8b46ff8de0348546c1d300486b1e42f57e42dcabafb19e199e6cd65e37158dcbe449cb801323cc96e074f97f424e9074b848679d48b33efa271faff83bcafdd9d442ff8eda9d",
                contactDept1: "bc5f6ca192e3400ca91f2304b4e11bdcd349fc13124f4eb2ba1209dbf655e7d33a878f4d1cba433c8d20123d662439feabcdc4570b914420994ba78879491a92d54c6b749a964b77bcf4e7",
                contactMail1: "a0f0b853ad344caaa8fba2173ddf70ef3f9be0e7cce04c80bd5d794e6586a634215f56f9c19a411ba652a85cf5359bb523e412869b4b4bc18a10c845a3013d1be48630c5fbac4df4bb0db8",
                contactPosition1: "8c1d3b2627684570bf148fa68e2e219a1f74048488594080bb90e7c20e70a781baa43bed7f434d38ad6c09e911c6b4da11e25f2b88f945c097b85728d0dcfd7ac4ed35abb2184ed29c3de9bfa48422c8d55593961c4644088022918656c30ad0925f79682ceb41ada48828f290fc712d1d59e971385c4bd99c66df29cd",
                contactPhone1: "16648208365a49d39dd5c7c89481b1b5aa243f3b9249446882",
                contactName2: "2517d2565ff1496099c6f3c3c21abe48f122a0dc3854447a905217442e4f70cdcc6fc3b9a7f1479785b3af103220407fa3afa37d5b2f4d7bb50fa27d95cd3ae0ad876565e0b844eea3b2f7",
                contactDept2: "563dae03ada74def96776baab7a65bc5ac8ab3b9324949c79a83a46fa22a2b01b40bd5a5aad945c9a523e7f4003ad22526d527e97f1c46acad5f423ef1f9fc132d1b9304140748e1b20ea8",
                contactMail2: "7e37599798a2443ca00bae9576b4f6e7a1db8dfb79614a24903f04a22cfc7833aabe45a603734bbe928fa9661313dd8cd84c1a0987814c79ac3640f1be8df58551ab1b36ff3a40cda4494a",
                contactPosition2: "459235f2373844ad9148d69284300efab83bb1cad24b42a19635a37d79551e4d2c0a008e3e3e497ba5ea39fc737459351ddc7c737eed43eeb95c1a63d33828609b2ef65d6eff4c60abb6908a7bc2fe8b7843635cb68248958d284d7839e5c0e958ddbf23160f434ea4dc7b34eb5e8c30852adf62b07c49d1978ba91bbf",
                contactPhone2: "aeca855b3f514e13b0913f5711c1582b9d9bfc621b6b48daa5",
                longtitude: 1661222487,
                latitude: 856668148,
                note: "d1f9144d419f4f54a51aa60f34e34f041adc477fada743cfabb6a4b73c713253230b12d166634de4b2c1c9b3b213ba6f820117c694f8488fb7eea48e25074faf4e601ece83994345b454b3c97bce630a649fddee24534655ab0d553e2f601f7c5c5db726702944eb9f3b2e5794db94fb0f8f6bd226b94a2f863afb9c61",
                docStatus: 43,
                directShareholding: 1794473942,
                consolidatedShareholding: 1821074459,
                consolidateNoted: "e602e4c939034c3fa36b8077c739a1cf3b05730bba8f44398c025afaa7ff0d3322207ed0c1fd4e3693cd656",
                votingRightDirect: 1285880085,
                votingRightTotal: 2055073432,
                image: "b06c3eddd8ca4003b4f3b2430a0e97ec05efce0d02c64b88963937137d888efbb336c20e",
                isActive: true,
                bravoCode: "cb998",
                legacyCode: "866ba5ad9bd44529"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}