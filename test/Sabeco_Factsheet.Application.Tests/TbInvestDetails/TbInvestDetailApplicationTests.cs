using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbInvestDetails
{
    public abstract class TbInvestDetailsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbInvestDetailsAppService _tbInvestDetailsAppService;
        private readonly IRepository<TbInvestDetail, int> _tbInvestDetailRepository;

        public TbInvestDetailsAppServiceTests()
        {
            _tbInvestDetailsAppService = GetRequiredService<ITbInvestDetailsAppService>();
            _tbInvestDetailRepository = GetRequiredService<IRepository<TbInvestDetail, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbInvestDetailsAppService.GetListAsync(new GetTbInvestDetailsInput());

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
            var result = await _tbInvestDetailsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbInvestDetailCreateDto
            {
                ParentId = 1411174207,
                DocDate = new DateTime(2007, 10, 5),
                DocNo = "1030997a0ade4509bfafefb0419ff287a75c31be98ec4aa0a2",
                InvestType = 1502892996,
                ShareNum = 738361616,
                ShareValue = 442082504,
                Note = "e66b5a4689d04e318c2d71afaa39010bf92727c885ce4836bca26717ff34eb66dca9a59ded6b45919d9dd1badb7462bd67e7c104d5054364b18136946ffc5daee141460138e344f79880637b4119cfa75dcc5de13ace448eaa3b32ca11f7e76f84bfa0cb58004e3ebaf18fa5b3d1450f08245d06f90f43e790328bb4f7",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbInvestDetailsAppService.CreateAsync(input);

            // Assert
            var result = await _tbInvestDetailRepository.FindAsync(c => c.ParentId == serviceResult.ParentId);

            result.ShouldNotBe(null);
            result.ParentId.ShouldBe(1411174207);
            result.DocDate.ShouldBe(new DateTime(2007, 10, 5));
            result.DocNo.ShouldBe("1030997a0ade4509bfafefb0419ff287a75c31be98ec4aa0a2");
            result.InvestType.ShouldBe(1502892996);
            result.ShareNum.ShouldBe(738361616);
            result.ShareValue.ShouldBe(442082504);
            result.Note.ShouldBe("e66b5a4689d04e318c2d71afaa39010bf92727c885ce4836bca26717ff34eb66dca9a59ded6b45919d9dd1badb7462bd67e7c104d5054364b18136946ffc5daee141460138e344f79880637b4119cfa75dcc5de13ace448eaa3b32ca11f7e76f84bfa0cb58004e3ebaf18fa5b3d1450f08245d06f90f43e790328bb4f7");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbInvestDetailUpdateDto()
            {
                ParentId = 879874091,
                DocDate = new DateTime(2008, 1, 3),
                DocNo = "55650666893a4bcb8c80e50066427b1781b5fff9fcb14cdf8d",
                InvestType = 1612828652,
                ShareNum = 964145889,
                ShareValue = 1923570795,
                Note = "c1003bb802a84949bee6a785b72e2933b39ef078e16b422288902d35fc4c8d2aa1120e7b483c4775ac2e02203aa439d0c1522be4072743b790b135fc8cd09b68161368134e1a41d8a46609736c064e99a5fc17d141124549ac4220feb50fc53a2c8755120d4f43d3886b94a93c7b11f20a7cc618189d40fabe6b38ee8a",
                IsActive = true
            };

            // Act
            var serviceResult = await _tbInvestDetailsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbInvestDetailRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ParentId.ShouldBe(879874091);
            result.DocDate.ShouldBe(new DateTime(2008, 1, 3));
            result.DocNo.ShouldBe("55650666893a4bcb8c80e50066427b1781b5fff9fcb14cdf8d");
            result.InvestType.ShouldBe(1612828652);
            result.ShareNum.ShouldBe(964145889);
            result.ShareValue.ShouldBe(1923570795);
            result.Note.ShouldBe("c1003bb802a84949bee6a785b72e2933b39ef078e16b422288902d35fc4c8d2aa1120e7b483c4775ac2e02203aa439d0c1522be4072743b790b135fc8cd09b68161368134e1a41d8a46609736c064e99a5fc17d141124549ac4220feb50fc53a2c8755120d4f43d3886b94a93c7b11f20a7cc618189d40fabe6b38ee8a");
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbInvestDetailsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbInvestDetailRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}