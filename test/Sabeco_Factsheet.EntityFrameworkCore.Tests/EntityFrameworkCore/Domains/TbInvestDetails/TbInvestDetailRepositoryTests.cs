using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbInvestDetails;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbInvestDetails
{
    public class TbInvestDetailRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbInvestDetailRepository _tbInvestDetailRepository;

        public TbInvestDetailRepositoryTests()
        {
            _tbInvestDetailRepository = GetRequiredService<ITbInvestDetailRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbInvestDetailRepository.GetListAsync(
                    docNo: "b7a6ff7fe4f04c6c952be9b8c6381b158534c2ae57d24ccc90",
                    note: "f2d2e60447134ad4991a037c4c7a76ee97f7f0e62c0043daa8394985523efcccb62461474bfb461fa2d5731b77c178dfabbe1a3f38e84b4594058fe10d8ac9a2ad22fc87ca804516af7ae698e63c0949c2cd670a6a854b31a058fca837d78af8ac350c3702de4c1594c6efc45f54b432db8161d970824e268314f453d3",
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
                var result = await _tbInvestDetailRepository.GetCountAsync(
                    docNo: "edf2d1bd27ce4cecb1d61b2af2fc3d0640b436462e6d4f9cb5",
                    note: "f957525a700f4f1ca63d98f4813a070683d2a34e7f3e4a9b94267ad10131bc3abf615a1b93b746cfa31c3664a377b7dfedc0a0d9c8d544149e714c75523e40305eae1bafea944e5ebf702b605d1311576b33ffcfad04468393fe783837d496e0cbb89fdf186147869cc64e6c49c8998534d7d79eca764a4a931b60a400",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}