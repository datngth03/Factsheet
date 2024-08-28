using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbBreweries;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbBreweries
{
    public class TbBreweryRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbBreweryRepository _tbBreweryRepository;

        public TbBreweryRepositoryTests()
        {
            _tbBreweryRepository = GetRequiredService<ITbBreweryRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbBreweryRepository.GetListAsync(
                    breweryCode: "48c2d9e934294658bb94",
                    breweryName: "ec4b893839bc448abef8a7325a4bab0e83607b92ab9d4726a6ebfa2b86a8ec58f9511bca8a4c4c5f90c972a28f68273ee20da542725a4598a4083938cdd08ad7d4ac9b8799ba4d90abf2655a76a5dda9364edf36136a4fb383f19006c69d1f470680a2b2b4654d95971ad81062870c041ff416e4b9614652a392f3d20e",
                    breweryName_EN: "6134da4339fe48ce81518a40cedd4a3a76f507230eed41d183f61c133b8ab95695031526ac894c10b5216bfedf4e3e090aa8a60d4a904332b9bf34625e76506a1476addb177f4dea84a4de9b4b7703252f40312d1ad24342a9910522b6dd31b8734dd811d3164077b8e68b56a10c7d41d55891ba65d14cd1a2a09f3036",
                    briefName: "916374f01719490c88a0a94f83ea9066a7ed4284768343cf801dd07007ccb0d0a8",
                    breweryAdress: "20471e56b25947109d747f19848cf2fbf09016e920a1468e95f8e3f2232026b3629",
                    note: "7d3e6517a76d4bb3b60ad",
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
                var result = await _tbBreweryRepository.GetCountAsync(
                    breweryCode: "1a9482fb3e5c438fbef2",
                    breweryName: "153b3fed71e947b383aaf5de98c9b7100cdedc5f9c194a1187aed270915e734bd71d9d960b6a4d278c1a1bf6e18c086bae6f1fc99c3942358c2db6e253f8087544b90ca573804f09a8439fc1d83a16fab5294499b03a43f5bd5f8743cbae84f80513731b844647199f0db5df4ebab136b61ab8d0e85141739f902fe8a5",
                    breweryName_EN: "1039649c34bf4045a527fd2c78cd37e7cfc3500098804c39afbe9eb1e946d731de7de2c42b504f3cb37f1ee7ea746159d7befe0117334210b230c22422c1fc5cbd30faf92dfb40de83727fff3d7a7fb6f98474685f2a403d9533eaad802d448de179662735de450e8f7ac86acedcd2dc840ede1980744019909f3fc290",
                    briefName: "37b56a19ec2c4a0db2384e72d98ef4b2d5127b3b79de410",
                    breweryAdress: "d5c382e4311545948d607e00634d72",
                    note: "28345bcc16974f67bed68419974e7b62f1e0d3eb2a3a4eae8b778f10bdc9e6152b78279df8c34d14b83806",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}