using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbCompanyInvests;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbCompanyInvests
{
    public class TbCompanyInvestRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbCompanyInvestRepository _tbCompanyInvestRepository;

        public TbCompanyInvestRepositoryTests()
        {
            _tbCompanyInvestRepository = GetRequiredService<ITbCompanyInvestRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbCompanyInvestRepository.GetListAsync(
                    companyName: "77f9153b2d714373873d0545fce35c75afd2cd78db3a455cb8b19d70fc442bc",
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
                var result = await _tbCompanyInvestRepository.GetCountAsync(
                    companyName: "2c3473a944e54802aabf7e953af7a99d484d7fa9bfb541e5aafab",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}