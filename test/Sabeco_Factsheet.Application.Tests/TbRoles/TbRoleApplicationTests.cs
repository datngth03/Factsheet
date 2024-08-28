using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbRoles
{
    public abstract class TbRolesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbRolesAppService _tbRolesAppService;
        private readonly IRepository<TbRole, int> _tbRoleRepository;

        public TbRolesAppServiceTests()
        {
            _tbRolesAppService = GetRequiredService<ITbRolesAppService>();
            _tbRoleRepository = GetRequiredService<IRepository<TbRole, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbRolesAppService.GetListAsync(new GetTbRolesInput());

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
            var result = await _tbRolesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbRoleCreateDto
            {
                Code = "5fe3ec510ae949508346",
                Name = "81d6d3d19844492db5fd87f736796a3870c388d1361042c4b2e44d55a45ec58183ddc8b6a476404c96422ed7d66e7637b1f7e03b9b9b40ddba7ca262c1ae9dd74b441e87d7c64a81a10d9fbf8c2952a94f0e0c9baa53405784b76e9a2da2e6fb8fd5473914744cab92ae64b89555b6f016626b547fdc4f4f9798ce57b2",
                Description = "6fffdbb54dda402e8331229463f683eda199c9d1eb0e42e2829a4f63a1ce3553302607b933814dca8262aa4465005d4b1cd7dd411c6341e8ad8596c20c50731fcf37de4ea14b4f94bfa268d61f362a7d68415902fed34298a50581a34f536c88770c4e51839843f6a51cced9b1b285becfc64c4f424f44158211d7e17b",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbRolesAppService.CreateAsync(input);

            // Assert
            var result = await _tbRoleRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("5fe3ec510ae949508346");
            result.Name.ShouldBe("81d6d3d19844492db5fd87f736796a3870c388d1361042c4b2e44d55a45ec58183ddc8b6a476404c96422ed7d66e7637b1f7e03b9b9b40ddba7ca262c1ae9dd74b441e87d7c64a81a10d9fbf8c2952a94f0e0c9baa53405784b76e9a2da2e6fb8fd5473914744cab92ae64b89555b6f016626b547fdc4f4f9798ce57b2");
            result.Description.ShouldBe("6fffdbb54dda402e8331229463f683eda199c9d1eb0e42e2829a4f63a1ce3553302607b933814dca8262aa4465005d4b1cd7dd411c6341e8ad8596c20c50731fcf37de4ea14b4f94bfa268d61f362a7d68415902fed34298a50581a34f536c88770c4e51839843f6a51cced9b1b285becfc64c4f424f44158211d7e17b");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbRoleUpdateDto()
            {
                Code = "c49f88d94c214e0682e0",
                Name = "708e2edd3f0c445daa1967a7aad4308c6e09a3242f094f748434e74c58bdd80b6f78db1130da4af4a79fef9b87c66cd169a3408e0b0e468b979b41982cf0b8d1fada6eebfc44408e96b9fc40328a750b7cd1094025a84a23bcb985fd6e92326f8a421dd234a24b8380138d413d0dba42a14bace7637b497db39f4e448b",
                Description = "8176a31ce7fd4b30a9df7d41db4fabf8591dfb69687b4e379c6bfff172280528d648562a762c416a92a49c4866f7b1a1e9caa49f189c4888804ea6c1948242962d35ee0a38174d36b658172cef9f3516f8601a7440f946d59ccb82ffedeb16e1b97e19b7b59145d09407840d064326cc6d51e3a490c04c1aa614917cf2",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbRolesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbRoleRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("c49f88d94c214e0682e0");
            result.Name.ShouldBe("708e2edd3f0c445daa1967a7aad4308c6e09a3242f094f748434e74c58bdd80b6f78db1130da4af4a79fef9b87c66cd169a3408e0b0e468b979b41982cf0b8d1fada6eebfc44408e96b9fc40328a750b7cd1094025a84a23bcb985fd6e92326f8a421dd234a24b8380138d413d0dba42a14bace7637b497db39f4e448b");
            result.Description.ShouldBe("8176a31ce7fd4b30a9df7d41db4fabf8591dfb69687b4e379c6bfff172280528d648562a762c416a92a49c4866f7b1a1e9caa49f189c4888804ea6c1948242962d35ee0a38174d36b658172cef9f3516f8601a7440f946d59ccb82ffedeb16e1b97e19b7b59145d09407840d064326cc6d51e3a490c04c1aa614917cf2");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbRolesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbRoleRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}