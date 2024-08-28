using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbLandInfos;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbLandInfos
{
    public class TbLandInfoRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbLandInfoRepository _tbLandInfoRepository;

        public TbLandInfoRepositoryTests()
        {
            _tbLandInfoRepository = GetRequiredService<ITbLandInfoRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbLandInfoRepository.GetListAsync(
                    description: "58bc7277b09d4504bbd90cc37b531",
                    address: "b6b92bfb88954643a68",
                    typeOfLand: "567b0268cb9d4712b60827faf320f9",
                    supportingDocument: "7a92138637d34bf0bdf83089eb9dfc66499123c973334b45a57131fee9b6def24f810d1ff25743a0b54e14",
                    payment: "a5d147ed6cc944899b6a16b0499dc1a838d03e9dca774da99ad810c1fe7682319ed0df6b93d94",
                    remark: "cd2347b7ee81415ca03dbc8a441a28",
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
                var result = await _tbLandInfoRepository.GetCountAsync(
                    description: "f05196ef55704f6f84348d435df9515a6c78a382f703406782628228bb1",
                    address: "a67ec151c1d943fe9738063d838e7b2b55dad887360c455ea76bbb4b2",
                    typeOfLand: "1627b0550011453984347",
                    supportingDocument: "3c5a06d1a3b64305bb3e3bd519ac8833ae0a0302f35a4369b6ec941170818e62463a0c4681",
                    payment: "a5fd7712753c4ac985a8ed6e39288dfc2636d00739014c0c9b6",
                    remark: "f653651ef5994023a5985ee1d588574c",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}