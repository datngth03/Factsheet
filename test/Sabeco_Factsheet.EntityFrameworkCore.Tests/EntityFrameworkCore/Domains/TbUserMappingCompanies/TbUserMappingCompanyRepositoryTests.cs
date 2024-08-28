using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbUserMappingCompanies;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbUserMappingCompanies
{
    public class TbUserMappingCompanyRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbUserMappingCompanyRepository _tbUserMappingCompanyRepository;

        public TbUserMappingCompanyRepositoryTests()
        {
            _tbUserMappingCompanyRepository = GetRequiredService<ITbUserMappingCompanyRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbUserMappingCompanyRepository.GetListAsync(
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
                var result = await _tbUserMappingCompanyRepository.GetCountAsync(
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}