using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbCompanyPersons;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbCompanyPersons
{
    public class TbCompanyPersonRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbCompanyPersonRepository _tbCompanyPersonRepository;

        public TbCompanyPersonRepositoryTests()
        {
            _tbCompanyPersonRepository = GetRequiredService<ITbCompanyPersonRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbCompanyPersonRepository.GetListAsync(
                    branchCode: "46a1bcc60a",
                    positionCode: "a9ce3ac63be343d58444",
                    note: "fb4d60376b9444e7bcb5c5f996c81d8d087827a1b557432d8e4976282478ebc197623463b7544837b626b34403a0097b65f2f647d1554aceadacbdfd2a9d4bd427806a8fc8544c03b5ef26419fe30c32b25c8db26571415289776a270695859855f9acc79463402498975f1b2f4fdbaa650315653c51493b80548ae2d6",
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
                var result = await _tbCompanyPersonRepository.GetCountAsync(
                    branchCode: "de3964bc1b",
                    positionCode: "031601faeb574fd383c6",
                    note: "28acc915bcef4854aa93f08281c045778bba5d387f9346e58fe9be02f7ff6eed61e7f589be2b4b24aac76fe9289002a5d7d16b37de064666b633410c653cc4281f22e48f2be9498f95bb1f6edc2bbe03f352ef7a6091454eabdb8862cbf77fe2da625115b6ac49d59977487d08f29e436dfb02fe4b4142a29506db7ec7",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}