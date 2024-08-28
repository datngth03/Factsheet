using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbInvestPersons;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbInvestPersons
{
    public class TbInvestPersonRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbInvestPersonRepository _tbInvestPersonRepository;

        public TbInvestPersonRepositoryTests()
        {
            _tbInvestPersonRepository = GetRequiredService<ITbInvestPersonRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbInvestPersonRepository.GetListAsync(
                    note: "f6bbce5a262d4560b65393779b083ff14c2e7931f5204972972f642435c7075e06742d77e12c419d9a66b7179c424d30773097dab1e74231a5a5fb7c66185f36f3f91508010b462f86b97d8b97526d77289c152045ae4290bcfae93fec8d28f277c3fba9a16947359df24b4bd113ffdb136bb1d12eaf40978243eb9713",
                    isActive: true
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(1);
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbInvestPersonRepository.GetCountAsync(
                    note: "c1ac57814ce244aa84641816e0e9504468d63964498d4c00a3d848cb10ba8224628adf93c6104315b48101645c5440a5d8dbfb5278714fb88c5a06243a80cd94a063caf365f142a3b87d29533e47ac5314160749804d4cb3841e884065623c19a9f35d1c08954297ac30669ba6f6b6da4389678f2e714fe78af1d70761",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}