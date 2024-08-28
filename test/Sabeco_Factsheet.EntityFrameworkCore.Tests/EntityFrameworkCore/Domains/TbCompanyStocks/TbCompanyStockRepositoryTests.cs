using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbCompanyStocks;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbCompanyStocks
{
    public class TbCompanyStockRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbCompanyStockRepository _TbCompanyStockRepository;

        public TbCompanyStockRepositoryTests()
        {
            _TbCompanyStockRepository = GetRequiredService<ITbCompanyStockRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _TbCompanyStockRepository.GetListAsync(
                    companyCode: "d6eac4543ced424a85d8",
                    isPublicCompany: true,
                    stockExchange: "a5112e9ffb",
                    description: "7d5e06678fb7494f816f898d1ab0c9d6ae83564977c44f8daee09f17fb538cd07d1f5de3f4194427a6001473cea050df833012c4f0d3428bafd947c2f09753dd16edf61aad3a46b4a033a98fde941e87baff8a8602bf4b6c90bebcfa76d8739cec4d9e538e89499e93b374a54b73db686a70df0a9d53427b81bc8ffd45",
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
                var result = await _TbCompanyStockRepository.GetCountAsync(
                    companyCode: "af0c563c244e4a7ba5a8",
                    isPublicCompany: true,
                    stockExchange: "045975fd8e",
                    description: "0011f99c61b4499294b46fefee315bfe6987933454ed472096941cd45fb5be9ac68e869dc69547caa657fb907e358b409cfb8744f9274150aa1e0892051993fa7b97ee203cb94c229f2d0370b46f8db2c330fa1e3a244ca882ca1279658087ac273c41236df444d79ccd9081c769ea847f50f1db24104299964a3d7dec",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}