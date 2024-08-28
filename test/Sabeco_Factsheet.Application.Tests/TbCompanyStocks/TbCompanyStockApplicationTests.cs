using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanyStocks
{
    public abstract class TbCompanyStocksAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompanyStocksAppService _TbCompanyStocksAppService;
        private readonly IRepository<TbCompanyStock, int> _TbCompanyStockRepository;

        public TbCompanyStocksAppServiceTests()
        {
            _TbCompanyStocksAppService = GetRequiredService<ITbCompanyStocksAppService>();
            _TbCompanyStockRepository = GetRequiredService<IRepository<TbCompanyStock, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _TbCompanyStocksAppService.GetListAsync(new GetTbCompanyStocksInput());

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
            var result = await _TbCompanyStocksAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyStockCreateDto
            {
                CompanyId = 957321271,
                CompanyCode = "888b935e8ad042679963",
                IsPublicCompany = true,
                StockExchange = "5937cd1f11",
                RegistrationDate = new DateTime(2001, 4, 15),
                CharteredCapital = 2101031590,
                ParValue = 1354171652,
                TotalShare = 867483894,
                ListedShare = 1532335232,
                Description = "9659189a143a4ec299c526db030dd661104670fd767c40e79191e633c75e9d706df5b422eb5e408a8001afb5d7f2ddede14c5301e99e402a87dd4d6d12cf59c0c86a1a4a53784341bca3ba8166cd1698023938fd018044a1a6bbb9319a58b4c5199805520c6f4e4a88705d32be8c51980688f7a28b794c4dabb57ade12",
                IsActive = true,
                crt_date = new DateTime(2003, 4, 21),
                crt_user = 1632085670
            };

            // Act
            var serviceResult = await _TbCompanyStocksAppService.CreateAsync(input);

            // Assert
            var result = await _TbCompanyStockRepository.FindAsync(c => c.CompanyId == serviceResult.CompanyId);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(957321271);
            result.CompanyCode.ShouldBe("888b935e8ad042679963");
            result.IsPublicCompany.ShouldBe(true);
            result.StockExchange.ShouldBe("5937cd1f11");
            result.RegistrationDate.ShouldBe(new DateTime(2001, 4, 15));
            result.CharteredCapital.ShouldBe(2101031590);
            result.ParValue.ShouldBe(1354171652);
            result.TotalShare.ShouldBe(867483894);
            result.ListedShare.ShouldBe(1532335232);
            result.Description.ShouldBe("9659189a143a4ec299c526db030dd661104670fd767c40e79191e633c75e9d706df5b422eb5e408a8001afb5d7f2ddede14c5301e99e402a87dd4d6d12cf59c0c86a1a4a53784341bca3ba8166cd1698023938fd018044a1a6bbb9319a58b4c5199805520c6f4e4a88705d32be8c51980688f7a28b794c4dabb57ade12");
            result.IsActive.ShouldBe(true);
            result.crt_date.ShouldBe(new DateTime(2003, 4, 21));
            result.crt_user.ShouldBe(1632085670);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyStockUpdateDto()
            {
                CompanyId = 726196480,
                CompanyCode = "58c424ddc5ba49b786aa",
                IsPublicCompany = true,
                StockExchange = "2c85eaf0bb",
                RegistrationDate = new DateTime(2011, 3, 11),
                CharteredCapital = 2032098194,
                ParValue = 1342367019,
                TotalShare = 52572879,
                ListedShare = 1575416861,
                Description = "2234e0080b3e4a3d9813b63314916c16c9403d7a8cee488ab41137eb2b10c329ce8922215c8949c38929f5220f523167a389eaf96426492da3a6f250fb65d055e1e901c6967d4222b8654de02ef77973f192eabc42d44e2d948b48a84c7a0c090273133475d74047b99c51199d068c0b21f91108d245425eadf1d5585d",
                IsActive = true,
                crt_date = new DateTime(2004, 5, 15),
                crt_user = 1027958706
            };

            // Act
            var serviceResult = await _TbCompanyStocksAppService.UpdateAsync(1, input);

            // Assert
            var result = await _TbCompanyStockRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyId.ShouldBe(726196480);
            result.CompanyCode.ShouldBe("58c424ddc5ba49b786aa");
            result.IsPublicCompany.ShouldBe(true);
            result.StockExchange.ShouldBe("2c85eaf0bb");
            result.RegistrationDate.ShouldBe(new DateTime(2011, 3, 11));
            result.CharteredCapital.ShouldBe(2032098194);
            result.ParValue.ShouldBe(1342367019);
            result.TotalShare.ShouldBe(52572879);
            result.ListedShare.ShouldBe(1575416861);
            result.Description.ShouldBe("2234e0080b3e4a3d9813b63314916c16c9403d7a8cee488ab41137eb2b10c329ce8922215c8949c38929f5220f523167a389eaf96426492da3a6f250fb65d055e1e901c6967d4222b8654de02ef77973f192eabc42d44e2d948b48a84c7a0c090273133475d74047b99c51199d068c0b21f91108d245425eadf1d5585d");
            result.IsActive.ShouldBe(true);
            result.crt_date.ShouldBe(new DateTime(2004, 5, 15));
            result.crt_user.ShouldBe(1027958706);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _TbCompanyStocksAppService.DeleteAsync(1);

            // Assert
            var result = await _TbCompanyStockRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}