using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbPersons;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbPersons
{
    public class TbPersonRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbPersonRepository _tbPersonRepository;

        public TbPersonRepositoryTests()
        {
            _tbPersonRepository = GetRequiredService<ITbPersonRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbPersonRepository.GetListAsync(
                    code: "090b963dc3d34f5ca50b",
                    fullName: "70bf6f69c09b48c3a83dfa7f34ee72fbb470f7326a1444f88996b6380e29c897373faf8a7ed94025aa0324d68a37a0a1660c2d832d124acead4ab5d59ec68857997434ae743d4c768099d9",
                    birthPlace: "c89718aeac7d40b9913504c375c89b494cd0ac6ff017487492f0a667cdc3230cd34dde57d552403ba00d062ff0d9961f346a75dd7a714522a07fbfc548429f700f8066cbb7e44fa6912e25",
                    address: "01a0605a3d4d486890c9e5f011efabf79e8221eb1b5b4152bd12aaad5fb5aa681059857d13a0424483c2a9892290625f099d9b9a6d284129a921d5fef89c20dbbbfb294b32a0497eb1325f",
                    iDCardNo: "67064404f1ea40b2b9a5",
                    idCardIssuePlace: "c76f41e09ed248f0a45004d34cdaa5bb7c902e42cdc64d56978161f25b8916d60ff4233d04b2445f957409723c0e17f7cbfb142a1baf4a50afe50c45cdf724640257680491b04a9facb546",
                    ethnicity: "c0290fc9837a44658004d16ca433929196a5c7e588d540079dba0d788cdcbf3976a8d400ebde447daf37af0b0fd09c16fc561ef3bd96485ba073a65adb493a5bc4371081fe7041b9b61580",
                    religion: "4745a807e44d4d5f87d3b1df91ce4db91617f92b73cd454db0df29f832ef7fb2fd60e5c0bb26465e97ad73a076627ee46e2e0ed069704d8fa008793d6dda1564437c8da4333d42e5a65a0b",
                    nationalityCode: "f96",
                    gender: "bda",
                    phone: "f1dbbe8fde0d41b6bb4917b2dbb91392640b63ce0db147f28f",
                    email: "d25825e15aed43ffafeec61cd77ae3252df9a6abe3ae4d668e0d4defc331f04c09b1112fc9e944e8b54c32202276419b1f44e66bcbb94b5282dea76b77ddddfd9dafd594c1f24749a17c2b",
                    note: "0e968e94937943ce8c18752f15a9fb4ff386a79d063d443c9089af81f9cd8de1487de3091be7421e984fc4277f0e26072250c50528f34585a27ccc098f988603a47feb72f2f14f22bd708eaf34b90c561b85e7bb808a4a48bfb449b7ac8adcb57b294f0dcafb4b898d4a42640552830ae543f4deb3da417e95ce3f9592",
                    image: "48d89f67d6ed4615902b50be59777e4d932218fb6fb546d694361c2f97725ad6158bb000",
                    isActive: true,
                    isCheckRetirement: true,
                    isCheckTermEnd: true,
                    oldCode: "8780772294ad4f5ba713"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(1);
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbPersonRepository.GetCountAsync(
                    code: "3dd1befda97b4d43aee1",
                    fullName: "289fe75e117844a091921a79e99ee206f17523f9fa8d4c9689e5675809658e3bb89b31fca186460389a0d23bd8a979a83fb171a16dd345578295c102695e146a10c8ac93c3d546918c8c7e",
                    birthPlace: "a8cdd01610dc49d6ac3c96c3c8ffe98de44523d36b75435785feb6a4f13feac89480aac73e89472da3554ca3aecb1f40a78595c2813d491797433a2ab6f83954c91265d448004ba5949534",
                    address: "592cb79c6a3a4c8a93643aa075a4104e9eb51fa4472a474f9c220d14c11d8655bb17b05e3ec0458287667068c8b165867426c92abdfb47e8b7ea92f9349d7f511b405423688547c08cc41b",
                    iDCardNo: "05f87971c0e7468b8dd1",
                    idCardIssuePlace: "e78cb2af1a8d49f6a76833ee31ae0b22a9c962f6ce17430db221b399d02eeb942a2685b58eff486985883d3eccb862eb3282f4fc6c3e4b8b8607148f2e3681757a360dbfde6544b7a6ee06",
                    ethnicity: "6bbfc621c91a472a9d72f12816813431f767926e243649eeae912a56486aa8c55eadd3518bd94ef885ed1727658c999819c140fe94f64dc9a58ab10ea856c002edba57b7248e4aaf92578a",
                    religion: "2418d448d8eb4dda845fb8148acb8b00d63c15ee80a040e09e6b8ace8ca4472e3ca86dc0f22b4aaab6699aa07c68698b0a5813c4cf50435b990c32eba5284938b515499c31864cb4b2a9c1",
                    nationalityCode: "641",
                    gender: "244",
                    phone: "bba4b9dc932b41889290698484837218b74419f4fe454627b3",
                    email: "d27174ee91e244769b40a76ddd530d3c75dfc7fbea5b497a9a238adc6e67c8dc2e04b43729da454d8667072116783434b88e809a1198425a9da60c89eee81a2b622a3ad028a643d5b56b8a",
                    note: "07bd68d3042849e784d09742b69f5519316d5dfd85484bda99124a110a742d8abb0149b634084a1286fe917536fad3760c83f2168faf49329f6b6932d2a3f3e9efa5fd585cd84356b4d8cb21978dcd64d9d8059796f1494690ec5b7d08242e25607dd002764041c4b13b09356783e070c17c0c90ec2241a2af0e676f1d",
                    image: "2b03fd8dd79d4c5e9eb3062122bfbab90a6d0dc76f9447f58f2a046a2e7651ee16160349e12640e68a98650ab9da2432",
                    isActive: true,
                    isCheckRetirement: true,
                    isCheckTermEnd: true,
                    oldCode: "10da99964d924feb98ea"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}