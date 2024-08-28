using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbCompanyPersonTemps;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbCompanyPersonTemps
{
    public class TbCompanyPersonTempRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbCompanyPersonTempRepository _tbCompanyPersonTempRepository;

        public TbCompanyPersonTempRepositoryTests()
        {
            _tbCompanyPersonTempRepository = GetRequiredService<ITbCompanyPersonTempRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbCompanyPersonTempRepository.GetListAsync(
                    branchCode: "ddb480e473",
                    positionCode: "b0cb569598d4493991f4",
                    note: "b19a8dce534643daabe9d785c15c7678232790d0dfbe4831954b8a5501ed647cd6e9663f8d2441f890a9b72af0dda9b537b8a2ecd4fb4cb6aa4ef09b4e7b34b2ea537d61b17b4395b4c820462a0646cb159896f527454ab8b297bc66a196ff427bec549883b14fda82f13dcc708b7f04d195b0043f7d49abbdbd41d373",
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
                var result = await _tbCompanyPersonTempRepository.GetCountAsync(
                    branchCode: "2e4b150b49",
                    positionCode: "bd41a5ac58e74f6fb3a4",
                    note: "8185ebcd703c406f947f10cd8d7aefa11b83547b91184bdcaf2bc7baf50d42b0a208471772504a3a8314debdf06f084261a64f702ca54fff8c8a2ff9e6f51e5fa7d1a702b03d4173a5bdce248be07eabd105da96cf6b4bd0aac87dd7d1cf0162affad15642324abebcfe194739290aae9ed2e7aa55db4dc6aedf9395f4",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}