using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyPersonTemps
{
    public abstract class TbCompanyPersonTempsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyPersonTempsAppService _tbCompanyPersonTempsAppService;
        private readonly IRepository<TbCompanyPersonTemp, int> _tbCompanyPersonTempRepository;

        public TbCompanyPersonTempsAppServiceTests()
        {
            _tbCompanyPersonTempsAppService = GetRequiredService<ITbCompanyPersonTempsAppService>();
            _tbCompanyPersonTempRepository = GetRequiredService<IRepository<TbCompanyPersonTemp, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyPersonTempsAppService.GetListAsync(new GetTbCompanyPersonTempsInput());

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
            var result = await _tbCompanyPersonTempsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyPersonTempCreateDto
            {
                idCompanyPerson = 1858556984,
                BranchCode = "50f937c8c3",
                CompanyId = 884951323,
                PersonId = 1397108312,
                PositionId = 1807937251,
                FromDate = new DateTime(2020, 1, 2),
                ToDate = new DateTime(2012, 11, 21),
                PositionCode = "448776eccfcc4a519719",
                PersonalValue = 1817315234,
                PersonalSharePercentage = 1662788000,
                OwnerValue = 244250234,
                RepresentativePercentage = 2042012623,
                Note = "42d80408b1ef404cbe04e284a0f34c9877f4e8789a5b4b31b3ea9f6c66edf2dc8c484be9a7294841b9cd9bd610458a223f3230966fa843f780d63f4dc8f3581f99905105868945ad9dd1db728536b79a001a7f74dd4e44f0b45e18714bf1f572854f67f640524b1e870fe0f62ae52587cae2950f016e4c918b4d5992ed",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbCompanyPersonTempsAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyPersonTempRepository.FindAsync(c => c.idCompanyPerson == serviceResult.idCompanyPerson);

            result.ShouldNotBe(null);
            result.idCompanyPerson.ShouldBe(1858556984);
            result.BranchCode.ShouldBe("50f937c8c3");
            result.CompanyId.ShouldBe(884951323);
            result.PersonId.ShouldBe(1397108312);
            result.PositionId.ShouldBe(1807937251);
            result.FromDate.ShouldBe(new DateTime(2020, 1, 2));
            result.ToDate.ShouldBe(new DateTime(2012, 11, 21));
            result.PositionCode.ShouldBe("448776eccfcc4a519719");
            result.PersonalValue.ShouldBe(1817315234);
            result.PersonalSharePercentage.ShouldBe(1662788000);
            result.OwnerValue.ShouldBe(244250234);
            result.RepresentativePercentage.ShouldBe(2042012623);
            result.Note.ShouldBe("42d80408b1ef404cbe04e284a0f34c9877f4e8789a5b4b31b3ea9f6c66edf2dc8c484be9a7294841b9cd9bd610458a223f3230966fa843f780d63f4dc8f3581f99905105868945ad9dd1db728536b79a001a7f74dd4e44f0b45e18714bf1f572854f67f640524b1e870fe0f62ae52587cae2950f016e4c918b4d5992ed");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyPersonTempUpdateDto()
            {
                idCompanyPerson = 1964686818,
                BranchCode = "d58bf37515",
                CompanyId = 360417579,
                PersonId = 856118044,
                PositionId = 334128690,
                FromDate = new DateTime(2020, 11, 1),
                ToDate = new DateTime(2012, 7, 5),
                PositionCode = "986c7a8db09c41b5b852",
                PersonalValue = 935979687,
                PersonalSharePercentage = 1966989179,
                OwnerValue = 2063469477,
                RepresentativePercentage = 1103654730,
                Note = "87be1463a18e4b6db40f2217cf6ab426651f4e4267164b51a266513fdc593ca6df92231c5bd74dffa3300e846ebbe5557082ad33402045399f7ef458b72475232953beaac573407191e1f467cc259f685b011cd072294582841f0cd04da91fc0e0410143b3ec4ce8b4bc68fcdab37364a8090293225141cda2bd579c52",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbCompanyPersonTempsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyPersonTempRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.idCompanyPerson.ShouldBe(1964686818);
            result.BranchCode.ShouldBe("d58bf37515");
            result.CompanyId.ShouldBe(360417579);
            result.PersonId.ShouldBe(856118044);
            result.PositionId.ShouldBe(334128690);
            result.FromDate.ShouldBe(new DateTime(2020, 11, 1));
            result.ToDate.ShouldBe(new DateTime(2012, 7, 5));
            result.PositionCode.ShouldBe("986c7a8db09c41b5b852");
            result.PersonalValue.ShouldBe(935979687);
            result.PersonalSharePercentage.ShouldBe(1966989179);
            result.OwnerValue.ShouldBe(2063469477);
            result.RepresentativePercentage.ShouldBe(1103654730);
            result.Note.ShouldBe("87be1463a18e4b6db40f2217cf6ab426651f4e4267164b51a266513fdc593ca6df92231c5bd74dffa3300e846ebbe5557082ad33402045399f7ef458b72475232953beaac573407191e1f467cc259f685b011cd072294582841f0cd04da91fc0e0410143b3ec4ce8b4bc68fcdab37364a8090293225141cda2bd579c52");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyPersonTempsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyPersonTempRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}