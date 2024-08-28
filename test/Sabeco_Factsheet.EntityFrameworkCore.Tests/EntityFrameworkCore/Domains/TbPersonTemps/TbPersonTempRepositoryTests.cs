using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbPersonTemps;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbPersonTemps
{
    public class TbPersonTempRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbPersonTempRepository _tbPersonTempRepository;

        public TbPersonTempRepositoryTests()
        {
            _tbPersonTempRepository = GetRequiredService<ITbPersonTempRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbPersonTempRepository.GetListAsync(
                    code: "b8b82e090e4749c787e6",
                    fullName: "3fcc3f16d4dc45c9963b90d6c4616b324b40772ff6d646bd95e6eb14977869bf0933533a81f34acaa8c828917e9f80d9d8086eeaad2e4cbf8ee589aee5edc115c81eadb3c88243e6a3e550",
                    birthPlace: "29792c48ef4c42bdab1c55f4df8bfcc05c9053cbc5f24a5e83f8bd248a480b90916edff3d6574a39bacb3acabb12bfce255bce71976f440caab0a10901e9f62a7f81e9ea7359405e8c5004",
                    address: "0ed7e88baa1747959990e1cbb09e66ea7c8282fc0cbd4dca935fa9ccae7b7753415dcb6fef9d4fb0a7609fd42c5871d74cf262b214954a1780babebfb897177c0f366188ba9b4db8877a51",
                    iDCardNo: "919b4bf7b8324c13afe7",
                    idCardIssuePlace: "f9ac2181debb40afb2e1171593903238c5bc2d7b93dd492097693ada2dcf9f8e757c218cfcc349d9ae6dee5ff41f7e655893cb0f7fc04feeaa6dcb30b11e0f026c51f3722fec4866958b6e",
                    ethnicity: "b42fef18491e49a3aa50aee423bc6525cec5d4a6483d458599ea934a580d0aaff73e8dd3a16b49709a74546eb5e743d0444ab7aaa7f44f09a0478584b302e88f124107cfdcb44d2cac3ccf",
                    religion: "8f61a6c98e834a7c816e6046b6f68dcde36028e674bd4d1c897542ee5d08ff7455b0e33a446147e0b9679f88672f7709b76bc8cd36fe4e4588e6e4f6ad061dd5a6e6cff56d6f44e7a98746",
                    nationalityCode: "6a1",
                    gender: "9e4",
                    phone: "d1a17c8f4137400982c042be932b7e11f1b62cdfa7fa4c4795",
                    email: "86e83159bf8d45a5ba0b6f831fcda4ed786e158c3d75432ab8ae1b63e93601ab01d71f52e1fa4523b6ba620b0448caad55b9b045756842aea5c387a364b6408be7255c01cc83433294e5a7",
                    note: "2a3b0c98ea8f46028981eb63008163b28989ae4fa7c94aa3a129dd9e4cb290c8c2b30979ee1047238cdb345dad64a15abf058e1a6c734ec99b54ffc86c9489e9fd74c00772114d1080467429ab8d7f02228400f88b6a4098817769296f015923d0c0fb4c109c4291a8641e635eded00bcb1ac5f9eae9408ab4164f1413",
                    image: "e317436f77b643ca9909026106d3888345057b7ecdd145efbd1a5b4671bd7d35fec7931e1",
                    isActive: true,
                    isCheckRetirement: true,
                    isCheckTermEnd: true,
                    oldCode: "8113e98028cc4ee2965c"
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
                var result = await _tbPersonTempRepository.GetCountAsync(
                    code: "ce7e667447ad4fada34e",
                    fullName: "cdb8c3d2867e49edb2a277b99f4308883338447abf574d9eb9fd3fed329e1d7c6402c53255c14d8d9eb9ac26133147e74e505702965e489188d5b2205a3daa5f311e624802864e26a525e0",
                    birthPlace: "f3dedabd2b534ef499fc674243225029a299dd6c3e574620ab699987c8cc7b4bfa1d836daf5e4a87a29871095fa163f2f72afb0568974faba467bbebe3cbb9e6179bf3031d4d4a9fac87ec",
                    address: "f49819ce5c414d0d97887eb85aca5c63dbd88014ed3641258d6142ff50c8f2ac5e0f2a4f6f17447587aac755bf362de1ccd1d99e24414e4eb2c06a8d9cbbbe47902f755f930a4b28915552",
                    iDCardNo: "0e5096ca10204984bbf1",
                    idCardIssuePlace: "287227aa776f4bf69677f892fcaa5c8692a1412006814c4f9f103b671beac0ff6cb1d42b50ca4895bfaf0fda9b9d8a47abd7e867a12443ec830281077082ff1b27603c902fe942c5999366",
                    ethnicity: "871c60c3e48e4896a5d09f0ecd49ba14747bf05849114d1d9fe3469546c2d2041e5b3f480c314557b21a30c67ae8bf8a3372f67ec3ce441b97dbd010fd2a2da29f55c943c696408d934b92",
                    religion: "48d9cd5f5c784885a86e6389b0da1c997f3f793cb0124b9291d64fe13542c48d15db8fa106a042f8a3a144ac94970b4ee3a5505c804747ba9f59b33bd3cc01a03b83bfe1956444e1aed759",
                    nationalityCode: "75c",
                    gender: "732",
                    phone: "1a322a9e0c1049d3af06e1db48b25f5da050a37f82db48369b",
                    email: "df4c08fa05ef46e7ae0cb6721d0dae327f6ea77898cc4d099c8da700ac95aa813d249464af3246c59f18692b27ea85004c9c7155bf4e4f2fa451a68f1b511d471ebb9d6005a54d4f949ba9",
                    note: "8554696a61cb4faa8746bee2947e26fc17040275554d49089244393e590001a51ce742614b0f447d9c8757d2173b71af677d5a2a46c84658ad72199d90614060f482365e5a0e4a3584fd7433dab032ab55ae054db6d8401db2459f0ae1856d97cb875f967af9448aadadf82c5a5fc83e017b92cd71b44e49af177d81fc",
                    image: "58c6533d047741d0a0348006d327b7f576b2f647a8fa4a52bd7df755caefd3712b616",
                    isActive: true,
                    isCheckRetirement: true,
                    isCheckTermEnd: true,
                    oldCode: "4b8920efc38a4b35b2c9"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}