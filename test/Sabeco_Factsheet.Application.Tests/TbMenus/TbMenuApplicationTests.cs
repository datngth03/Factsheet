using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbMenus
{
    public abstract class TbMenusAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbMenusAppService _tbMenusAppService;
        private readonly IRepository<TbMenu, int> _tbMenuRepository;

        public TbMenusAppServiceTests()
        {
            _tbMenusAppService = GetRequiredService<ITbMenusAppService>();
            _tbMenuRepository = GetRequiredService<IRepository<TbMenu, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbMenusAppService.GetListAsync(new GetTbMenusInput());

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
            var result = await _tbMenusAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbMenuCreateDto
            {
                ControlName = "ddb8062d75a8458a81ee505661cc04cb24fe0f0cbb2f451ab527d3310b23487a8d9f0cd4c7294f3badde8f12b10930bf98aa249c25884da68323280fde9eade7b52f45cf40254a47bde656719f9d985b94a634417f9141fbaa8bc1fabb4da980bd4cfd00052f4d8daee08d45e94d677e075cf2acce3b473ca20f79ab473405e6d110f16ead0247fcb3005e5efa8449e13706c684ab4b4cbc8c6521cac872b75778d81e5ab54141f19371b8425c969e3c4120f4c38ab14e4e9cdb7ffb11b799bf627e434f2cab444f84bb39ad43dbfe3370ce2149c0574b65b6eda72f6b15b12eee825dcdbe1841609b3daea4a83a06abef0abad117f641509f2c",
                Description = "de389a81623c43b4b0748d24fe5c187360e3e921b6604cdaad702c4af4e92691d0d73916dc9741258d86bf0a418b7471a90e4c3ab7ae47aeb429ccd663f179818848f4496db64dfdaa785c57f26a7850e09150bb5ec54aa4ad0d2ae75a0d70e4d2fe51bf98f34eb09d9cf50af61c8b1647dae6ea6683475fb0253c71311464a603d34e55c5f84d6e97bd47c8b9d3c10976a20d46097544e4977ffa17c9bd36abf05ac0ccd6a04f3eb4881cac11f21efc5a4b414af12b47e98a3479144dd53656a25309ccca3246f9911d289a2df03f9452568e9b7d934b75a4d5f0e0e4a1fc4ed0ec812cdfb64fa29f84e4aaf887a84a4251e7d4371542668061",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbMenusAppService.CreateAsync(input);

            // Assert
            var result = await _tbMenuRepository.FindAsync(c => c.ControlName == serviceResult.ControlName);

            result.ShouldNotBe(null);
            result.ControlName.ShouldBe("ddb8062d75a8458a81ee505661cc04cb24fe0f0cbb2f451ab527d3310b23487a8d9f0cd4c7294f3badde8f12b10930bf98aa249c25884da68323280fde9eade7b52f45cf40254a47bde656719f9d985b94a634417f9141fbaa8bc1fabb4da980bd4cfd00052f4d8daee08d45e94d677e075cf2acce3b473ca20f79ab473405e6d110f16ead0247fcb3005e5efa8449e13706c684ab4b4cbc8c6521cac872b75778d81e5ab54141f19371b8425c969e3c4120f4c38ab14e4e9cdb7ffb11b799bf627e434f2cab444f84bb39ad43dbfe3370ce2149c0574b65b6eda72f6b15b12eee825dcdbe1841609b3daea4a83a06abef0abad117f641509f2c");
            result.Description.ShouldBe("de389a81623c43b4b0748d24fe5c187360e3e921b6604cdaad702c4af4e92691d0d73916dc9741258d86bf0a418b7471a90e4c3ab7ae47aeb429ccd663f179818848f4496db64dfdaa785c57f26a7850e09150bb5ec54aa4ad0d2ae75a0d70e4d2fe51bf98f34eb09d9cf50af61c8b1647dae6ea6683475fb0253c71311464a603d34e55c5f84d6e97bd47c8b9d3c10976a20d46097544e4977ffa17c9bd36abf05ac0ccd6a04f3eb4881cac11f21efc5a4b414af12b47e98a3479144dd53656a25309ccca3246f9911d289a2df03f9452568e9b7d934b75a4d5f0e0e4a1fc4ed0ec812cdfb64fa29f84e4aaf887a84a4251e7d4371542668061");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbMenuUpdateDto()
            {
                ControlName = "3e96491d19094d88b6f435fe98ce7dc1e765cd85c95d4c4283a5dac08735c60baac55b6c703e446cab629ed306c40a56b7ed9c062f434784b8d30994ecec21b57045b5fbfa1248a98818410c57b469ccd2c53afccbd84c7f917af3d0b504499626af328a5cc74845b55dd8c2c7f40182314bd0a6c00f4d21af2890ceaed320e86e4fef0b51444a0981c214932c7e5265db12ac986fb745f7bb870e44503b31bc0532e57bd64943299a6887242185192a69d1e4babf30455bb28f74cf486b1293685c25e0436548d29399bdac5cc7b4c81d05c496d0114b0eaf083857fa72a4ff1e9dc9cc6b0346a5baca7be3e93ba097babaaacbb19c47e2a66c",
                Description = "1c40a606f74a4de597409cef75becdeae61813ee29754a0a9f76684a33a9945561790eb513f6430dad98de2c5a0d4117fa70ccc3120b49108e3bfe62b8781204f7a70de0ac5b4a8aa2dfc186b907ff6eed6e805fe8c8471f82cb7728c724ef7b54617bb4b10f49769c859c8ac63279bd821aeb4f23f24693936889d6eced4b9da81328e08c554b118ff7a96f1103f6a1c5e5a15facdd46cdb0661d60ecf5c3beb52248de6ffa47a4b97b624ade9eb862e970163dfd274096b1d72c8848c2e68716164ae1d1fc4dfab88c9dbf0c1a125f33b24008c6ca4f459ad33fa6e9c5e116052cfe1a9d1b4b4584734d5457f66621ba2f053cbf9047a78ad7",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbMenusAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbMenuRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ControlName.ShouldBe("3e96491d19094d88b6f435fe98ce7dc1e765cd85c95d4c4283a5dac08735c60baac55b6c703e446cab629ed306c40a56b7ed9c062f434784b8d30994ecec21b57045b5fbfa1248a98818410c57b469ccd2c53afccbd84c7f917af3d0b504499626af328a5cc74845b55dd8c2c7f40182314bd0a6c00f4d21af2890ceaed320e86e4fef0b51444a0981c214932c7e5265db12ac986fb745f7bb870e44503b31bc0532e57bd64943299a6887242185192a69d1e4babf30455bb28f74cf486b1293685c25e0436548d29399bdac5cc7b4c81d05c496d0114b0eaf083857fa72a4ff1e9dc9cc6b0346a5baca7be3e93ba097babaaacbb19c47e2a66c");
            result.Description.ShouldBe("1c40a606f74a4de597409cef75becdeae61813ee29754a0a9f76684a33a9945561790eb513f6430dad98de2c5a0d4117fa70ccc3120b49108e3bfe62b8781204f7a70de0ac5b4a8aa2dfc186b907ff6eed6e805fe8c8471f82cb7728c724ef7b54617bb4b10f49769c859c8ac63279bd821aeb4f23f24693936889d6eced4b9da81328e08c554b118ff7a96f1103f6a1c5e5a15facdd46cdb0661d60ecf5c3beb52248de6ffa47a4b97b624ade9eb862e970163dfd274096b1d72c8848c2e68716164ae1d1fc4dfab88c9dbf0c1a125f33b24008c6ca4f459ad33fa6e9c5e116052cfe1a9d1b4b4584734d5457f66621ba2f053cbf9047a78ad7");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbMenusAppService.DeleteAsync(1);

            // Assert
            var result = await _tbMenuRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}