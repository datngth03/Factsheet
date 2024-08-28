using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbCompanyMappings;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbCompanyMappings
{
    public class TbCompanyMappingRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbCompanyMappingRepository _tbCompanyMappingRepository;

        public TbCompanyMappingRepositoryTests()
        {
            _tbCompanyMappingRepository = GetRequiredService<ITbCompanyMappingRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbCompanyMappingRepository.GetListAsync(
                    companyTypeShareholdingCode: "8398cc18f29a4e7ebfcb83929b3eef7dc03fff3082a1491",
                    companyTypesCode: "2906405d9ddb44d3a26b4f675346349f83b8dedb644b4b6881b356c8e599617165d77c7bb7df425593063ce385dfeff",
                    note: "35622fe207e74951bcf188451cb2bbff2a4c495fede1415ab9761f71b42e8e381a0"
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
                var result = await _tbCompanyMappingRepository.GetCountAsync(
                    companyTypeShareholdingCode: "372b2c8b56224494a341875dfa122274888c9222f",
                    companyTypesCode: "93a5e4a6991d488787ca665e96c5c7c9c",
                    note: "6fec5efad8e646a5bd6c4ab62aada718c7229cbe1c394ef4806a892eb44e7d123bd283936"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}