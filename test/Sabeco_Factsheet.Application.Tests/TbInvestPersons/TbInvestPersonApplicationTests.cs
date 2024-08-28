using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbInvestPersons
{
    public abstract class TbInvestPersonsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbInvestPersonsAppService _tbInvestPersonsAppService;
        private readonly IRepository<TbInvestPerson, int> _tbInvestPersonRepository;

        public TbInvestPersonsAppServiceTests()
        {
            _tbInvestPersonsAppService = GetRequiredService<ITbInvestPersonsAppService>();
            _tbInvestPersonRepository = GetRequiredService<IRepository<TbInvestPerson, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbInvestPersonsAppService.GetListAsync(new GetTbInvestPersonsInput());

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
            var result = await _tbInvestPersonsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbInvestPersonCreateDto
            {
                ParentId = 263764001,
                PersonId = 1624557157,
                FromDate = new DateTime(2013, 9, 18),
                PersonalValue = 955328635,
                OwnerValue = 1617942513,
                Note = "294e9aa519f64ca180da657c748e12e5ec6ee99253f9447e98c6d3a31b5b7320ef9c3c253fa5437d82f9c97171e4fb3f1b9b79c773aa4f4ab704336b810a4dda776b5847deff4fc29a6ffb93347cc3a77a302612830d4ec88c3079f2e19685a1a59bb7e4cb004d0f82ebeff42f90d24cb9dc82cb953a40f0ab3c8e2a4e",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbInvestPersonsAppService.CreateAsync(input);

            // Assert
            var result = await _tbInvestPersonRepository.FindAsync(c => c.ParentId == serviceResult.ParentId);

            result.ShouldNotBe(null);
            result.ParentId.ShouldBe(263764001);
            result.PersonId.ShouldBe(1624557157);
            result.FromDate.ShouldBe(new DateTime(2013, 9, 18));
            result.PersonalValue.ShouldBe(955328635);
            result.OwnerValue.ShouldBe(1617942513);
            result.Note.ShouldBe("294e9aa519f64ca180da657c748e12e5ec6ee99253f9447e98c6d3a31b5b7320ef9c3c253fa5437d82f9c97171e4fb3f1b9b79c773aa4f4ab704336b810a4dda776b5847deff4fc29a6ffb93347cc3a77a302612830d4ec88c3079f2e19685a1a59bb7e4cb004d0f82ebeff42f90d24cb9dc82cb953a40f0ab3c8e2a4e");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbInvestPersonUpdateDto()
            {
                ParentId = 107066180,
                PersonId = 1278338435,
                FromDate = new DateTime(2004, 2, 22),
                PersonalValue = 915596359,
                OwnerValue = 968634660,
                Note = "740e6b66fbed44e2bef12e3d158d378a9bbb2ae1c79c445a94660bfc64d2d3ab59f02d5341b84666bda2bf5109f8be633601408e55504e2a90bb590f887558cbc1c4ef4a63524d44baa01f3892fcdce37b680cea3a0f4627acfbda18fd09ca728a8d92aa62dc4cf2ab18a19cf90edc10885c258c28984c4eac55d9b9ac",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbInvestPersonsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbInvestPersonRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ParentId.ShouldBe(107066180);
            result.PersonId.ShouldBe(1278338435);
            result.FromDate.ShouldBe(new DateTime(2004, 2, 22));
            result.PersonalValue.ShouldBe(915596359);
            result.OwnerValue.ShouldBe(968634660);
            result.Note.ShouldBe("740e6b66fbed44e2bef12e3d158d378a9bbb2ae1c79c445a94660bfc64d2d3ab59f02d5341b84666bda2bf5109f8be633601408e55504e2a90bb590f887558cbc1c4ef4a63524d44baa01f3892fcdce37b680cea3a0f4627acfbda18fd09ca728a8d92aa62dc4cf2ab18a19cf90edc10885c258c28984c4eac55d9b9ac");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbInvestPersonsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbInvestPersonRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}