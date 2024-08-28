using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbFileUploads;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbFileUploads
{
    public class TbFileUploadRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbFileUploadRepository _tbFileUploadRepository;

        public TbFileUploadRepositoryTests()
        {
            _tbFileUploadRepository = GetRequiredService<ITbFileUploadRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbFileUploadRepository.GetListAsync(
                    fileName: "9b9e93cf0f6c4f218af6c513459d4d2c638a233a03c14a",
                    fullFileName: "b21582d26b82",
                    fileLink: "0a5c15af9f874293a4658e8b22cd6a86ebf55495fa72449e8a31fcf68789f941a28",
                    note: "4d73a4c9b1a04e06b8f74e84f86f1bc63e813f158c4b49e980d2a47cb4f2e6c5dde",
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
                var result = await _tbFileUploadRepository.GetCountAsync(
                    fileName: "83d98b2c11aa4436ad2b458626fcd775ded70392be28466097bf6af7",
                    fullFileName: "cb22bcdd18ef40e58e",
                    fileLink: "5dc82899dcf94fc4902e2a67",
                    note: "b8b460bc",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}