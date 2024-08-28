using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbBreweryImages;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbBreweryImages
{
    public class TbBreweryImageRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbBreweryImageRepository _tbBreweryImageRepository;

        public TbBreweryImageRepositoryTests()
        {
            _tbBreweryImageRepository = GetRequiredService<ITbBreweryImageRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbBreweryImageRepository.GetListAsync(
                    breweryImage: "c7a44a1a8fe740a895751385acd2f7a3026d2ea3e9de4fe4ac3731bea65cd38b94aca9ab03a14e",
                    imageLink: "4d681a2a23714ac39f9aa2081f8ae6230a",
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
                var result = await _tbBreweryImageRepository.GetCountAsync(
                    breweryImage: "77893ec4df",
                    imageLink: "3da593c68cd04e8b9169b6489e",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}