using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyPersons
{
    public abstract class TbCompanyPersonsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyPersonsAppService _tbCompanyPersonsAppService;
        private readonly IRepository<TbCompanyPerson, int> _tbCompanyPersonRepository;

        public TbCompanyPersonsAppServiceTests()
        {
            _tbCompanyPersonsAppService = GetRequiredService<ITbCompanyPersonsAppService>();
            _tbCompanyPersonRepository = GetRequiredService<IRepository<TbCompanyPerson, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyPersonsAppService.GetListAsync(new GetTbCompanyPersonsInput());

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
            var result = await _tbCompanyPersonsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyPersonCreateDto
            {
                BranchCode = "865b277bbf",
                CompanyId = 1059524976,
                PersonId = 110046582,
                PositionId = 511106521,
                FromDate = new DateTime(2000, 10, 26),
                ToDate = new DateTime(2021, 11, 17),
                PositionCode = "6e9f167a4cf74aa19437",
                PersonalValue = 447833149,
                PersonalSharePercentage = 1060579222,
                OwnerValue = 1717763433,
                RepresentativePercentage = 1272670940,
                Note = "e0f543ac743642a9b56b8005fb53eee874865184b8b24f6ebf464d2c07f967dc62961b6ee5664ad99899364d06d0e56d4c1376d3004446288c44b810480693a71eef8ce745ee45a9874e5086f57702ea158d8703b0bc44908702d2b8909fa68876a0c5cf99ab49faaef2a703fa4c3c1a465f26129e624b89a654fdbc68",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbCompanyPersonsAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyPersonRepository.FindAsync(c => c.BranchCode == serviceResult.BranchCode);

            result.ShouldNotBe(null);
            result.BranchCode.ShouldBe("865b277bbf");
            result.CompanyId.ShouldBe(1059524976);
            result.PersonId.ShouldBe(110046582);
            result.PositionId.ShouldBe(511106521);
            result.FromDate.ShouldBe(new DateTime(2000, 10, 26));
            result.ToDate.ShouldBe(new DateTime(2021, 11, 17));
            result.PositionCode.ShouldBe("6e9f167a4cf74aa19437");
            result.PersonalValue.ShouldBe(447833149);
            result.PersonalSharePercentage.ShouldBe(1060579222);
            result.OwnerValue.ShouldBe(1717763433);
            result.RepresentativePercentage.ShouldBe(1272670940);
            result.Note.ShouldBe("e0f543ac743642a9b56b8005fb53eee874865184b8b24f6ebf464d2c07f967dc62961b6ee5664ad99899364d06d0e56d4c1376d3004446288c44b810480693a71eef8ce745ee45a9874e5086f57702ea158d8703b0bc44908702d2b8909fa68876a0c5cf99ab49faaef2a703fa4c3c1a465f26129e624b89a654fdbc68");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyPersonUpdateDto()
            {
                BranchCode = "e718c1aeb3",
                CompanyId = 1875733291,
                PersonId = 599244262,
                PositionId = 1031592802,
                FromDate = new DateTime(2007, 9, 10),
                ToDate = new DateTime(2009, 10, 5),
                PositionCode = "bfb265fde3a44a8ea576",
                PersonalValue = 1875182997,
                PersonalSharePercentage = 382744535,
                OwnerValue = 834523926,
                RepresentativePercentage = 815065807,
                Note = "1cfb9a023e35488bac66ec7f640c1169e96f75a96f0543f3b3a436b9873bf9355f72f7fa13d64f85976372a02002894f4569e07b992e4afda862f49d86cb75d89e41006b95a14454aec87d20be51f367cdfc39eab0ab4b82b530c6ec1570772f41a8938ab87143d493f07ee883560ec1136996cdd23f4b39b00ed7b04d",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbCompanyPersonsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyPersonRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.BranchCode.ShouldBe("e718c1aeb3");
            result.CompanyId.ShouldBe(1875733291);
            result.PersonId.ShouldBe(599244262);
            result.PositionId.ShouldBe(1031592802);
            result.FromDate.ShouldBe(new DateTime(2007, 9, 10));
            result.ToDate.ShouldBe(new DateTime(2009, 10, 5));
            result.PositionCode.ShouldBe("bfb265fde3a44a8ea576");
            result.PersonalValue.ShouldBe(1875182997);
            result.PersonalSharePercentage.ShouldBe(382744535);
            result.OwnerValue.ShouldBe(834523926);
            result.RepresentativePercentage.ShouldBe(815065807);
            result.Note.ShouldBe("1cfb9a023e35488bac66ec7f640c1169e96f75a96f0543f3b3a436b9873bf9355f72f7fa13d64f85976372a02002894f4569e07b992e4afda862f49d86cb75d89e41006b95a14454aec87d20be51f367cdfc39eab0ab4b82b530c6ec1570772f41a8938ab87143d493f07ee883560ec1136996cdd23f4b39b00ed7b04d");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyPersonsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyPersonRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}