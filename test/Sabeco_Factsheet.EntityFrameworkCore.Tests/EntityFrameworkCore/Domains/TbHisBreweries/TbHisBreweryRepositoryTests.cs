using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbHisBreweries;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbHisBreweries
{
    public class TbHisBreweryRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbHisBreweryRepository _tbHisBreweryRepository;

        public TbHisBreweryRepositoryTests()
        {
            _tbHisBreweryRepository = GetRequiredService<ITbHisBreweryRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbHisBreweryRepository.GetListAsync(
                    isSendMail: true,
                    breweryName: "fd122b1f3cfe4eaa8656ee2a8f9ad6454383a4ef6aac4a06948ee4dba209d7a966561f49711d43899d5f3b4c9ebf71e60296691449a74f97a086571148ff5ab9f62026f94c74495fa5b57d414e1c380e5df0fd1b1b39415a9be7e5bcc879f9d24d9f2a10649c4380afbd6acbeee1e13f29a7baa7013e46e6a1c514f3fa",
                    breweryName_EN: "0f45ae8a52414081bd304d8b1a4220e9db013c967b5744b3b2f71e26e4a93ffa7468526675d74e0c93653aa3a574c83a9abaadc4b32a4aa6bec614e2e654fcefbb741ce8281b4a78bf4be8be322acd31c41ce86770a746608c6ee131f7f28d59f8857948667b49bea622a324cc75b7a420204f4fe2ca43478c45c114e8",
                    breweryAdress: "b572ad49001a41598493610020a715aec9ea42739c8448a5abbf30f55808bb60fb98e1ec628f4713",
                    briefName: "1cde3d074a0d4722bab9120ccf36f",
                    note: "edb082b1169e4c6e83",
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
                var result = await _tbHisBreweryRepository.GetCountAsync(
                    isSendMail: true,
                    breweryName: "0e2e84e8de0f4f13a27c5e1887ddb8f85b5498348b16440e8528209086e7dd79cbbf150b319f4a67b25fada304aba5bf753c2f90e14a47d09e7dc591adcc9453e49e092a255d4393aa2c125034a64ff1430dff5fdb004439976759d8c9c96a79b9628efd21eb452eac12c4ea30c05601b7affb625ad949dc918da50017",
                    breweryName_EN: "021ceafa5a5444b981b23ab7430d2a9b0409b326cea04ee8bf773195555b5736ba424889aa034bd78d46758aa7dfd2d517fc93e5b4824ef0bfd4df7f9987a58ac279b4f7a83941cbb70a933c45fcd220a4887991078142d5990a20b8cef79b7ff37c926dbd0c4b30bb92f2b9e356a86e5cde507c789943bc8a24836512",
                    breweryAdress: "5a3679a6410e4fb8b192a43d6789e288fd2c3f2c5a484c819bbddd50888696b3c1e72c06892c4282",
                    briefName: "034036503f7347c3b08b6afbe135550f1b87166c2ea143a9a389a3a833926232596c8d553",
                    note: "28094b30af6a4c038ecd98f3a380c15c88ec838ea8da420da3cbb6ef31027a4eda3bed1eabcb4c",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}