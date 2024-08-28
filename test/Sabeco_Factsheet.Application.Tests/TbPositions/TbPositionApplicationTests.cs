using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbPositions
{
    public abstract class TbPositionsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbPositionsAppService _tbPositionsAppService;
        private readonly IRepository<TbPosition, int> _tbPositionRepository;

        public TbPositionsAppServiceTests()
        {
            _tbPositionsAppService = GetRequiredService<ITbPositionsAppService>();
            _tbPositionRepository = GetRequiredService<IRepository<TbPosition, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbPositionsAppService.GetListAsync(new GetTbPositionsInput());

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
            var result = await _tbPositionsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbPositionCreateDto
            {
                Code = "29b6579f425a402d92fe",
                Name = "bf0cd6e87068489aba75074192bd1b6276834d91d0c04d92ab9edc646676615cb71a7882f1894be29612fe0e9a0f5ca87112124d1bf540e79f278178cff043e939eddf2478694af2baa795645e6cab8604f7569b90a7493faaa393f4f44432614b089296b1524194a70d9d4623d20051162d50740e8f4fb0ade9049deb",
                Name_EN = "8a8b592a4cd2413699cc0afbf7850efdd755d42d911c4891805f601684c9b7c29da6e10ad0574124bb4b4050ad028e0b6c0bbb1fe2be4379a200760f26da705b37066b1c8a6d4d38917cf138dc57b3966669b3b8dacf4b499da1f8b0526f7f7ce301e84a41334b63a0de9104dd74d3999a7cde7e098847979162f7d661",
                PositionType = 44,
                IsActive = true,
                OrderNumb = 1639911121
            };

            // Act
            var serviceResult = await _tbPositionsAppService.CreateAsync(input);

            // Assert
            var result = await _tbPositionRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("29b6579f425a402d92fe");
            result.Name.ShouldBe("bf0cd6e87068489aba75074192bd1b6276834d91d0c04d92ab9edc646676615cb71a7882f1894be29612fe0e9a0f5ca87112124d1bf540e79f278178cff043e939eddf2478694af2baa795645e6cab8604f7569b90a7493faaa393f4f44432614b089296b1524194a70d9d4623d20051162d50740e8f4fb0ade9049deb");
            result.Name_EN.ShouldBe("8a8b592a4cd2413699cc0afbf7850efdd755d42d911c4891805f601684c9b7c29da6e10ad0574124bb4b4050ad028e0b6c0bbb1fe2be4379a200760f26da705b37066b1c8a6d4d38917cf138dc57b3966669b3b8dacf4b499da1f8b0526f7f7ce301e84a41334b63a0de9104dd74d3999a7cde7e098847979162f7d661");
            result.PositionType.ShouldBe((byte?)44);
            result.IsActive.ShouldBe(true);
            result.OrderNumb.ShouldBe(1639911121);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbPositionUpdateDto()
            {
                Code = "9458770f0d0448d2a797",
                Name = "7369d55e3bf14bb4a998b234f7ddf3ee0290f3bfc0684aae984917194d245b09a81ea2e464984d0f888410ec953359234603f75d19e043de8f9b8a4b95effb4a9808dc63912b4cc081dda2afd215761e318b5683f882489db674c8a13a50e132ae77e34000da41a896cc54a81e3a605a98c1b6aa68cd45b98f9ac79aed",
                Name_EN = "b0198aa18a7f4f6a90a2964ee309489ac54c336146bb4ff98968ca6f6f4ebe61ae2e2770439443bfb74c7f7908359babee15b21198a5498c946d36f97d52fabf937339d9f6a942d58faffeaeb804900c534c54e5ee2240fdbeaca85ef61c562ab2aa0f4f14c74819a666b5a57a86984144a93b8f77f54975aefe8fddea",
                PositionType = 122,
                IsActive = true,
                OrderNumb = 1947200564
            };

            // Act
            var serviceResult = await _tbPositionsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbPositionRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("9458770f0d0448d2a797");
            result.Name.ShouldBe("7369d55e3bf14bb4a998b234f7ddf3ee0290f3bfc0684aae984917194d245b09a81ea2e464984d0f888410ec953359234603f75d19e043de8f9b8a4b95effb4a9808dc63912b4cc081dda2afd215761e318b5683f882489db674c8a13a50e132ae77e34000da41a896cc54a81e3a605a98c1b6aa68cd45b98f9ac79aed");
            result.Name_EN.ShouldBe("b0198aa18a7f4f6a90a2964ee309489ac54c336146bb4ff98968ca6f6f4ebe61ae2e2770439443bfb74c7f7908359babee15b21198a5498c946d36f97d52fabf937339d9f6a942d58faffeaeb804900c534c54e5ee2240fdbeaca85ef61c562ab2aa0f4f14c74819a666b5a57a86984144a93b8f77f54975aefe8fddea");
            result.PositionType.ShouldBe((byte?)122);
            result.IsActive.ShouldBe(true);
            result.OrderNumb.ShouldBe(1947200564);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbPositionsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbPositionRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}