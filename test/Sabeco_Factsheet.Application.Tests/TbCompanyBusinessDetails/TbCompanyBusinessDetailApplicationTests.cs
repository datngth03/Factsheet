using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{
    public abstract class TbCompanyBusinessDetailsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyBusinessDetailsAppService _tbCompanyBusinessDetailsAppService;
        private readonly IRepository<TbCompanyBusinessDetail, int> _tbCompanyBusinessDetailRepository;

        public TbCompanyBusinessDetailsAppServiceTests()
        {
            _tbCompanyBusinessDetailsAppService = GetRequiredService<ITbCompanyBusinessDetailsAppService>();
            _tbCompanyBusinessDetailRepository = GetRequiredService<IRepository<TbCompanyBusinessDetail, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyBusinessDetailsAppService.GetListAsync(new GetTbCompanyBusinessDetailsInput());

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
            var result = await _tbCompanyBusinessDetailsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyBusinessDetailCreateDto
            {
                ParentId = 352894023,
                RegistrationCode = "c98861af21",
                RegistrationName = "38d47e87dc2141eeab3154d2958ff437e692f2f2bed7409698870cc1b7529017a5001f2c29a948a0a8f71be094f6a893b3fcc5dc75414452bb7f47727ee6792e960b254220a64ff2bedba89a923fc71b47ee2d77426b479f9e3c04b4d7cf9af93b204257c2114aad8711dad85b705f0d6f7b652a1b834da3a56a9aae9d",
                RegistrationName_EN = "0d25f4cda99345569686e424586a4bcb97b01b639cef4a949968a134bd1ff7c66c34b7d8559e4cd886607dfb68d4db7aec10997a60214ee09790865b550d862415ee37ea8b03466dba2ae82093fa4add7bf65ec9d80e459c84e16f4cf2a235c24596408ac02e4132b0aaedd64b25c2016a4cd7a1495d4b44adb04ed805",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbCompanyBusinessDetailsAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyBusinessDetailRepository.FindAsync(c => c.ParentId == serviceResult.ParentId);

            result.ShouldNotBe(null);
            result.ParentId.ShouldBe(352894023);
            result.RegistrationCode.ShouldBe("c98861af21");
            result.RegistrationName.ShouldBe("38d47e87dc2141eeab3154d2958ff437e692f2f2bed7409698870cc1b7529017a5001f2c29a948a0a8f71be094f6a893b3fcc5dc75414452bb7f47727ee6792e960b254220a64ff2bedba89a923fc71b47ee2d77426b479f9e3c04b4d7cf9af93b204257c2114aad8711dad85b705f0d6f7b652a1b834da3a56a9aae9d");
            result.RegistrationName_EN.ShouldBe("0d25f4cda99345569686e424586a4bcb97b01b639cef4a949968a134bd1ff7c66c34b7d8559e4cd886607dfb68d4db7aec10997a60214ee09790865b550d862415ee37ea8b03466dba2ae82093fa4add7bf65ec9d80e459c84e16f4cf2a235c24596408ac02e4132b0aaedd64b25c2016a4cd7a1495d4b44adb04ed805");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyBusinessDetailUpdateDto()
            {
                ParentId = 1991401562,
                RegistrationCode = "8e4380a7f7",
                RegistrationName = "e57a1bd5ffcb4cf7a56d41599f86e5041eaf2f2b55d04b608cc1c7bf00b57e554951be613e3e45f0bfc96b152928601e96721a9708294076ad903996122f92cbb7844c2186574614939dccf62d82484cccbc776842f44b91861f9bc8e6f64d77303c657b6a7f4c97b5cb0c2563a54a4a061931b73e9e43d3a3aa31358e",
                RegistrationName_EN = "608b38642e554ffebc42988e96dc4b04b207008c453e4f93924c7e0b5f628b7e623862ff579946a0807e44beeb0c8220abff5c4a61644a7a948c992a2c736caaf3cbd9a278224c6889f1151e2e9faf77ff4c78c7dab148bf87d45a4cb190fb3c846c3cb4d4eb4d52867c2bd2e2b21b8be3dd38df8c4b42a3ad7a15c3c4",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbCompanyBusinessDetailsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyBusinessDetailRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ParentId.ShouldBe(1991401562);
            result.RegistrationCode.ShouldBe("8e4380a7f7");
            result.RegistrationName.ShouldBe("e57a1bd5ffcb4cf7a56d41599f86e5041eaf2f2b55d04b608cc1c7bf00b57e554951be613e3e45f0bfc96b152928601e96721a9708294076ad903996122f92cbb7844c2186574614939dccf62d82484cccbc776842f44b91861f9bc8e6f64d77303c657b6a7f4c97b5cb0c2563a54a4a061931b73e9e43d3a3aa31358e");
            result.RegistrationName_EN.ShouldBe("608b38642e554ffebc42988e96dc4b04b207008c453e4f93924c7e0b5f628b7e623862ff579946a0807e44beeb0c8220abff5c4a61644a7a948c992a2c736caaf3cbd9a278224c6889f1151e2e9faf77ff4c78c7dab148bf87d45a4cb190fb3c846c3cb4d4eb4d52867c2bd2e2b21b8be3dd38df8c4b42a3ad7a15c3c4");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyBusinessDetailsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyBusinessDetailRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}