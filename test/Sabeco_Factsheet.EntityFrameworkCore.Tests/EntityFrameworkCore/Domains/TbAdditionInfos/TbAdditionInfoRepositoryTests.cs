using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbAdditionInfos;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbAdditionInfos
{
    public class TbAdditionInfoRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbAdditionInfoRepository _tbAdditionInfoRepository;

        public TbAdditionInfoRepositoryTests()
        {
            _tbAdditionInfoRepository = GetRequiredService<ITbAdditionInfoRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbAdditionInfoRepository.GetListAsync(
                    typeOfGroup: "89fc27c731924ba186d93c69c84537b65c72f830a4ca465aab",
                    typeOfEvent: "3a02d9",
                    description: "c45ae0b3e92d4fa0b14bdbdf51e5a832442d62d623f043e5a7cecd44bc6dfcb4eefcba5f95ee416cac4e64",
                    noOfDocument: "bfbcbb766d114b94ad7466c36ddc8c29effeafb242f04448a195956f61cd6de3644dc0a",
                    remark: "69b73435443f49e7b1630622f05f434d8ada",
                    isActive: true
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
                var result = await _tbAdditionInfoRepository.GetCountAsync(
                    typeOfGroup: "c35def450dda453497414fe3344aea450f14462b330d4946bd",
                    typeOfEvent: "5fe496e7e98b45c3910e83fdf0ba5d8502e5341c9f684e01",
                    description: "5a9f093a51fe46f18b27d9556ae44bca526c1b7caf134cab9be8d0493938",
                    noOfDocument: "579a8303d87b412497e1da9619bc7789173eed10da0c49ccad4a1efdc6f4c62d9",
                    remark: "3cab9ef8566940059bfc",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}