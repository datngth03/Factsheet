using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyMajors
{
    public abstract class TbCompanyMajorsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyMajorsAppService _tbCompanyMajorsAppService;
        private readonly IRepository<TbCompanyMajor, int> _tbCompanyMajorRepository;

        public TbCompanyMajorsAppServiceTests()
        {
            _tbCompanyMajorsAppService = GetRequiredService<ITbCompanyMajorsAppService>();
            _tbCompanyMajorRepository = GetRequiredService<IRepository<TbCompanyMajor, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompanyMajorsAppService.GetListAsync(new GetTbCompanyMajorsInput());

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
            var result = await _tbCompanyMajorsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyMajorCreateDto
            {
                CompanyId = 51567436,
                ShareHolderMajor = "e135bc23745f41b79ef38a",
                ShareHolderType = "54a5117d61e04e8d9d3c",
                FromDate = new DateTime(2015, 7, 26),
                ToDate = new DateTime(2014, 11, 7),
                ShareHolderValue = 31967312,
                ShareHolderRate = 657876377,
                Note = "6459392a8c0a40c88ad78fbac18e80137d6c7c8332c04c548764e26b2c800c39f37df4166181407ba503cc45e244dd8921f94caeeeb347588c2c37c76cbe74209930decf165b4f8990e10c18225523f23541d4db15f14038aa8a00c630bc898e20d9856b34a847d9ac365992b2379df6f55bdd206752484182f7bc984e",
                IsActive = true,
                ClassId = 958654250
            };

            // Act
            var serviceResult = await _tbCompanyMajorsAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyMajorRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(51567436);
            result.ShareHolderMajor.ShouldBe("e135bc23745f41b79ef38a");
            result.ShareHolderType.ShouldBe("54a5117d61e04e8d9d3c");
            result.FromDate.ShouldBe(new DateTime(2015, 7, 26));
            result.ToDate.ShouldBe(new DateTime(2014, 11, 7));
            result.ShareHolderValue.ShouldBe(31967312);
            result.ShareHolderRate.ShouldBe(657876377);
            result.Note.ShouldBe("6459392a8c0a40c88ad78fbac18e80137d6c7c8332c04c548764e26b2c800c39f37df4166181407ba503cc45e244dd8921f94caeeeb347588c2c37c76cbe74209930decf165b4f8990e10c18225523f23541d4db15f14038aa8a00c630bc898e20d9856b34a847d9ac365992b2379df6f55bdd206752484182f7bc984e");
            result.IsActive.ShouldBe(true);
            result.ClassId.ShouldBe(958654250);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyMajorUpdateDto()
            {
                CompanyId = 1993904553,
                ShareHolderMajor = "35b1e08789e548fba52c423bf75b084b42592e27ebe84e24946173fde2b47622",
                ShareHolderType = "e9d7da94744844ac91ff",
                FromDate = new DateTime(2012, 6, 8),
                ToDate = new DateTime(2010, 11, 6),
                ShareHolderValue = 101883677,
                ShareHolderRate = 117483913,
                Note = "70b85698d2f74a4ca4a53e93c3808a6df6f73c80db9c4bd384fe03f7bf86319a67d492a459214991b9b2388652e4afe16fc50396edf0400199585b6c3f81fd3470e97b6c5eff457f9aefd21ae483472756d44fe761d4446b9fa2dff43da15a63508abbf0acf24d87b0efbe300395fc81ec19e36a4e4b4fd68051390c73",
                IsActive = true,
                ClassId = 525534395
            };

            // Act
            var serviceResult = await _tbCompanyMajorsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyMajorRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(1993904553);
            result.ShareHolderMajor.ShouldBe("35b1e08789e548fba52c423bf75b084b42592e27ebe84e24946173fde2b47622");
            result.ShareHolderType.ShouldBe("e9d7da94744844ac91ff");
            result.FromDate.ShouldBe(new DateTime(2012, 6, 8));
            result.ToDate.ShouldBe(new DateTime(2010, 11, 6));
            result.ShareHolderValue.ShouldBe(101883677);
            result.ShareHolderRate.ShouldBe(117483913);
            result.Note.ShouldBe("70b85698d2f74a4ca4a53e93c3808a6df6f73c80db9c4bd384fe03f7bf86319a67d492a459214991b9b2388652e4afe16fc50396edf0400199585b6c3f81fd3470e97b6c5eff457f9aefd21ae483472756d44fe761d4446b9fa2dff43da15a63508abbf0acf24d87b0efbe300395fc81ec19e36a4e4b4fd68051390c73");
            result.IsActive.ShouldBe(true);
            result.ClassId.ShouldBe(525534395);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompanyMajorsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyMajorRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}