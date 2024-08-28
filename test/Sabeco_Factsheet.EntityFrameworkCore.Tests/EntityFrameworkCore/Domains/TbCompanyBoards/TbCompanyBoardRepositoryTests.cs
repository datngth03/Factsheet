using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbCompanyBoards;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbCompanyBoards
{
    public class TbCompanyBoardRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbCompanyBoardRepository _tbCompanyBoardRepository;

        public TbCompanyBoardRepositoryTests()
        {
            _tbCompanyBoardRepository = GetRequiredService<ITbCompanyBoardRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbCompanyBoardRepository.GetListAsync(
                    branchCode: "d50b74111c",
                    companyCode: "117f8f8d3d874ca5a0c0",
                    personCode: "88a02feaee3a450eb794",
                    positionCode: "6450fc879e244c9b81f4",
                    note: "2e29b5fa330c46ea873a61f155c5d521fcabd4373aad4ba087b72b4f2ffa6e7b6d92d97a61a847a39f2071e2eba7af0e71783b674eb047dfb9a2b0b7767549229ee7618e7e9549d6a279ab85412fd18a64edb2611e19459883cc1809fb84ab150c2043b393a74366b777a239937b2953a80771e02b6043f6bf1dfde287",
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
                var result = await _tbCompanyBoardRepository.GetCountAsync(
                    branchCode: "982c84b6fe",
                    companyCode: "e9e506cb164f4e209b00",
                    personCode: "d548f2b4f93d451fa6eb",
                    positionCode: "960297ecd92d4dbcac95",
                    note: "aebd3693b33b487490bc0cb1d5a52b6f3d9832e4dc7946ac8b11f00a9a43c47e79e5727047094b8c890241f40df00ba21fb490e57ac64f68a7218bf3c1fcd34de027f1fcfa57462fbb0938995c844beba2ef72a66bcb4ffd8282f2398e309ff5edda2677e1b64419a5328a32c14a2dd56d488ff5d3294ec88f4a6fe0f4",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}