using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbCompanyBranchImages;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbCompanyBranchImages
{
    public class TbCompanyBranchImageRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbCompanyBranchImageRepository _tbCompanyBranchImageRepository;

        public TbCompanyBranchImageRepositoryTests()
        {
            _tbCompanyBranchImageRepository = GetRequiredService<ITbCompanyBranchImageRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbCompanyBranchImageRepository.GetListAsync(
                    branchImage: "8dfba3c8e177462eaef8468625fbf4c5b2087ce472f5472189ac3755a01a7cccccff4b6ca0404b8abaf368437bb2145b72",
                    imageLink: "c01ba7bb14fd496d99f6d2a28ae94f53051d99b4d2d44487a18c93fc6a59b628ea684c921f6a4c338269628",
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
                var result = await _tbCompanyBranchImageRepository.GetCountAsync(
                    branchImage: "67f7d085a71a4a7682061ecf2b95206bc0761e2e2b274fe895652aebbd1d041fbc",
                    imageLink: "b3fd94744abf4ade997d0332cd75bbd05155a83e9b5d40518eefc9a3c7a96fb072e9b5916b7041148b4a2b556cde",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}