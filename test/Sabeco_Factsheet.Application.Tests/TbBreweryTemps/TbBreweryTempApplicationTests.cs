using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbBreweryTemps
{
    public abstract class TbBreweryTempsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbBreweryTempsAppService _tbBreweryTempsAppService;
        private readonly IRepository<TbBreweryTemp, int> _tbBreweryTempRepository;

        public TbBreweryTempsAppServiceTests()
        {
            _tbBreweryTempsAppService = GetRequiredService<ITbBreweryTempsAppService>();
            _tbBreweryTempRepository = GetRequiredService<IRepository<TbBreweryTemp, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbBreweryTempsAppService.GetListAsync(new GetTbBreweryTempsInput());

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
            var result = await _tbBreweryTempsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbBreweryTempCreateDto
            {
                idBrewery = 967166751,
                BreweryCode = "4946cb698dcf4994b8d7",
                BreweryName = "42c594b2a9134548a5ee356d1bbb1bbadda5960946fd4e01aa4a75ba81582f03cf8418ee4c1345e1b2c5a16b024e64340a8d4919005d406493e1733a60fff973ee1220b3f84c41efb6839c2157cfb6af2e4c518912a749efa1152c2171db5a63892b7444e910467ba57efadf4663cd809af71222f3a4481381ab995c2e",
                BreweryName_EN = "2b0e1725ba084e59b72043e8730663e0c285c70382064b19aa6b8898c1078e7687e57d0395b84a18a631b122db8f1fbb585c1b9d3bd54fea84c00805833d7408302538cfcf11412085ca76ffaa785727313b55b27434444f844261219c1d8288cfe38eef19444eabb6d00a30617ac56ffdb650fe025c4d8caefb09ef91",
                BriefName = "2f50a357aad24014a61d0c0367edc9bdf936f",
                BreweryAdress = "276655b1292e4e69b33e8f75fdca1233bb02f10e894849469541994e6237e02906f9bdf22",
                CompanyId = 561743324,
                CapacityVolume = 299823965,
                DeliveryVolume = 1776791308,
                Note = "33689cb4116547a59338851849acf979b32adac903ed4cef801b76a2",
                DocStatus = 40,
                isActive = true
            };

            // Act
            var serviceResult = await _tbBreweryTempsAppService.CreateAsync(input);

            // Assert
            var result = await _tbBreweryTempRepository.FindAsync(c => c.idBrewery == serviceResult.idBrewery);

            result.ShouldNotBe(null);
            result.idBrewery.ShouldBe(967166751);
            result.BreweryCode.ShouldBe("4946cb698dcf4994b8d7");
            result.BreweryName.ShouldBe("42c594b2a9134548a5ee356d1bbb1bbadda5960946fd4e01aa4a75ba81582f03cf8418ee4c1345e1b2c5a16b024e64340a8d4919005d406493e1733a60fff973ee1220b3f84c41efb6839c2157cfb6af2e4c518912a749efa1152c2171db5a63892b7444e910467ba57efadf4663cd809af71222f3a4481381ab995c2e");
            result.BreweryName_EN.ShouldBe("2b0e1725ba084e59b72043e8730663e0c285c70382064b19aa6b8898c1078e7687e57d0395b84a18a631b122db8f1fbb585c1b9d3bd54fea84c00805833d7408302538cfcf11412085ca76ffaa785727313b55b27434444f844261219c1d8288cfe38eef19444eabb6d00a30617ac56ffdb650fe025c4d8caefb09ef91");
            result.BriefName.ShouldBe("2f50a357aad24014a61d0c0367edc9bdf936f");
            result.BreweryAdress.ShouldBe("276655b1292e4e69b33e8f75fdca1233bb02f10e894849469541994e6237e02906f9bdf22");
            result.CompanyId.ShouldBe(561743324);
            result.CapacityVolume.ShouldBe(299823965);
            result.DeliveryVolume.ShouldBe(1776791308);
            result.Note.ShouldBe("33689cb4116547a59338851849acf979b32adac903ed4cef801b76a2");
            result.DocStatus.ShouldBe((byte?)40);
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbBreweryTempUpdateDto()
            {
                idBrewery = 1646164776,
                BreweryCode = "97926ae4c19b419cac4b",
                BreweryName = "9f4a4d6898f043a89e24f67d9b7ca250a69876b86a514c3a9eb2fff25c7f9a57c5b73cdf91ed459ba261ec2f14ae4cbe2217541b9fa44bc9a2a6158c28839c991a935cc97aa140afa88befa5c3f2f2e07889117cf5c344b6af7b5ceb0f2c1fa829ec688bf57a47c09dfe49f03d434e9d9c0f0128eb03428fbeb1fb685c",
                BreweryName_EN = "abb644e162f64474beb7193bfd13f04b4361148788dd446196798a349ceb600ad939a9a5459c4f77907da2d61f3602f35b9f3f851b9d47ad8d93e83d7839329402ee8824de4540d68eb06ad1696e42279e12f4b1e7bf4dac97a6060a8cf1a4b14134ff5bd7c84451a027e5e93c74206bf9abcd39d3764db8a6a8ce79a7",
                BriefName = "0c91d7f0aacd4a75a2a7ece67d650a84fd9cafc",
                BreweryAdress = "0874cf58fdb643438d277b1b0b6ab8584919e8b736e54556baa9ee33c01a02f69ae27fc76d4444bfa41896f74da43",
                CompanyId = 334614691,
                CapacityVolume = 374758360,
                DeliveryVolume = 472291179,
                Note = "44fac5442c3a4807",
                DocStatus = 64,
                isActive = true
            };

            // Act
            var serviceResult = await _tbBreweryTempsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbBreweryTempRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.idBrewery.ShouldBe(1646164776);
            result.BreweryCode.ShouldBe("97926ae4c19b419cac4b");
            result.BreweryName.ShouldBe("9f4a4d6898f043a89e24f67d9b7ca250a69876b86a514c3a9eb2fff25c7f9a57c5b73cdf91ed459ba261ec2f14ae4cbe2217541b9fa44bc9a2a6158c28839c991a935cc97aa140afa88befa5c3f2f2e07889117cf5c344b6af7b5ceb0f2c1fa829ec688bf57a47c09dfe49f03d434e9d9c0f0128eb03428fbeb1fb685c");
            result.BreweryName_EN.ShouldBe("abb644e162f64474beb7193bfd13f04b4361148788dd446196798a349ceb600ad939a9a5459c4f77907da2d61f3602f35b9f3f851b9d47ad8d93e83d7839329402ee8824de4540d68eb06ad1696e42279e12f4b1e7bf4dac97a6060a8cf1a4b14134ff5bd7c84451a027e5e93c74206bf9abcd39d3764db8a6a8ce79a7");
            result.BriefName.ShouldBe("0c91d7f0aacd4a75a2a7ece67d650a84fd9cafc");
            result.BreweryAdress.ShouldBe("0874cf58fdb643438d277b1b0b6ab8584919e8b736e54556baa9ee33c01a02f69ae27fc76d4444bfa41896f74da43");
            result.CompanyId.ShouldBe(334614691);
            result.CapacityVolume.ShouldBe(374758360);
            result.DeliveryVolume.ShouldBe(472291179);
            result.Note.ShouldBe("44fac5442c3a4807");
            result.DocStatus.ShouldBe((byte?)64);
            result.isActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbBreweryTempsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbBreweryTempRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}