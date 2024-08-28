using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbInvests;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbInvests
{
    public class TbInvestRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbInvestRepository _tbInvestRepository;

        public TbInvestRepositoryTests()
        {
            _tbInvestRepository = GetRequiredService<ITbInvestRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbInvestRepository.GetListAsync(
                    branchCode: "4db87ca24add4059875b",
                    companyCode: "56e1eaea76174665a268",
                    note: "7945f798c48d4390a60e2669169a9fc9464d451117c649fbbce7f477d057c817110eebe7ac2f445db3a58027f8915cdeb34d82d49708427d95192f6852fcabe0b7e9ed8fc5ee4b9290fcab2a014c98057883a86a92b6485c882dad30797d781c74dddd9f20204ae4bb127a2ccf8c820730438ae1c9484a4382af48f332",
                    investGroup: true,
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
                var result = await _tbInvestRepository.GetCountAsync(
                    branchCode: "138cc923a7d144948b53",
                    companyCode: "a799ee686c6d46a0a046",
                    note: "8bc69668c1bc4fc9b98deca646b6df59a4a81395615f47ce8a2d2e2a712b36b4657b8c55c4624bb980824e32a12d9eaa6ce913a4162448dfb9fded3576036b4d651cdd9b558c457cb8964aa5570b89289ef08a7428fa4c0c996a0b81809bbbbbd742200736464ed2b7bdf4f5f71eaa33248d234e09d848e481ead7d16f",
                    investGroup: true,
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}