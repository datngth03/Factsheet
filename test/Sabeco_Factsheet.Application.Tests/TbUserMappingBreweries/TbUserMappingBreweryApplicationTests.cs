using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public abstract class TbUserMappingBreweriesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbUserMappingBreweriesAppService _tbUserMappingBreweriesAppService;
        private readonly IRepository<TbUserMappingBrewery, int> _tbUserMappingBreweryRepository;

        public TbUserMappingBreweriesAppServiceTests()
        {
            _tbUserMappingBreweriesAppService = GetRequiredService<ITbUserMappingBreweriesAppService>();
            _tbUserMappingBreweryRepository = GetRequiredService<IRepository<TbUserMappingBrewery, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbUserMappingBreweriesAppService.GetListAsync(new GetTbUserMappingBreweriesInput());

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
            var result = await _tbUserMappingBreweriesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbUserMappingBreweryCreateDto
            {
                userid = 1409413765,
                breweryid = 1345729082,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbUserMappingBreweriesAppService.CreateAsync(input);

            // Assert
            var result = await _tbUserMappingBreweryRepository.FindAsync(c => c.userid == serviceResult.userid);

            result.ShouldNotBe(null);
            result.userid.ShouldBe(1409413765);
            result.breweryid.ShouldBe(1345729082);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbUserMappingBreweryUpdateDto()
            {
                userid = 2043208810,
                breweryid = 1393519840,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbUserMappingBreweriesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbUserMappingBreweryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.userid.ShouldBe(2043208810);
            result.breweryid.ShouldBe(1393519840);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbUserMappingBreweriesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbUserMappingBreweryRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}