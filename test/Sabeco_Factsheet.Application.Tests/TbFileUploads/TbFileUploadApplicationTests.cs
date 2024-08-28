using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbFileUploads
{
    public abstract class TbFileUploadsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbFileUploadsAppService _tbFileUploadsAppService;
        private readonly IRepository<TbFileUpload, int> _tbFileUploadRepository;

        public TbFileUploadsAppServiceTests()
        {
            _tbFileUploadsAppService = GetRequiredService<ITbFileUploadsAppService>();
            _tbFileUploadRepository = GetRequiredService<IRepository<TbFileUpload, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbFileUploadsAppService.GetListAsync(new GetTbFileUploadsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == 1).ShouldBe(true);
            result.Items.Any(x => x.Id == 2).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tbFileUploadsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbFileUploadCreateDto
            {
                companyId = 1429412401,
                personId = 1644983232,
                fileName = "3525f204c",
                fullFileName = "0703db5c51964f079decc5da3646d5fcd007d4c2e2e541b8ad5f8306c",
                fileLink = "5b7c214c842e",
                uploadDate = new DateTime(2018, 8, 14),
                UserUpload = 295506077,
                note = "a01e30c3c2a34d5e9437d74766be9aedde1f9",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbFileUploadsAppService.CreateAsync(input);

            // Assert
            var result = await _tbFileUploadRepository.FindAsync(c => c.companyId == serviceResult.companyId);

            result.ShouldNotBe(null);
            result.companyId.ShouldBe(1429412401);
            result.personId.ShouldBe(1644983232);
            result.fileName.ShouldBe("3525f204c");
            result.fullFileName.ShouldBe("0703db5c51964f079decc5da3646d5fcd007d4c2e2e541b8ad5f8306c");
            result.fileLink.ShouldBe("5b7c214c842e");
            result.uploadDate.ShouldBe(new DateTime(2018, 8, 14));
            result.UserUpload.ShouldBe(295506077);
            result.note.ShouldBe("a01e30c3c2a34d5e9437d74766be9aedde1f9");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbFileUploadUpdateDto()
            {
                companyId = 551775519,
                personId = 868837299,
                fileName = "63e5a2373cc747cbae57c0741b5e953449eaed1b35954c66a85b1eaf8eb2b44769d908dbb7",
                fullFileName = "ef9c4f3a1d19",
                fileLink = "0a743d4ce94c4c1bafb965ffe324380aa12",
                uploadDate = new DateTime(2010, 2, 16),
                UserUpload = 954103882,
                note = "f92f64284ee546728924a5e594496d2242f082f22ee24c42bb8",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbFileUploadsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbFileUploadRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.companyId.ShouldBe(551775519);
            result.personId.ShouldBe(868837299);
            result.fileName.ShouldBe("63e5a2373cc747cbae57c0741b5e953449eaed1b35954c66a85b1eaf8eb2b44769d908dbb7");
            result.fullFileName.ShouldBe("ef9c4f3a1d19");
            result.fileLink.ShouldBe("0a743d4ce94c4c1bafb965ffe324380aa12");
            result.uploadDate.ShouldBe(new DateTime(2010, 2, 16));
            result.UserUpload.ShouldBe(954103882);
            result.note.ShouldBe("f92f64284ee546728924a5e594496d2242f082f22ee24c42bb8");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbFileUploadsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbFileUploadRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}