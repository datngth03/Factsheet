using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public abstract class TbUserMappingPersonsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbUserMappingPersonsAppService _tbUserMappingPersonsAppService;
        private readonly IRepository<TbUserMappingPerson, int> _tbUserMappingPersonRepository;

        public TbUserMappingPersonsAppServiceTests()
        {
            _tbUserMappingPersonsAppService = GetRequiredService<ITbUserMappingPersonsAppService>();
            _tbUserMappingPersonRepository = GetRequiredService<IRepository<TbUserMappingPerson, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbUserMappingPersonsAppService.GetListAsync(new GetTbUserMappingPersonsInput());

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
            var result = await _tbUserMappingPersonsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbUserMappingPersonCreateDto
            {
                userid = 1599781984,
                personid = 1705597370,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbUserMappingPersonsAppService.CreateAsync(input);

            // Assert
            var result = await _tbUserMappingPersonRepository.FindAsync(c => c.userid == serviceResult.userid);

            result.ShouldNotBe(null);
            result.userid.ShouldBe(1599781984);
            result.personid.ShouldBe(1705597370);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbUserMappingPersonUpdateDto()
            {
                userid = 631729056,
                personid = 1224021546,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbUserMappingPersonsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbUserMappingPersonRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.userid.ShouldBe(631729056);
            result.personid.ShouldBe(1224021546);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbUserMappingPersonsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbUserMappingPersonRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}