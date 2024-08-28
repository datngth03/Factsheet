using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbLandInfos
{
    public abstract class TbLandInfosAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbLandInfosAppService _tbLandInfosAppService;
        private readonly IRepository<TbLandInfo, int> _tbLandInfoRepository;

        public TbLandInfosAppServiceTests()
        {
            _tbLandInfosAppService = GetRequiredService<ITbLandInfosAppService>();
            _tbLandInfoRepository = GetRequiredService<IRepository<TbLandInfo, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbLandInfosAppService.GetListAsync(new GetTbLandInfosInput());

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
            var result = await _tbLandInfosAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbLandInfoCreateDto
            {
                CompanyId = 753792719,
                Description = "d4264dbdeb544ce6bb7740ad07b733118d0dc77d64204a868900423b8c9a04",
                Address = "675b7442f7e04a6fa798434aed53eb5c3389b6d1322d4234be45195f2c794618a9ef4f940c4a43e2876b193abff7297ad",
                TypeOfLand = "f0e908ed",
                Area = 1169993171,
                SupportingDocument = "2f684b5",
                IssueDate = new DateTime(2010, 6, 9),
                ExpiryDate = new DateTime(2021, 8, 17),
                Payment = "5ec70229d1c742a2ac4f",
                Remark = "6ce94f9e277e416bb148b02e0d733daada82db58fdbe405da0aa1c2c31f2a745eb4044fff9264aca9bc23b25a4f9b",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbLandInfosAppService.CreateAsync(input);

            // Assert
            var result = await _tbLandInfoRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(753792719);
            result.Description.ShouldBe("d4264dbdeb544ce6bb7740ad07b733118d0dc77d64204a868900423b8c9a04");
            result.Address.ShouldBe("675b7442f7e04a6fa798434aed53eb5c3389b6d1322d4234be45195f2c794618a9ef4f940c4a43e2876b193abff7297ad");
            result.TypeOfLand.ShouldBe("f0e908ed");
            result.Area.ShouldBe(1169993171);
            result.SupportingDocument.ShouldBe("2f684b5");
            result.IssueDate.ShouldBe(new DateTime(2010, 6, 9));
            result.ExpiryDate.ShouldBe(new DateTime(2021, 8, 17));
            result.Payment.ShouldBe("5ec70229d1c742a2ac4f");
            result.Remark.ShouldBe("6ce94f9e277e416bb148b02e0d733daada82db58fdbe405da0aa1c2c31f2a745eb4044fff9264aca9bc23b25a4f9b");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbLandInfoUpdateDto()
            {
                CompanyId = 1766109984,
                Description = "89ab600527484f0f8f28111b354944bcb3e7d3cbcb23403ab27282356e97653ffe6",
                Address = "f6aafc1854484a01be0333212b787fd0421751b22dac4b7397a20",
                TypeOfLand = "d26a83dadf2f4bd08f091c4ab951cd0aacc26fbcef124222a819648fca1cca7ff2e89871",
                Area = 1711262181,
                SupportingDocument = "e3092569878344ca9655d832316581f936510",
                IssueDate = new DateTime(2008, 9, 3),
                ExpiryDate = new DateTime(2010, 9, 17),
                Payment = "ca866e2152ab4317b696659e93259c9aada",
                Remark = "e26db1dff49e40f68b25da407f91a071af85a82a213a4cc39c8eb724e087fdb59579ccb52ca440369c5e25b74c3b983c9",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbLandInfosAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbLandInfoRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1766109984);
            result.Description.ShouldBe("89ab600527484f0f8f28111b354944bcb3e7d3cbcb23403ab27282356e97653ffe6");
            result.Address.ShouldBe("f6aafc1854484a01be0333212b787fd0421751b22dac4b7397a20");
            result.TypeOfLand.ShouldBe("d26a83dadf2f4bd08f091c4ab951cd0aacc26fbcef124222a819648fca1cca7ff2e89871");
            result.Area.ShouldBe(1711262181);
            result.SupportingDocument.ShouldBe("e3092569878344ca9655d832316581f936510");
            result.IssueDate.ShouldBe(new DateTime(2008, 9, 3));
            result.ExpiryDate.ShouldBe(new DateTime(2010, 9, 17));
            result.Payment.ShouldBe("ca866e2152ab4317b696659e93259c9aada");
            result.Remark.ShouldBe("e26db1dff49e40f68b25da407f91a071af85a82a213a4cc39c8eb724e087fdb59579ccb52ca440369c5e25b74c3b983c9");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbLandInfosAppService.DeleteAsync(1);

            // Assert
            var result = await _tbLandInfoRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}