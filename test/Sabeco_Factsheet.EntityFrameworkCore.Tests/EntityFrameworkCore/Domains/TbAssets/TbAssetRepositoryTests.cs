using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbAssets;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbAssets
{
    public class TbAssetRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbAssetRepository _tbAssetRepository;

        public TbAssetRepositoryTests()
        {
            _tbAssetRepository = GetRequiredService<ITbAssetRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbAssetRepository.GetListAsync(
                    assetType: "20c3b260db3f44cdb6fb5c9d7699f5f40efd438d201547cdb8abe2233ee7bc7cdbd3c5b1eb454a0cadb59627b3dcdbfaf4bc9e8ecbf6455cb60da6ed016a7f3edd2bb25dd7974e999113c2",
                    assetItem: "e88ab6bedb054eae8ab491046c6c1be1630324aecd844514bf8e015d7bb56a1fd4b337fcdc314caea5f8facf9807778f4ab420eaaf7841ebb7e0529e70e3ad80c42e0fd59e2c4e50b61743bbaff0114bad8b091848264155951d76b0ee68c968220648d4dbb0414590e4f89446b7500a78add5dc1a8a4c1ca7e70ed052",
                    assetAddress: "13d91ee2fe1d4466b8195224917e3ca1ae387b35c8e64d81966632ca19547a0f4c862eab78664df29cfd364f03af6620960c00df383841219cac52306e7c4b15122c82aba5234b159a06ccfa8c2f60bd8c1da3114b4442ea935a028aea1f5528f9f9e8523e994373a429c7e8474fadd7c9dce154e04c4a7c9d86acb259",
                    docNo: "3cbe67887ee941498678d74ccccc9615065c7f93f3134d19aa",
                    description: "3264ee426a564a5bb3a868b14b7a7be14472ae1d0ff241fdbd4d7b3d3190a96f39de465a45ec4efca910f9792a10e49d17d2f69092a84384a1807133b01c9066dff80d00cfc3487cb366e103a881311861b43251d65142359a7d83345b5d983b3d005bd47cf04ec8a624474b7173cd66f8ff503252b543b1ac0c2a67e3",
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
                var result = await _tbAssetRepository.GetCountAsync(
                    assetType: "7d5a21dd29a4475f8f5e0a1faf511cf86ca547e9043f462ea1a91c4957c1f3f2bf2902cdb38d4da6b16ab42fe1f9b2b8ff42d3f35b904bfbad2946a9f9b69d482ce12a890525456c8d93e6",
                    assetItem: "6abdadd1970143d4a8b8a06ac76d56961c47f443a8c84ffb8faf19a56a60b382039bc15142d344ce9e69370314cc00691ba03092d1874663a509cf72521ad7b9457fd0135f4e4638947abc77720c2823d19ffafea9ef44a18cff9a85e4ec79b594b81d2143ab4e1395521af19f19435487ff39df72854205aac6f4d369",
                    assetAddress: "e66be987f20546c4ac086df1473aec8215813bc855574057b4dcf19871b3c5d2f6c7597b98b64dad8eb6034401054418cf6ae3de800241f9a2999a8476cc7b4f3da63cb1d78048d98adff3bb56f6cfdbc9ed31e957164127b1acc9995e9d1e8feb4e8b089d3e4e1bb4b931dd4de64209db7b0a3759b043e991400f2d00",
                    docNo: "de5a5f4b825c4b9c8a0a65259ea3586af974781806be4a19bb",
                    description: "75fb41f391fd41b38df3b8f05bdc74b7af88f91814a441cf8e977b10ca5f72a3ea12b3e354b042dbbc326cf63c5bd662283aae14f2d94e18a9a0023b439c425d5bf6ab73750c4f38ba4aa75f3326cf531a3b730d0c304d89ad37e1188aebcbed25333b09b55c409498ba913ec25e2b14942fda78e16947d3b1f6bf382a",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}