using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Sabeco_Factsheet.TbCompanies
{
    public abstract class TbCompaniesAppServiceTests<TStartupModule> : Sabeco_FactsheetApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ITbCompaniesAppService _tbCompaniesAppService;
        private readonly IRepository<TbCompany, int> _tbCompanyRepository;

        public TbCompaniesAppServiceTests()
        {
            _tbCompaniesAppService = GetRequiredService<ITbCompaniesAppService>();
            _tbCompanyRepository = GetRequiredService<IRepository<TbCompany, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tbCompaniesAppService.GetListAsync(new GetTbCompaniesInput());

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
            var result = await _tbCompaniesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TbCompanyCreateDto
            {
                ParentId = 1666458293,
                IsGroup = true,
                Code = "b7d464e2c8444619a50f",
                Name = "e32ce39299074935a5c07f374fb01a0b0d40b31b02844faead5e705086b65cded5e13cc5485544529d8584a15935e7420a98a648f64e47db8b4ec68202d7b588b074ccb60c58418fa04bb7b9f131013d553bd47121e5435bb59fe3ec2defe657c507d0506df84feaab45a8d23624238c10deca0ce36d48ee90f783b4fc",
                Name_EN = "bb3173e3f1064699b548aa5b23037c42b1c125199c2c413c91965217f4dd4a98b57fe4aa021149f997f012156020a8205d3b06ddd8fe47c39dbdcf3ece415c73839e56e88e51480783403378b0c2e2e91118a083ec6544a3b939e0b2cb44b527f7535bd81d054e4c97fac0860c1c5ef5de371b55f376479384709a1c82",
                BriefName = "dc54a78d913f4d7283b05a9836b54ca93829d79baba24d4899820a86c6e3df6eb62126ce885948ff8da885066bf13c04894e",
                ContactInfo_01 = "72a18d210ccf4bd69ee883f2b44b4dfdd89db57f12cd49ebabc4f80667da253d3428c03ef3034fca94f627a2ead799220f4f00a30dda421dab462b85837499863835376f799d45a997b6a51d3ecdd286b8e298238d4941a1a4be592f77bcec67fdca414b379a4d37a6b3d7400438a62a7b551f4d10cb4cda94a6627e5b",
                ContactInfo_02 = "2add8cb6ed7441838b2bf2992aafab2e1fd0123bd4304dfd9f",
                ContactInfo_03 = "f5cb3921e1774f878f7b1f95eb47eb4bff49e0d45f7f45a3a4",
                ContactInfo_04 = "c9cdd10e24924c54a9f444655941ab7544840f25c2124289a5e43d666b3104d5097742e6248046a1a517f8353d0eec4951bd572276e04253ab7fd518527319d12a85fa7738164956954dd6",
                ContactInfo_05 = "f6b6fbcea68843bcbbad408dd5aeb406d34f0b9a20d74da1905028a95abbdc0b18b385f6f0e14efb878e6b7393800cbae03488ec557248e69411f0a3b059310a30dcfa1d46744f11a83f89f681d759f2918c97fe211b4f15bc4cc7f181a4972326204e1e7cfb427e9979037ed33097c2bd122cfd568143e0bfca200fbb",
                ContactInfo_06 = "fc2f0ea7ce53444",
                StockCode = "453ef",
                StockExchange = "54f04fa14e",
                StockRegistrationDate = new DateTime(2020, 7, 16),
                IsPublicCompany = true,
                LicenseNo = "e2ddd762bb784ad088b5",
                License = "ce146a7ca6064f178ff5",
                RegistrationOrder = 64,
                RegistrationDate0 = new DateTime(2014, 7, 11),
                RegistrationDate = new DateTime(2020, 3, 21),
                LatestAmendment = new DateTime(2012, 4, 26),
                LegalRepresent = "eada6fe608a44ab8b67470796ec7cbbe7d5d9b94b9f440a184a007c10102e0903023212cd9ac459b8447e92b9b463724aa1dfc4e95794e9b9748f8bcf2255b1d08bd66255ebb43f082c396a4c79d3a2e047afe88adc6490fa000ef6fa8a49d1f53feb5eeafdc45298524bb50123463562951ffa01f37484dbb30b01330",
                CompanyType = "cbff1",
                CharteredCapital = 834591972,
                TotalShare = 589815482,
                ListedShare = 1923692821,
                ParValue = 1767121717,
                ContactName1 = "3571d842a5b042b788037521737a00c7a115b5a21d864d9fb21ae3001264b0dacff60cc8d62345d7a2c428e716bc526b027b9471387d49fdb8d85da15301b78eec6f7120575e4283903b0f",
                ContactDept1 = "bf3821d3ff7e4fbeb055cbf4ae723c4d5d5e24dec69f437086c80fe39fab2a68ce7ac15464f4420ab07b12bb1fa46623270a49f5c305464ebe2e9d8d1e3296f3f64030be57a64d0281f350",
                ContactMail1 = "1cc4d3cac83c4904b22ac2534094211904191ac24a7c4468a5fe56a0e972b6136827960a2bc54f58aa1901f5278148dd4357d9f688ff48da836b4f0d857bdb614f2b130322284800abdf61",
                ContactPosition1 = "907ac80cc57e444aaa55eed0c9ff11220478e7ed0b594668b94fdf06ce1af4fc38ae7b34d1e9466fabd19c698f91d9e55e50ef4dc3f84ab897a24bc648178d27ddb6c2480fe6496cb1daaa9d786b613017a9c441d413423ebe8a5b258ebfbcbf2822d2c284494f8d98eb2e8d5126e8cbb1b4ce9e019f46a5a5429287d0",
                ContactPhone1 = "af49f5b3c72a449b93ad99455bd158f2eaa43e7d8e574a03a4",
                ContactName2 = "35da75ba0616431fb64ee95e69f4cbc43c2f817badd546fdbba28d0773728a4c3a22c989318c4e9f8b81e0c1ca867343d92d875af6b64cc59108d7915013f59e9d0ed825792645c3b9c3c2",
                ContactDept2 = "583d69ddd44a4474a86d1fd56a0a1f5bfc0c8cc28ed0434ebb5b2dfdd9dc625d408975326eaf4f43a1ced6466a6b38f80b7615cfbd404890bc25faf08482756174ba9984bfbf4804aacb60",
                ContactMail2 = "ecf73bc431f9423690eb775c2ca7e1bb9fea5741211948069cdf9724d61d5ac73c2561a0444c47b3835e51cd9839fb9b843641efbc6a4b52b5561e4560a53ff51a54ce4e22054c7e96437f",
                ContactPosition2 = "60b0d1cc56084cb0afbfff6988138a04c65fb1e69b1e4fa9ac2f5c7cc9c8a994bc20d81f26944371b2389f16e81ab39128cec98a58e044a69525fbb0311bcf902328512015df460da2c5c95938720453b5f6b819f02d4c2e8c7199de5761c4a9b29f9b61b8984a22a86b511711b86a6368073c6b06504521bcc22a081d",
                ContactPhone2 = "017ceaca17274f6c83b34cda2d17b1461689224fe21040b19d",
                longtitude = 237863807,
                latitude = 634869079,
                Note = "8849df53ce654203962e3ada42d9157c29fb585b732b49a49373c81ff78dd042e22f1d5a25174eb49788b9d237cf1e7509b6d11c91354be69ef91a3a9dd9198e1e9dd4db924342f0980952b4d2a2dd757166298a8af74ba3a2744c806e8670e64451fcabe57842b7b4f4920f6da97bd6d15c4453f1a649698e39338961",
                DocStatus = 18,
                DirectShareholding = 1425769629,
                ConsolidatedShareholding = 1224628511,
                ConsolidateNoted = "3ea5a8ef1aa847b5aba16e33",
                VotingRightDirect = 1260863104,
                VotingRightTotal = 2090721401,
                Image = "90eff566825548c792138f72a27cff93133f36eef0fc4cca86f70ab2da559f58cf211d1f2338485f99211b",
                IsActive = true,
                BravoCode = "7ce57",
                LegacyCode = "dd5c5347293047d6",
                idCompanyType = 1331353303
            };

            // Act
            var serviceResult = await _tbCompaniesAppService.CreateAsync(input);

            // Assert
            var result = await _tbCompanyRepository.FindAsync(c => c.ParentId == serviceResult.ParentId);

            result.ShouldNotBe(null);
            result.ParentId.ShouldBe(1666458293);
            result.IsGroup.ShouldBe(true);
            result.Code.ShouldBe("b7d464e2c8444619a50f");
            result.Name.ShouldBe("e32ce39299074935a5c07f374fb01a0b0d40b31b02844faead5e705086b65cded5e13cc5485544529d8584a15935e7420a98a648f64e47db8b4ec68202d7b588b074ccb60c58418fa04bb7b9f131013d553bd47121e5435bb59fe3ec2defe657c507d0506df84feaab45a8d23624238c10deca0ce36d48ee90f783b4fc");
            result.Name_EN.ShouldBe("bb3173e3f1064699b548aa5b23037c42b1c125199c2c413c91965217f4dd4a98b57fe4aa021149f997f012156020a8205d3b06ddd8fe47c39dbdcf3ece415c73839e56e88e51480783403378b0c2e2e91118a083ec6544a3b939e0b2cb44b527f7535bd81d054e4c97fac0860c1c5ef5de371b55f376479384709a1c82");
            result.BriefName.ShouldBe("dc54a78d913f4d7283b05a9836b54ca93829d79baba24d4899820a86c6e3df6eb62126ce885948ff8da885066bf13c04894e");
            result.ContactInfo_01.ShouldBe("72a18d210ccf4bd69ee883f2b44b4dfdd89db57f12cd49ebabc4f80667da253d3428c03ef3034fca94f627a2ead799220f4f00a30dda421dab462b85837499863835376f799d45a997b6a51d3ecdd286b8e298238d4941a1a4be592f77bcec67fdca414b379a4d37a6b3d7400438a62a7b551f4d10cb4cda94a6627e5b");
            result.ContactInfo_02.ShouldBe("2add8cb6ed7441838b2bf2992aafab2e1fd0123bd4304dfd9f");
            result.ContactInfo_03.ShouldBe("f5cb3921e1774f878f7b1f95eb47eb4bff49e0d45f7f45a3a4");
            result.ContactInfo_04.ShouldBe("c9cdd10e24924c54a9f444655941ab7544840f25c2124289a5e43d666b3104d5097742e6248046a1a517f8353d0eec4951bd572276e04253ab7fd518527319d12a85fa7738164956954dd6");
            result.ContactInfo_05.ShouldBe("f6b6fbcea68843bcbbad408dd5aeb406d34f0b9a20d74da1905028a95abbdc0b18b385f6f0e14efb878e6b7393800cbae03488ec557248e69411f0a3b059310a30dcfa1d46744f11a83f89f681d759f2918c97fe211b4f15bc4cc7f181a4972326204e1e7cfb427e9979037ed33097c2bd122cfd568143e0bfca200fbb");
            result.ContactInfo_06.ShouldBe("fc2f0ea7ce53444");
            result.StockCode.ShouldBe("453ef");
            result.StockExchange.ShouldBe("54f04fa14e");
            result.StockRegistrationDate.ShouldBe(new DateTime(2020, 7, 16));
            result.IsPublicCompany.ShouldBe(true);
            result.LicenseNo.ShouldBe("e2ddd762bb784ad088b5");
            result.License.ShouldBe("ce146a7ca6064f178ff5");
            result.RegistrationOrder.ShouldBe((byte?)64);
            result.RegistrationDate0.ShouldBe(new DateTime(2014, 7, 11));
            result.RegistrationDate.ShouldBe(new DateTime(2020, 3, 21));
            result.LatestAmendment.ShouldBe(new DateTime(2012, 4, 26));
            result.LegalRepresent.ShouldBe("eada6fe608a44ab8b67470796ec7cbbe7d5d9b94b9f440a184a007c10102e0903023212cd9ac459b8447e92b9b463724aa1dfc4e95794e9b9748f8bcf2255b1d08bd66255ebb43f082c396a4c79d3a2e047afe88adc6490fa000ef6fa8a49d1f53feb5eeafdc45298524bb50123463562951ffa01f37484dbb30b01330");
            result.CompanyType.ShouldBe("cbff1");
            result.CharteredCapital.ShouldBe(834591972);
            result.TotalShare.ShouldBe(589815482);
            result.ListedShare.ShouldBe(1923692821);
            result.ParValue.ShouldBe(1767121717);
            result.ContactName1.ShouldBe("3571d842a5b042b788037521737a00c7a115b5a21d864d9fb21ae3001264b0dacff60cc8d62345d7a2c428e716bc526b027b9471387d49fdb8d85da15301b78eec6f7120575e4283903b0f");
            result.ContactDept1.ShouldBe("bf3821d3ff7e4fbeb055cbf4ae723c4d5d5e24dec69f437086c80fe39fab2a68ce7ac15464f4420ab07b12bb1fa46623270a49f5c305464ebe2e9d8d1e3296f3f64030be57a64d0281f350");
            result.ContactMail1.ShouldBe("1cc4d3cac83c4904b22ac2534094211904191ac24a7c4468a5fe56a0e972b6136827960a2bc54f58aa1901f5278148dd4357d9f688ff48da836b4f0d857bdb614f2b130322284800abdf61");
            result.ContactPosition1.ShouldBe("907ac80cc57e444aaa55eed0c9ff11220478e7ed0b594668b94fdf06ce1af4fc38ae7b34d1e9466fabd19c698f91d9e55e50ef4dc3f84ab897a24bc648178d27ddb6c2480fe6496cb1daaa9d786b613017a9c441d413423ebe8a5b258ebfbcbf2822d2c284494f8d98eb2e8d5126e8cbb1b4ce9e019f46a5a5429287d0");
            result.ContactPhone1.ShouldBe("af49f5b3c72a449b93ad99455bd158f2eaa43e7d8e574a03a4");
            result.ContactName2.ShouldBe("35da75ba0616431fb64ee95e69f4cbc43c2f817badd546fdbba28d0773728a4c3a22c989318c4e9f8b81e0c1ca867343d92d875af6b64cc59108d7915013f59e9d0ed825792645c3b9c3c2");
            result.ContactDept2.ShouldBe("583d69ddd44a4474a86d1fd56a0a1f5bfc0c8cc28ed0434ebb5b2dfdd9dc625d408975326eaf4f43a1ced6466a6b38f80b7615cfbd404890bc25faf08482756174ba9984bfbf4804aacb60");
            result.ContactMail2.ShouldBe("ecf73bc431f9423690eb775c2ca7e1bb9fea5741211948069cdf9724d61d5ac73c2561a0444c47b3835e51cd9839fb9b843641efbc6a4b52b5561e4560a53ff51a54ce4e22054c7e96437f");
            result.ContactPosition2.ShouldBe("60b0d1cc56084cb0afbfff6988138a04c65fb1e69b1e4fa9ac2f5c7cc9c8a994bc20d81f26944371b2389f16e81ab39128cec98a58e044a69525fbb0311bcf902328512015df460da2c5c95938720453b5f6b819f02d4c2e8c7199de5761c4a9b29f9b61b8984a22a86b511711b86a6368073c6b06504521bcc22a081d");
            result.ContactPhone2.ShouldBe("017ceaca17274f6c83b34cda2d17b1461689224fe21040b19d");
            result.longtitude.ShouldBe(237863807);
            result.latitude.ShouldBe(634869079);
            result.Note.ShouldBe("8849df53ce654203962e3ada42d9157c29fb585b732b49a49373c81ff78dd042e22f1d5a25174eb49788b9d237cf1e7509b6d11c91354be69ef91a3a9dd9198e1e9dd4db924342f0980952b4d2a2dd757166298a8af74ba3a2744c806e8670e64451fcabe57842b7b4f4920f6da97bd6d15c4453f1a649698e39338961");
            result.DocStatus.ShouldBe((byte?)18);
            result.DirectShareholding.ShouldBe(1425769629);
            result.ConsolidatedShareholding.ShouldBe(1224628511);
            result.ConsolidateNoted.ShouldBe("3ea5a8ef1aa847b5aba16e33");
            result.VotingRightDirect.ShouldBe(1260863104);
            result.VotingRightTotal.ShouldBe(2090721401);
            result.Image.ShouldBe("90eff566825548c792138f72a27cff93133f36eef0fc4cca86f70ab2da559f58cf211d1f2338485f99211b");
            result.IsActive.ShouldBe(true);
            result.BravoCode.ShouldBe("7ce57");
            result.LegacyCode.ShouldBe("dd5c5347293047d6");
            result.idCompanyType.ShouldBe(1331353303);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TbCompanyUpdateDto()
            {
                ParentId = 1700388594,
                IsGroup = true,
                Code = "2338e493e31a4b0fa7b3",
                Name = "29784b3f6bbd4529be0469e3a543e71a2dc3762c8e804914a7d960b9687ac0738ba2c2e985014e719c37764a54f939b648a16090d6e6489a9c90f522c6b0ae72ca7fbffc6b2c4b998e5ab5524504ff373b121c56682b4678a08999175afe82ce090d8b5c3eb2454ea024471e7e69fe9a7ece947607fc43b79dfb54988a",
                Name_EN = "d6985e650ee6481ba2a64b0189720e2d17e83d0db7194b98a92f62725d2c54f582a40fc5028e4d3fba82adaee4eeb04d0115a83c4f644b2ea862a100ce40f629239e5c78083b4f29961ea92cfe15fde2b444ed5fd3544e2a817bdcbfea0d717448dfcf49723d496e9138c473ac94cc7063de5e2083464403bdb220acb2",
                BriefName = "1b023600123a4c098255d802afc463ef7c439d961bbe4e4697dc4d40085cd42d55ce00a760ca473e975212c140d5568179e3",
                ContactInfo_01 = "b9b280a107fe4126a7a5fc268e7b19fec0c0b6fdb6dc4de299e95483c28b9465c5bd0d7471ec4334bc77548940c517e05867825361f34a65bc5aecbfa26f4fdec3219faa30ad4a1c9948b434ab958599f86dfff4e487468b94007e2593efccb8ec68c06c960e4360b39ee8e69a169bd90b31f4f510ca42e5bd3f2fb1b9",
                ContactInfo_02 = "c17942a5d77d44f3ba5d3c86405ce933b4127fc0a3614c1b80",
                ContactInfo_03 = "d0a403b6f3a24026ba6a9d4b3008ef190efa0ed00c3f4507a8",
                ContactInfo_04 = "6ba321f6508d493d8e2e6b236d3ea6fe8cdfd21af4fb486fb53b41833d5e89aeea9de992059549789c9da2c7abeef445dccc41fb17a6464c9ce88f5a780db0995be6e53a32fd44f69f3802",
                ContactInfo_05 = "0530284882ff404981c4ac7d2fc1ea50367f746d5b7840868dad526af21f790ed486c624442f4ce886eccb0ad7f21ab15a3d25a5a78b4ab78f157c4b412e25b71da332509133445ca3c23e65dea6c2c6e7315148c88940539c73ced1b01ee0cdf91c599f581d43adbe440bebf2b94e228a8914ee00c6490a8cecc11527",
                ContactInfo_06 = "d0728ff0b7f8486",
                StockCode = "523e3",
                StockExchange = "de21bf52de",
                StockRegistrationDate = new DateTime(2023, 6, 25),
                IsPublicCompany = true,
                LicenseNo = "57829d4b58e34c9eb1b0",
                License = "c55fbef9dd544d6dad66",
                RegistrationOrder = 8,
                RegistrationDate0 = new DateTime(2015, 2, 18),
                RegistrationDate = new DateTime(2009, 6, 25),
                LatestAmendment = new DateTime(2007, 11, 3),
                LegalRepresent = "bd56474faea14854afe2567efd128bc6d59ad4b9ada848d396032fd0a61341fe0d4ccd31628742a09dd108e8e812f9adb96965bdacf140a78ad99a19bec2d4a80a6a0ef4b2a84219b72d8642719dac353a81317eeda4426aa71b203705ca23b6150074897a494506ab608a4ec2ef5d4ff1987ebe67b2400bbdcdd6dd00",
                CompanyType = "95827",
                CharteredCapital = 703057844,
                TotalShare = 1810999487,
                ListedShare = 1460249100,
                ParValue = 1806595328,
                ContactName1 = "ae4cc6c0f8974401b6aa0a6c031c8b0d02510afbb6be48bd97073e4b642600825187e1440cf44a889068bf016db0f1ecdae337e5e3b542fdbd3c4110e68f9d5851fe5c722b6149f0994249",
                ContactDept1 = "f1c3c637b4844b70b90839b20689c52b60171e3c63ef4d47a82c4db07c3ba5f142a0020fd9cc4fa9aecba1e4376d3710422f847b8ab44e83ba70980f83542092ce80db0cf7d74a0d99e7bc",
                ContactMail1 = "19b9d88e2c0249c991927f8f36c81bad0700785b8f214d3595955bd6b9528d77f0f9b589701d42d1b21f3f8e90fac68419f58e125b0b475693e826d1c49f7a6ba72e9b0e652d4d598e7f1e",
                ContactPosition1 = "eebf2c302b3a4c5e9c13c93ed22b659b407cc4c6785f431a8b995f482c8d6907ae4555b4966a4d0391c6e8127258b172bb5459745fb540508e9d02aae949eee895145a6302984dad97cd0b1f944744b7d82622a210dd46709220f216ee1837e82fcd1b6082b64629bbdce483e3ca47f4abae3418ffa84e858627d47ed8",
                ContactPhone1 = "8944f730f1b141b09941adbf4d5d3b848d15dab146f04ba2a9",
                ContactName2 = "b8fd764ee9b64523b54ab32651233bcfb58330b23bb2498688b75f6269a67b03591ed65986b24c3c9e205403ac6a231f2a14b7a5ed7545408093e075d48e61668d3213c0572d4c67a3e4f5",
                ContactDept2 = "9373095ed6434096a3aa3749b1f215092fd102aa43b4413b852d4351b3160a4ec3ab7c4f1d124f338976f3e592b0b1eec0801286860344d4a0d549635d6278267c49165cfdfd435fb3f5d2",
                ContactMail2 = "e247874b313b4c97995f2d913717c9a0188fa6ecd0dc478dbd1c48ba08f51e2985ec78c58d6f4cd5953bb61ff98b7959ea7ed3abf01d4425a769a2e80865a6895fe5e8b1020e441499e3bf",
                ContactPosition2 = "5f09ceb7c45f44e48344c68457d3d13c0e4968f1e68245d6b421d993e648587fc94fe4bbb3be467fb3d68fc84923a3d6b102eea210024b2bb44c77b73c4d831b529524f8f4204fc2a61b50554d0fb16ecaf1c3f3df364c03825290ac10d17854ce80d717a96d4e0fa88d0faab9a80e81c34fba5f818e4eecaba98a3a80",
                ContactPhone2 = "2cfb8f038f53442d8fbe44c5e697d725e952113ffebf44a391",
                longtitude = 1282167760,
                latitude = 1948659042,
                Note = "f6498ce3449f494295dac868329b45f626504971b2474b31ac4369bedcf87d19de0ea14b076945e2983a3d693ad01a699ebe202ecb0543e2b6d1cd99cbf3351655a9a4adc64c4b139cf714c9a77fd08f8c15ce26503e4ba6af2d15924612dca4a21235cdfc5b4897bbbeac6224e4c249a6d954b53d6d401e92f0c90db1",
                DocStatus = 67,
                DirectShareholding = 1240926208,
                ConsolidatedShareholding = 536848802,
                ConsolidateNoted = "13ac3037bd564271be4c1018b89f2e8cdfbbab4c2f0e4fec9e02ef7fe68c244d72be6ff8f13c438a8850049c",
                VotingRightDirect = 1324361527,
                VotingRightTotal = 913485593,
                Image = "fabe1b9973074a4f82ffae449a0b0734337522ac52ae4bbab7007ee92",
                IsActive = true,
                BravoCode = "d3324",
                LegacyCode = "3578429ec58146cf",
                idCompanyType = 1215198576
            };

            // Act
            var serviceResult = await _tbCompaniesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _tbCompanyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ParentId.ShouldBe(1700388594);
            result.IsGroup.ShouldBe(true);
            result.Code.ShouldBe("2338e493e31a4b0fa7b3");
            result.Name.ShouldBe("29784b3f6bbd4529be0469e3a543e71a2dc3762c8e804914a7d960b9687ac0738ba2c2e985014e719c37764a54f939b648a16090d6e6489a9c90f522c6b0ae72ca7fbffc6b2c4b998e5ab5524504ff373b121c56682b4678a08999175afe82ce090d8b5c3eb2454ea024471e7e69fe9a7ece947607fc43b79dfb54988a");
            result.Name_EN.ShouldBe("d6985e650ee6481ba2a64b0189720e2d17e83d0db7194b98a92f62725d2c54f582a40fc5028e4d3fba82adaee4eeb04d0115a83c4f644b2ea862a100ce40f629239e5c78083b4f29961ea92cfe15fde2b444ed5fd3544e2a817bdcbfea0d717448dfcf49723d496e9138c473ac94cc7063de5e2083464403bdb220acb2");
            result.BriefName.ShouldBe("1b023600123a4c098255d802afc463ef7c439d961bbe4e4697dc4d40085cd42d55ce00a760ca473e975212c140d5568179e3");
            result.ContactInfo_01.ShouldBe("b9b280a107fe4126a7a5fc268e7b19fec0c0b6fdb6dc4de299e95483c28b9465c5bd0d7471ec4334bc77548940c517e05867825361f34a65bc5aecbfa26f4fdec3219faa30ad4a1c9948b434ab958599f86dfff4e487468b94007e2593efccb8ec68c06c960e4360b39ee8e69a169bd90b31f4f510ca42e5bd3f2fb1b9");
            result.ContactInfo_02.ShouldBe("c17942a5d77d44f3ba5d3c86405ce933b4127fc0a3614c1b80");
            result.ContactInfo_03.ShouldBe("d0a403b6f3a24026ba6a9d4b3008ef190efa0ed00c3f4507a8");
            result.ContactInfo_04.ShouldBe("6ba321f6508d493d8e2e6b236d3ea6fe8cdfd21af4fb486fb53b41833d5e89aeea9de992059549789c9da2c7abeef445dccc41fb17a6464c9ce88f5a780db0995be6e53a32fd44f69f3802");
            result.ContactInfo_05.ShouldBe("0530284882ff404981c4ac7d2fc1ea50367f746d5b7840868dad526af21f790ed486c624442f4ce886eccb0ad7f21ab15a3d25a5a78b4ab78f157c4b412e25b71da332509133445ca3c23e65dea6c2c6e7315148c88940539c73ced1b01ee0cdf91c599f581d43adbe440bebf2b94e228a8914ee00c6490a8cecc11527");
            result.ContactInfo_06.ShouldBe("d0728ff0b7f8486");
            result.StockCode.ShouldBe("523e3");
            result.StockExchange.ShouldBe("de21bf52de");
            result.StockRegistrationDate.ShouldBe(new DateTime(2023, 6, 25));
            result.IsPublicCompany.ShouldBe(true);
            result.LicenseNo.ShouldBe("57829d4b58e34c9eb1b0");
            result.License.ShouldBe("c55fbef9dd544d6dad66");
            result.RegistrationOrder.ShouldBe((byte?)8);
            result.RegistrationDate0.ShouldBe(new DateTime(2015, 2, 18));
            result.RegistrationDate.ShouldBe(new DateTime(2009, 6, 25));
            result.LatestAmendment.ShouldBe(new DateTime(2007, 11, 3));
            result.LegalRepresent.ShouldBe("bd56474faea14854afe2567efd128bc6d59ad4b9ada848d396032fd0a61341fe0d4ccd31628742a09dd108e8e812f9adb96965bdacf140a78ad99a19bec2d4a80a6a0ef4b2a84219b72d8642719dac353a81317eeda4426aa71b203705ca23b6150074897a494506ab608a4ec2ef5d4ff1987ebe67b2400bbdcdd6dd00");
            result.CompanyType.ShouldBe("95827");
            result.CharteredCapital.ShouldBe(703057844);
            result.TotalShare.ShouldBe(1810999487);
            result.ListedShare.ShouldBe(1460249100);
            result.ParValue.ShouldBe(1806595328);
            result.ContactName1.ShouldBe("ae4cc6c0f8974401b6aa0a6c031c8b0d02510afbb6be48bd97073e4b642600825187e1440cf44a889068bf016db0f1ecdae337e5e3b542fdbd3c4110e68f9d5851fe5c722b6149f0994249");
            result.ContactDept1.ShouldBe("f1c3c637b4844b70b90839b20689c52b60171e3c63ef4d47a82c4db07c3ba5f142a0020fd9cc4fa9aecba1e4376d3710422f847b8ab44e83ba70980f83542092ce80db0cf7d74a0d99e7bc");
            result.ContactMail1.ShouldBe("19b9d88e2c0249c991927f8f36c81bad0700785b8f214d3595955bd6b9528d77f0f9b589701d42d1b21f3f8e90fac68419f58e125b0b475693e826d1c49f7a6ba72e9b0e652d4d598e7f1e");
            result.ContactPosition1.ShouldBe("eebf2c302b3a4c5e9c13c93ed22b659b407cc4c6785f431a8b995f482c8d6907ae4555b4966a4d0391c6e8127258b172bb5459745fb540508e9d02aae949eee895145a6302984dad97cd0b1f944744b7d82622a210dd46709220f216ee1837e82fcd1b6082b64629bbdce483e3ca47f4abae3418ffa84e858627d47ed8");
            result.ContactPhone1.ShouldBe("8944f730f1b141b09941adbf4d5d3b848d15dab146f04ba2a9");
            result.ContactName2.ShouldBe("b8fd764ee9b64523b54ab32651233bcfb58330b23bb2498688b75f6269a67b03591ed65986b24c3c9e205403ac6a231f2a14b7a5ed7545408093e075d48e61668d3213c0572d4c67a3e4f5");
            result.ContactDept2.ShouldBe("9373095ed6434096a3aa3749b1f215092fd102aa43b4413b852d4351b3160a4ec3ab7c4f1d124f338976f3e592b0b1eec0801286860344d4a0d549635d6278267c49165cfdfd435fb3f5d2");
            result.ContactMail2.ShouldBe("e247874b313b4c97995f2d913717c9a0188fa6ecd0dc478dbd1c48ba08f51e2985ec78c58d6f4cd5953bb61ff98b7959ea7ed3abf01d4425a769a2e80865a6895fe5e8b1020e441499e3bf");
            result.ContactPosition2.ShouldBe("5f09ceb7c45f44e48344c68457d3d13c0e4968f1e68245d6b421d993e648587fc94fe4bbb3be467fb3d68fc84923a3d6b102eea210024b2bb44c77b73c4d831b529524f8f4204fc2a61b50554d0fb16ecaf1c3f3df364c03825290ac10d17854ce80d717a96d4e0fa88d0faab9a80e81c34fba5f818e4eecaba98a3a80");
            result.ContactPhone2.ShouldBe("2cfb8f038f53442d8fbe44c5e697d725e952113ffebf44a391");
            result.longtitude.ShouldBe(1282167760);
            result.latitude.ShouldBe(1948659042);
            result.Note.ShouldBe("f6498ce3449f494295dac868329b45f626504971b2474b31ac4369bedcf87d19de0ea14b076945e2983a3d693ad01a699ebe202ecb0543e2b6d1cd99cbf3351655a9a4adc64c4b139cf714c9a77fd08f8c15ce26503e4ba6af2d15924612dca4a21235cdfc5b4897bbbeac6224e4c249a6d954b53d6d401e92f0c90db1");
            result.DocStatus.ShouldBe((byte?)67);
            result.DirectShareholding.ShouldBe(1240926208);
            result.ConsolidatedShareholding.ShouldBe(536848802);
            result.ConsolidateNoted.ShouldBe("13ac3037bd564271be4c1018b89f2e8cdfbbab4c2f0e4fec9e02ef7fe68c244d72be6ff8f13c438a8850049c");
            result.VotingRightDirect.ShouldBe(1324361527);
            result.VotingRightTotal.ShouldBe(913485593);
            result.Image.ShouldBe("fabe1b9973074a4f82ffae449a0b0734337522ac52ae4bbab7007ee92");
            result.IsActive.ShouldBe(true);
            result.BravoCode.ShouldBe("d3324");
            result.LegacyCode.ShouldBe("3578429ec58146cf");
            result.idCompanyType.ShouldBe(1215198576);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tbCompaniesAppService.DeleteAsync(1);

            // Assert
            var result = await _tbCompanyRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}