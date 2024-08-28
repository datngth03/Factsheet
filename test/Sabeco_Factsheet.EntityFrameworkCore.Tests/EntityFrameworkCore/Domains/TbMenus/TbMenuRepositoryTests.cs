using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Sabeco_Factsheet.TbMenus;
using Sabeco_Factsheet.EntityFrameworkCore;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains.TbMenus
{
    public class TbMenuRepositoryTests : Sabeco_FactsheetEntityFrameworkCoreTestBase
    {
        private readonly ITbMenuRepository _tbMenuRepository;

        public TbMenuRepositoryTests()
        {
            _tbMenuRepository = GetRequiredService<ITbMenuRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tbMenuRepository.GetListAsync(
                    controlName: "cfa236f7ab48401ca91550cd8c921d808fd4efa8631a414a87973918fa209002c3039f2a8ece46a6bccb8071b3e3f05a7dd15cb65338425f858797b114be5152e7a2b34a0fbb4b0b8f90a58385f5e890be2ca1bdd3ee486794b6df7eab7d07ba1873445852d64ec5a1ab5c498f67fdd283d4982b53ac4a6487bc917ea1f8a67652b0615a18c74ca1b62beb5d6c2e47542d07c079f7ab4849ad57ca32c77917ce86c3db8226dd4465aef787a14d0416ef0f1fe6d1bf3e43acb71e5883dda9ddb3317e10fdf52e41b3a50fc89cae81591ced4861e462c047199fc0cc4591ccd23006aa0b23834d4415bf3eb7d111709bd6c719426bd4824d9da587",
                    description: "d78985a09aba4f2181371bbefb061ea1a363d710f91b42fca5bb397aea1d9721928b54c0bfc540c4b3b40fd4af76e6bfd8728a59c2604ce4a1b71a033250f76615a6a63cbe8e4a8a942b96f5b538827c23556de873044f6b95ab06c9022c7da0729be59c46f0484cbb76c992aead161319b9d5ed20194d2c976ec9ce41c45a56f8aa17fa47da493bbf92035a8b6a69dbcd7e66db8edf408ab7f6b4ec8ef59c33093637113e8e478f9c914cf473733df0e16b468d123e41bbb74b47dd19dd11ae1ea4efbcdea94003a3543750623f0b17864405f01dd04f1782a2c966e8c5bdcbef7f8efab8ff4c408262adcf6715942475d83383090c442f9b3d",
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
                var result = await _tbMenuRepository.GetCountAsync(
                    controlName: "826b4b92ddb1496a865b865346c39c9e36ba789f7fac4fd4910d9a20667a5c70c1817076c9404953af57f0d783f630b7150c3fc27c2645f0ab4a27a0e3ef38387801edf1697346f2bb4111588697628d088de7968b974dca83f25fbc65886ebc516a5f09f3c8406db39c628abdb77bdbea4c1ee36159473a970db4318eacb3786fb41c6263d74dea96335063023e5c93892e71389721429db22d668dabb754942bad52e7bdd54852b4d8be4fd46945b9fac939106b4342f8af50165c311ba38359169cdd274a4f7f9b80ea761633ac51872820c06a2b431996dcbaed48f42e809ed3227fe5104e56949f7b826d54f1ee4ea6209f3f4a45909f89",
                    description: "ce82309907de470faaf5cdb7429e9e34fb8682cfeafb43d59ee6cf31ee1bc0cf96a758767a4647869e88d47071fe004ec749deec0fea43688a2046767bde3c5cdf44fb150b884940a0ac3c63a7818f34c880c12ec1d44a9a87134c3a68da6899bba49f000042479b905c4ffa29482c251f6d3d4dfa544991b45bea7405948fd3329060db1a69420686879ac1863993668ba9abcbe4a9477fb0da44c7ace1dd5d89d7939316a84a89b1b1b2842f1ac0e9212649df293f45798025a65d5ba2e67fcc1b31571eae46ef9dca2eb8a9317d7360f5657ddc0443edb71fd58f1cb0dd0df452a9e0110849438682ef5a7b4006b6531a431be27e40709dbc",
                    isActive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}