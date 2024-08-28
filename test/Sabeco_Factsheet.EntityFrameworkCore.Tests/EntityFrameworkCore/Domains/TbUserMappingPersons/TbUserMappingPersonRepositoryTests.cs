using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbUserMappingPersons;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbUserMappingPersons
{
    public class TbUserMappingPersonRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbUserMappingPersonRepository _tbUserMappingPersonRepository;

        public TbUserMappingPersonRepositoryTests()
        {
            _tbUserMappingPersonRepository = GetRequiredService<ITbUserMappingPersonRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbUserMappingPersonRepository.GetListAsync(
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
                var result = await _tbUserMappingPersonRepository.GetCountAsync(
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}