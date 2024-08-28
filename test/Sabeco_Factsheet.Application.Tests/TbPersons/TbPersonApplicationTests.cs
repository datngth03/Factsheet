using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbPersons
{
    public abstract class TbPersonsAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbPersonsAppService _tbPersonsAppService;
        private readonly IRepository<TbPerson, int> _tbPersonRepository;

        public TbPersonsAppServiceTests()
        {
            _tbPersonsAppService = GetRequiredService<ITbPersonsAppService>();
            _tbPersonRepository = GetRequiredService<IRepository<TbPerson, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbPersonsAppService.GetListAsync(new GetTbPersonsInput());

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
            var result = await _tbPersonsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbPersonCreateDto
            {
                Code = "80448e25b5484dfd9bfd",
                CompanyId = 2118617577,
                FullName = "8457b17366c54e5fb6853ef480e713e8b6913d6505c34790a2a8364125bc5a947d6b4d4c501a468d874bfc94ac6fea8e6a622c3f0e2a432f8a47b129a32506de94f24fb843a94714ab6bbd",
                BirthDate = new DateTime(2012, 11, 24),
                BirthPlace = "ca2e3bf0d16e40eaa8dd721fa1e455f017e31dfdef0a4161b603060bb3052dbe1a5636102bc34d618b85e5e02a9bc70bc2c790a9411d43d586c370198cc36182a11c755d821a42de8e7806",
                Address = "a8acb7c78ad64662af3be7703587fa15250636924b8f42a985688e1cfc74beacbe55eee9d1f842cdb9ca69f9ad26baee97891b58778e48b995c39bc0b036fa008a06e43b367d492da87cf5",
                IDCardNo = "761b98e78e9642af8cf3",
                IDCardDate = new DateTime(2007, 1, 3),
                IdCardIssuePlace = "f33a94b15199499bad5107b667381a00e670e2fd46ce4151a745d3bca35af6f5d697e1bddcf74e21b00a019bdb7d1f5b47576fd006cd4c73aba1de8a7d458c46d5ff8f1efe994d928f0b59",
                Ethnicity = "6c9ee270cd454fd7840c1b80373568a3dcc9d5b759b540ebbb9b2934453d9a5440733f8157d141ffbec0a802cdc6cd3d2272b952961b475e91513119716c3d187804723214fa45499e5edf",
                Religion = "338e0b7d05bb44608adb7201a8114ade5478265cc15b4064915ad0cf9f85a5db450105a04f744855b7d5a546f293f92f137d82c36a7a430fac5d847718324dd73bc0a325cef24c5fb17619",
                NationalityCode = "c97",
                Gender = "8e9",
                Phone = "3ca13d1f38744ae6bbf600e2b63e7e2e85b4d22e912e49db91",
                Email = "7856f835fc9443c59a66656b10148351f4771aa250314c9f9593eb1c8b04e52390a4df607641413ab50e775660efd51157276ce4b6bc45aa91468de1d77ed18e7fbc1fbd68ee4898923b61",
                Note = "308be6e8ff634cd186685021e2813ccb6195a0b3ff6f4bcd99be13a060cd9adbca5befd13bfd410eb5c8b3c2fb7460626036afa776b7489f91d2859dbb1dab6da32a220dc3254d79a03e68698436ccd9a4147b61b3ba4ab599c16ed02052e66dd6ddb8c569fe4eb3ba5e95646b9180bb2f383093002d47c8b7f7b7c44a",
                Image = "3e647a3aa37743d19297d51c8bcb3adb09831317ff4c42bb973d9c8a503015756fa127b1b0a041f497a68c6222c410de",
                IsActive = true,
                DocStatus = 16,
                IsCheckRetirement = true,
                IsCheckTermEnd = true,
                OldCode = "ef22dfd0a14046e6a739"
            };

            // Act
            var serviceResult = await _tbPersonsAppService.CreateAsync(input);

            // Assert
            var result = await _tbPersonRepository.FindAsync(c => c.Code == serviceResult.Code);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("80448e25b5484dfd9bfd");
            result.CompanyId.ShouldBe(2118617577);
            result.FullName.ShouldBe("8457b17366c54e5fb6853ef480e713e8b6913d6505c34790a2a8364125bc5a947d6b4d4c501a468d874bfc94ac6fea8e6a622c3f0e2a432f8a47b129a32506de94f24fb843a94714ab6bbd");
            result.BirthDate.ShouldBe(new DateTime(2012, 11, 24));
            result.BirthPlace.ShouldBe("ca2e3bf0d16e40eaa8dd721fa1e455f017e31dfdef0a4161b603060bb3052dbe1a5636102bc34d618b85e5e02a9bc70bc2c790a9411d43d586c370198cc36182a11c755d821a42de8e7806");
            result.Address.ShouldBe("a8acb7c78ad64662af3be7703587fa15250636924b8f42a985688e1cfc74beacbe55eee9d1f842cdb9ca69f9ad26baee97891b58778e48b995c39bc0b036fa008a06e43b367d492da87cf5");
            result.IDCardNo.ShouldBe("761b98e78e9642af8cf3");
            result.IDCardDate.ShouldBe(new DateTime(2007, 1, 3));
            result.IdCardIssuePlace.ShouldBe("f33a94b15199499bad5107b667381a00e670e2fd46ce4151a745d3bca35af6f5d697e1bddcf74e21b00a019bdb7d1f5b47576fd006cd4c73aba1de8a7d458c46d5ff8f1efe994d928f0b59");
            result.Ethnicity.ShouldBe("6c9ee270cd454fd7840c1b80373568a3dcc9d5b759b540ebbb9b2934453d9a5440733f8157d141ffbec0a802cdc6cd3d2272b952961b475e91513119716c3d187804723214fa45499e5edf");
            result.Religion.ShouldBe("338e0b7d05bb44608adb7201a8114ade5478265cc15b4064915ad0cf9f85a5db450105a04f744855b7d5a546f293f92f137d82c36a7a430fac5d847718324dd73bc0a325cef24c5fb17619");
            result.NationalityCode.ShouldBe("c97");
            result.Gender.ShouldBe("8e9");
            result.Phone.ShouldBe("3ca13d1f38744ae6bbf600e2b63e7e2e85b4d22e912e49db91");
            result.Email.ShouldBe("7856f835fc9443c59a66656b10148351f4771aa250314c9f9593eb1c8b04e52390a4df607641413ab50e775660efd51157276ce4b6bc45aa91468de1d77ed18e7fbc1fbd68ee4898923b61");
            result.Note.ShouldBe("308be6e8ff634cd186685021e2813ccb6195a0b3ff6f4bcd99be13a060cd9adbca5befd13bfd410eb5c8b3c2fb7460626036afa776b7489f91d2859dbb1dab6da32a220dc3254d79a03e68698436ccd9a4147b61b3ba4ab599c16ed02052e66dd6ddb8c569fe4eb3ba5e95646b9180bb2f383093002d47c8b7f7b7c44a");
            result.Image.ShouldBe("3e647a3aa37743d19297d51c8bcb3adb09831317ff4c42bb973d9c8a503015756fa127b1b0a041f497a68c6222c410de");
            result.IsActive.ShouldBe(true);
            result.DocStatus.ShouldBe((byte?)16);
            result.IsCheckRetirement.ShouldBe(true);
            result.IsCheckTermEnd.ShouldBe(true);
            result.OldCode.ShouldBe("ef22dfd0a14046e6a739");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbPersonUpdateDto()
            {
                Code = "cd5e3ffe78f345c59e24",
                CompanyId = 257820154,
                FullName = "89f42f97ffb246129847825820b6a1f41bdc5c125f2d48f386b6295711cfb3135180b26d765c417b8bf8071bb40be0be6609ec1bee36439785e7719c215a919d24eabbe7d4174b0b84c1bd",
                BirthDate = new DateTime(2016, 4, 9),
                BirthPlace = "dd872271bce0481dad494a1dd4441b07e4656ea62e914f30983e4b8e2eefcb5789d95a4d69d84794b0ddbacbf9d9dbbc32b5b05e48c74ef68f91c8828708d102682de76d44864e35b2ddf3",
                Address = "1529aacafbd8426eb624a5852f59eef4623e8b55527c4b9b8154322087b4562df1fa3ec4edc94e95bdb96e0ac2266402c5059933ef7d4011a97db8211eeeb66d4db4bdd0ecc647178cd6af",
                IDCardNo = "2149a954d808460b9292",
                IDCardDate = new DateTime(2013, 10, 6),
                IdCardIssuePlace = "ee225e90cd1d41f99d61168678366cc6c2c28251f8e54af8b65850cce3b82ea2649fa50f133c4037be2709d4a1a480636198c1724a024dbd871c832ff973a61122417df25eb44b24840326",
                Ethnicity = "f9b6aa2d07c44b6cb170726ef884b433c2c20745381544b59f0b945d38654535ee39c462370940beb5e68cd4a3cb735970a22d23251b4abd93f8459655348b5673e9b7ebf45e456fb11c27",
                Religion = "52f2af7e5cce4acbbc8e7cf7530cf07bd73314e723e14686ab3b10cb2a59a498cf5f14d011e8488e921db1724fe7bc6ed045bb0da2d44b639f093129266b2cda7ecfb2b28f2b45cabffcc2",
                NationalityCode = "d39",
                Gender = "a38",
                Phone = "2128399802064234a0c47cd6ab31df1184f00baf42a847ac8e",
                Email = "eba3881795ee425b8ccb0582692c12e267ff55c2e9b44a8285103d0cdef0c05adeefda661ebd4557bbc8998b939c5defa424ac36f3e54ae9bc542480530ecc2ea701de87dbdc48cbbc42c8",
                Note = "1115e0c66c6a47df94b18c89de918d9865cbf6f2c8b848d8a507f57d47b3dbc71486aaae84554b0b961d6a43133c6509d77d1e9b6d8943898fa1bb38d5227f4e4d64d9531d2f4fcf8286673394ef0ee77d3871e6252a4ab5a98aa1e98233988c559da178980b401ab02642da8cca0ce5eeb5c326ea0d4f0f90717e5a16",
                Image = "ef60c456a627482eaa587e32e370843a2086de33ada340fca0219f130a08620845b6ff1a00b44e16ad9a6420db04e50a533",
                IsActive = true,
                DocStatus = 25,
                IsCheckRetirement = true,
                IsCheckTermEnd = true,
                OldCode = "4bb90a105ce7430b9169"
            };

            // Act
            var serviceResult = await _tbPersonsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbPersonRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Code.ShouldBe("cd5e3ffe78f345c59e24");
            result.CompanyId.ShouldBe(257820154);
            result.FullName.ShouldBe("89f42f97ffb246129847825820b6a1f41bdc5c125f2d48f386b6295711cfb3135180b26d765c417b8bf8071bb40be0be6609ec1bee36439785e7719c215a919d24eabbe7d4174b0b84c1bd");
            result.BirthDate.ShouldBe(new DateTime(2016, 4, 9));
            result.BirthPlace.ShouldBe("dd872271bce0481dad494a1dd4441b07e4656ea62e914f30983e4b8e2eefcb5789d95a4d69d84794b0ddbacbf9d9dbbc32b5b05e48c74ef68f91c8828708d102682de76d44864e35b2ddf3");
            result.Address.ShouldBe("1529aacafbd8426eb624a5852f59eef4623e8b55527c4b9b8154322087b4562df1fa3ec4edc94e95bdb96e0ac2266402c5059933ef7d4011a97db8211eeeb66d4db4bdd0ecc647178cd6af");
            result.IDCardNo.ShouldBe("2149a954d808460b9292");
            result.IDCardDate.ShouldBe(new DateTime(2013, 10, 6));
            result.IdCardIssuePlace.ShouldBe("ee225e90cd1d41f99d61168678366cc6c2c28251f8e54af8b65850cce3b82ea2649fa50f133c4037be2709d4a1a480636198c1724a024dbd871c832ff973a61122417df25eb44b24840326");
            result.Ethnicity.ShouldBe("f9b6aa2d07c44b6cb170726ef884b433c2c20745381544b59f0b945d38654535ee39c462370940beb5e68cd4a3cb735970a22d23251b4abd93f8459655348b5673e9b7ebf45e456fb11c27");
            result.Religion.ShouldBe("52f2af7e5cce4acbbc8e7cf7530cf07bd73314e723e14686ab3b10cb2a59a498cf5f14d011e8488e921db1724fe7bc6ed045bb0da2d44b639f093129266b2cda7ecfb2b28f2b45cabffcc2");
            result.NationalityCode.ShouldBe("d39");
            result.Gender.ShouldBe("a38");
            result.Phone.ShouldBe("2128399802064234a0c47cd6ab31df1184f00baf42a847ac8e");
            result.Email.ShouldBe("eba3881795ee425b8ccb0582692c12e267ff55c2e9b44a8285103d0cdef0c05adeefda661ebd4557bbc8998b939c5defa424ac36f3e54ae9bc542480530ecc2ea701de87dbdc48cbbc42c8");
            result.Note.ShouldBe("1115e0c66c6a47df94b18c89de918d9865cbf6f2c8b848d8a507f57d47b3dbc71486aaae84554b0b961d6a43133c6509d77d1e9b6d8943898fa1bb38d5227f4e4d64d9531d2f4fcf8286673394ef0ee77d3871e6252a4ab5a98aa1e98233988c559da178980b401ab02642da8cca0ce5eeb5c326ea0d4f0f90717e5a16");
            result.Image.ShouldBe("ef60c456a627482eaa587e32e370843a2086de33ada340fca0219f130a08620845b6ff1a00b44e16ad9a6420db04e50a533");
            result.IsActive.ShouldBe(true);
            result.DocStatus.ShouldBe((byte?)25);
            result.IsCheckRetirement.ShouldBe(true);
            result.IsCheckTermEnd.ShouldBe(true);
            result.OldCode.ShouldBe("4bb90a105ce7430b9169");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbPersonsAppService.DeleteAsync(1);

            // Assert
            var result = await _tbPersonRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}