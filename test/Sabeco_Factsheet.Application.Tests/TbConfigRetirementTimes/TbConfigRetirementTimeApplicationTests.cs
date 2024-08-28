using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public abstract class TbConfigRetirementTimesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbConfigRetirementTimesAppService _tbConfigRetirementTimesAppService;
        private readonly IRepository<TbConfigRetirementTime, int> _tbConfigRetirementTimeRepository;

        public TbConfigRetirementTimesAppServiceTests()
        {
            _tbConfigRetirementTimesAppService = GetRequiredService<ITbConfigRetirementTimesAppService>();
            _tbConfigRetirementTimeRepository = GetRequiredService<IRepository<TbConfigRetirementTime, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbConfigRetirementTimesAppService.GetListAsync(new GetTbConfigRetirementTimesInput());

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
            var result = await _tbConfigRetirementTimesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbConfigRetirementTimeCreateDto
            {
                Code = "abf80eadbcdd42e68278ed84624fd6b071f24fb6f6bf4e99a29fc1b40d1",
                YearNumb = 1927535937,
                MonthNumb = 964025784,
                DayNumb = 1280053641,
                Note = "aff29daec80441c584970fb18973c2e02a1e234de2bf45669547fdcf86c9b6f098837c8de2fd4b9d9a1c0756e"
            };

            // Act
            var serviceResult = await _tbConfigRetirementTimesAppService.CreateAsync(input);

            // Assert
            var result = await _tbConfigRetirementTimeRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("abf80eadbcdd42e68278ed84624fd6b071f24fb6f6bf4e99a29fc1b40d1");
            result.YearNumb.ShouldBe(1927535937);
            result.MonthNumb.ShouldBe(964025784);
            result.DayNumb.ShouldBe(1280053641);
            result.Note.ShouldBe("aff29daec80441c584970fb18973c2e02a1e234de2bf45669547fdcf86c9b6f098837c8de2fd4b9d9a1c0756e");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbConfigRetirementTimeUpdateDto()
            {
                Code = "28e1308a8f664d5e87588c951f34812c6f7d395c8ade4f",
                YearNumb = 1680601893,
                MonthNumb = 2130400723,
                DayNumb = 69000532,
                Note = "89d31379da5944329e42c846b6310302f371f4f86fa84c239197584e88afd154ee3131f652"
            };

            // Act
            var serviceResult = await _tbConfigRetirementTimesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbConfigRetirementTimeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("28e1308a8f664d5e87588c951f34812c6f7d395c8ade4f");
            result.YearNumb.ShouldBe(1680601893);
            result.MonthNumb.ShouldBe(2130400723);
            result.DayNumb.ShouldBe(69000532);
            result.Note.ShouldBe("89d31379da5944329e42c846b6310302f371f4f86fa84c239197584e88afd154ee3131f652");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbConfigRetirementTimesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbConfigRetirementTimeRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}