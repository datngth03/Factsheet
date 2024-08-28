using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyBusinesses;

namespace Sabeco_Factsheet.TbCompanyBusinesses
{
    public class TbCompanyBusinessesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyBusinessRepository _tbCompanyBusinessRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyBusinessesDataSeedContributor(ITbCompanyBusinessRepository tbCompanyBusinessRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyBusinessRepository = tbCompanyBusinessRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyBusinessRepository.InsertAsync(new TbCompanyBusiness
            (
                companyId: 1623233263,
                license: "887856f5110c4b89b8f6",
                registrationNo: 90,
                registrationDate: new DateTime(2021, 6, 19),
                companyName: "a5699b37ed8f46be920e1a5f31bcd8b3f34ef1d9207543f19ef98c58a94e02f23fff29c0adb24e3f94024d2bd80e05416f02dac28eae40e6bbcf6ef2a66e196b36f38c36df0b407b8c0b8d2974acf04de7a3fb9a62f5419084dc004286d038307360a7a48e90427e855a2f749dfce4daa89bf3e74c8e411498e6ee3efd",
                companyAddress: "a048d006e2fe40359bfc9a9eda3955e6e3652cf8bbf943e89f28f8af904e130a525a4b0ce93d46e99889ab94ca6ff24144327c871eee4c78953a3c9810a62cfbe519dd22a45544dcaa0aad1730e3c15ab4b7b37e493e48ca9df69216b51e83bd5330926082ad4e7d94e528f8bc0827c1ce1f3e6f4de74e59bdf5337e03",
                legalRepresent: "ae308af8559a428d8dde53fb5f916f991647decd48e94bea8d6a0f4ba4d3f9f00afa2e361c1240488fe0ba5189ef6c140374236172a44589a1c5e2121ef082ec6e1464fdd57d4c9893c7548160521bd97915684c433f4807b3ff06e4fb167e0505e44ba279b94e30a9240e47ad9bdab643860f53469c496cb5c3df5f13",
                companyType: "3ccd291f2d2745a981a64f02eb16914cb197a4dd9a0a446a9054015c4ee8053782b7437e8b304b10b8ab5910d71e7b6d01bf596019714e1285c3f62276d1c4ec499f3a8ba25d46ad8459281f0a0fd51a21d3072d07864a77ba8d2f4e2300bde7304e370db317431bb643ebd59a20778b58e8d190dfef4b97a01f3f1544",
                majorBusiness: "19f131dd77b34b639b4022e99d01853e3d55b03c01e8427cbd516aebcbd7aa2c9454c88d1a084e8ca3bfdedbf44fc6b60d060364f6d2445385c47aeaa7c4db95ff72b6bac4d94a109d0dc4b4a532968e55c30c0ba7f14595945b11d1ae8c1d9c4e8788d752b44ad2b45b45b4463aa9fb125a4d71ff6a4288a8a8478851",
                otherActivity: "67d54f48c86a4898be62a61737203559a8727b4c21284f988ca41aef640e1ba49ce87c900b43402db155f49b63d46d0ef89eba0d478941caaf2314d80889dc34ba0cac00504e45a7badc85165ff617efec1cc3fab3804630aec1c4d12b0b6910edfe4271278c4165b2230ac845d28a6ed0087d52b4eb40dcaee529fe388987e3295fedd84bd54fcd8b804ad346e9ba8931e22e22249e4961bd05a1f0401ce6449da93085979b42aa981986a71e5616c4d8ed21ed78cb41dfad5c2b2d177a12ed30845ff9e7f04908b21740d04e5237351181167fefe74b0c88e65fc8ed923878ccc4a0dca7f64ef6bc84b93117d5106d59f71d92198540d898e3",
                note: "86286cab3fc94d3eb57f1ba7604ec8b1efb78450af404fafbf2c7d6f83023222db0f4751bd7644bc98dbfc224ea293a84f25c6b20f144b818335c89833a494c7ba43101db43e44bcaf212d8ba29f491213e7a3c4663245749f075efde33122125790dd7e4b9f4df1b11c9443429c95414a4196dbbcd4457d80e5fdd2d5",
                isActive: true,
                latestAmendment: new DateTime(2016, 9, 23)
            ));

            await _tbCompanyBusinessRepository.InsertAsync(new TbCompanyBusiness
            (
                companyId: 1881916535,
                license: "19e6348112b943b088ab",
                registrationNo: 20,
                registrationDate: new DateTime(2011, 1, 18),
                companyName: "d8b5af82162547d0927086920f0bdfa8d262cf813d29403abca7fdf13c2f4e0668e5b8d3703a41e787e97a4a25104a20f30a08eec43d4f63ba1056232f2cd9995faf5e1254b742a18392a864353503cceedc7985ca3a498189f09c010d1d69f1b9902ebb5c1349c2b3c36f1678dfde1608a5322792bf45ca93ee59d28d",
                companyAddress: "c517662e25094486afd22c2f567631ec0121864f7b29473a8b0277646a916e57f6a72238dcfd402cafa204a5eae9a4e0f8b99e07caef4a188bd959314ce89aa954c58b171b804a7a85697f0fe26e4682f79a61c792434b9bb8c947796733a78300505f19421642cea4c03c8241c67c31b7f0abcfb19b4b2c981603cbb7",
                legalRepresent: "4fba70d74470466a914974f7dcb0a53adff308b1a8ef48d6a1b45b02caaab748bbec10d4b97144dd9d533ac74e957459a28d5f3fc8b14a7b8757a52eb31e4997248437693a2849599bbb35c3ab770942eb340cdda746428d979ff62f07687af4862e9afdc9f6483eba2f01c91ea622386a3442b7e2bf4708914b29166e",
                companyType: "b45005a96dec4397b39b305f2d7a92f2c5a2bb77e47e4795b6171a5089b21dc3c9ab49607a864d559acf9726d252b457c1c0db7aeb1546b986c02052528a2f464ccd97b636bd45fd8721bc6d93822ba30a1d8e87261b4a248656d79ea35ba6a54bcf4f36799b4b67b107dddb567e67093f565a72465f4a0da299190ed4",
                majorBusiness: "e2d4fb9460f74392b02c83ee69d5e2a3ceb34c80614e4bcb9c9c4d5d6462a648d1b6a5d770ae489593797f19dd0e999e2594365f6da3439b8f34d85101d4ae181174d36e40194779b9972421ac1c5143c0a6139fb90640c1b195cff0586fdacd4dab9a1bd17341759ed8a2a89ab089ce3f7d02f0150b4899b260ed64ca",
                otherActivity: "6ac14489101e462aa4694a9e75284c36088184db6ec7422a87af48cb4b6554ff6b5db35de7f0467a9e4c25c080e4966fb73be7db8a4641a9830c8996148f219a4e6a813e64f94136a3f239ed5c346c870261f3ca6bf741d89bc3de7cede01125fa10045e937941f8b5baa5a3658151de665aa02695164222a4d2cb0b24b0ea030511f2ebb2464e95be2dbaa3d2f564463fb3cc1046f44fb7addfa547edfd014f7d794d81ec3a4769833a2485148369c2eaa5abc7bb3f4850b75ffd8ee68670399b8a51f2198f4d0d90407774967da0897c81e628d2334d439a23b74fe3f757bff5c88f6009c54c4e8dc5fe947a383cea8bdf1705e37745cc8882",
                note: "e76cddb51edf4e7aae1e7bb4a05396f735fe8bc4dbb34384b432ef2cf09983299397b6e97ffe4787b86b1340a3928e01039ac9d04797474694ab2d38d9a2e10fa011a61d1ebd406da0413f354b4e2fd809ce3e5de6bf48ad99cc12ca9959d66cda4a392387b04336bf2b061eca5bebac960c322566b948aaaa0fee5596",
                isActive: true,
                latestAmendment: new DateTime(2011, 4, 20)
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}