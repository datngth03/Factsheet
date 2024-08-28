using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbContacts
{
    public abstract class TbContactsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbContactsAppService _tbContactsAppService;
        private readonly IRepository<TbContact, int> _tbContactRepository;

        public TbContactsAppServiceTests()
        {
            _tbContactsAppService = GetRequiredService<ITbContactsAppService>();
            _tbContactRepository = GetRequiredService<IRepository<TbContact, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbContactsAppService.GetListAsync(new GetTbContactsInput());

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
            var result = await _tbContactsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbContactCreateDto
            {
                companyid = 71171676,
                ContactName = "3e83b15f5f44453583bbd723dc362c35af77c7f05ce74c6b90ab3a448b05896ff4738b5b702a455e9b431a5f24a1d39862d3cc12a04440a2a3aec7c6bc9f8be8f149f020a7a041f4ba556e",
                ContactDept = "e892697207374fb48c02ebc91a8ebbcf9c9635019f134aad8a3e7c953b75dc25ee78c75c118649a49b9f0907e3bb81d5bf49b8dfc0454b099079c8d59ead43a5cfbd43821e014f6691282a",
                ContactPosition = "c11d23b8d6054ace92b6543be942611ae68c9ae798e44eefa4e50c090a6ed9590f78bc21d9a244279e1cd2848a85bc213f391b934d2446398cfd8c3543051057154887e41091400dac8138",
                ContactEmail = "230bc52371984e2a9ff0ccb41405388b068c8928cf834254baef04a90e5d6a1bbe07af54d1804bd1aedd1c38312474862bcbd6d0ef8d4df0b169161251ce64bd552fe3da5a924b3188433f",
                ContactPhone = "f8261ae2ecf94912894d12ba610d7f14f6b89332583e42c586",
                Note = "a5abf2596eb84fb0ad6cdf86f53cce30ae6792a711b64aab95fbeda976996ee98d89bf0c158947d2aa39c196e9d05d339596bb7303a44c648eaf6e9bef9fddc669b14c65f4df4427bae09afb6c9d03253053754cdc08423c995268fc63f5643e3b15bfc85420485dad0d988d91892f05bcdfef91b5924de48215f02158",
                DocStatus = 7,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbContactsAppService.CreateAsync(input);

            // Assert
            var result = await _tbContactRepository.FindAsync(c => c.companyid == serviceResult.companyid);

            result.ShouldNotBe(null);
            result.companyid.ShouldBe(71171676);
            result.ContactName.ShouldBe("3e83b15f5f44453583bbd723dc362c35af77c7f05ce74c6b90ab3a448b05896ff4738b5b702a455e9b431a5f24a1d39862d3cc12a04440a2a3aec7c6bc9f8be8f149f020a7a041f4ba556e");
            result.ContactDept.ShouldBe("e892697207374fb48c02ebc91a8ebbcf9c9635019f134aad8a3e7c953b75dc25ee78c75c118649a49b9f0907e3bb81d5bf49b8dfc0454b099079c8d59ead43a5cfbd43821e014f6691282a");
            result.ContactPosition.ShouldBe("c11d23b8d6054ace92b6543be942611ae68c9ae798e44eefa4e50c090a6ed9590f78bc21d9a244279e1cd2848a85bc213f391b934d2446398cfd8c3543051057154887e41091400dac8138");
            result.ContactEmail.ShouldBe("230bc52371984e2a9ff0ccb41405388b068c8928cf834254baef04a90e5d6a1bbe07af54d1804bd1aedd1c38312474862bcbd6d0ef8d4df0b169161251ce64bd552fe3da5a924b3188433f");
            result.ContactPhone.ShouldBe("f8261ae2ecf94912894d12ba610d7f14f6b89332583e42c586");
            result.Note.ShouldBe("a5abf2596eb84fb0ad6cdf86f53cce30ae6792a711b64aab95fbeda976996ee98d89bf0c158947d2aa39c196e9d05d339596bb7303a44c648eaf6e9bef9fddc669b14c65f4df4427bae09afb6c9d03253053754cdc08423c995268fc63f5643e3b15bfc85420485dad0d988d91892f05bcdfef91b5924de48215f02158");
            result.DocStatus.ShouldBe((byte?)7);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbContactUpdateDto()
            {
                companyid = 1248443940,
                ContactName = "866815fad35c4731981e223632781d67b52ea4d6f64543c09bf1a5b21538bf71a5ed0d6ec0844d4d8a9234ddad95349cc48ca9a904c64810b328cf00c5508dee8ba22bcbc76c4956886d79",
                ContactDept = "16d2c8510b8e45c2a0805bd76d68e449277fad6fe9e0493286f45af676df24aeaeb4358faed542e0a0384956c2acc12d94838c4eb7ea416ebdc3aca42d2b24c1cf07488664224fcc9b8935",
                ContactPosition = "ac8bea97a6d04d7dbeeea067a93b003da7c791792b954c49bf9497961d95feb1aaf182cbb01f42cdacd7375caaaabd3dc72321694ea246da8ef3c475d1e3e3e50de78ad618394380a628d7",
                ContactEmail = "bb5af9b7e24a47e382de291217b855abfb9b15e69c354612ba14c1f638d14f06656f23db18cf4c1ca6e5b83a92716d5c8f6797e563f74132b9d8327f1d944401d2ebd8e30914445a9c1e33",
                ContactPhone = "da818a7c0684434984460f0ab51e00397479bf16e91d4d0bbf",
                Note = "37927294de214ffa871efb615574ab7056114085189f46c6b5e20ee364dbccad393b119b61fb4958b47f32243a1170638585f35b12584eed9f893a31266e11085d1cdc92ab5c47f2b81acdf30fc5cde534973120e36b438186191a28d51c149043a54b0704154381bbe9d346c12600bf523b069bfb7449f89f6315daac",
                DocStatus = 13,
                IsActive = true
            };

            // Act
            var serviceResult = await _tbContactsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbContactRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.companyid.ShouldBe(1248443940);
            result.ContactName.ShouldBe("866815fad35c4731981e223632781d67b52ea4d6f64543c09bf1a5b21538bf71a5ed0d6ec0844d4d8a9234ddad95349cc48ca9a904c64810b328cf00c5508dee8ba22bcbc76c4956886d79");
            result.ContactDept.ShouldBe("16d2c8510b8e45c2a0805bd76d68e449277fad6fe9e0493286f45af676df24aeaeb4358faed542e0a0384956c2acc12d94838c4eb7ea416ebdc3aca42d2b24c1cf07488664224fcc9b8935");
            result.ContactPosition.ShouldBe("ac8bea97a6d04d7dbeeea067a93b003da7c791792b954c49bf9497961d95feb1aaf182cbb01f42cdacd7375caaaabd3dc72321694ea246da8ef3c475d1e3e3e50de78ad618394380a628d7");
            result.ContactEmail.ShouldBe("bb5af9b7e24a47e382de291217b855abfb9b15e69c354612ba14c1f638d14f06656f23db18cf4c1ca6e5b83a92716d5c8f6797e563f74132b9d8327f1d944401d2ebd8e30914445a9c1e33");
            result.ContactPhone.ShouldBe("da818a7c0684434984460f0ab51e00397479bf16e91d4d0bbf");
            result.Note.ShouldBe("37927294de214ffa871efb615574ab7056114085189f46c6b5e20ee364dbccad393b119b61fb4958b47f32243a1170638585f35b12584eed9f893a31266e11085d1cdc92ab5c47f2b81acdf30fc5cde534973120e36b438186191a28d51c149043a54b0704154381bbe9d346c12600bf523b069bfb7449f89f6315daac");
            result.DocStatus.ShouldBe((byte?)13);
            result.IsActive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbContactsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbContactRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}