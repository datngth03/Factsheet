using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbContacts;

namespace Sabeco_Factsheet.TbContacts
{
    public class TbContactsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbContactRepository _tbContactRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbContactsDataSeedContributor(ITbContactRepository tbContactRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbContactRepository = tbContactRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbContactRepository.InsertAsync(new TbContact
            (
                companyid: 1524223888,
                contactName: "867277211f01400db12f6699000eb0727cad659e63cb4440b4a36119367e8ebc6273cbc042f9488db24c243b3844267432d2723ec12a404f8a0d28e3030aa335271e34fe7714495fb43df4",
                contactDept: "0390e21792a64eb9bcc7f8d6a9d0c14d07f9b1088f59415eb7648ed39237799d8965c323146a47fa8568b6f5e47b8a3dbaef4821f78b41579179c6026b3d65150f86d821fc8e45a5b68c8d",
                contactPosition: "3163e3a2544e497f9dc717ab3d4bf7fe77410f1ec59f4dbdac367fa7a013f0afc5a9a4ca79b241fb85187a7cb61f14171a7ad0ca4b03497fae0bb26a34c4412a1d918f0606ad47a8aadd4a",
                contactEmail: "c3e954d2ace046b395c25d9e8e0d4b283e9b113911ca44e5a5c22fb9e1d0563278462f4c03944db4b2d949c3afc1cbab8e68b951c73647ae8c692e7c540e380a2e4134c507044199820774",
                contactPhone: "b6aa30559aaf428986b2ed6a27e33bfa5c563e45812044f09f",
                note: "a422bed38850422ea73b235968e5a6fb66d615e8aebf4b1a944e1a44763006fb3cb27b8ecd544854a371c6d37c28c0438112a7d7c09143e4b71b9501ec4e9508ef46931e53874b51b618fbe6d53bf8ff5cfcdb012f2a474b8293e646a6ff140f0d506de6cd1f49d6aca550735911920a79bdbb2c464749659e7b6d0205",
                docStatus: 109,
                isActive: true
            ));

            await _tbContactRepository.InsertAsync(new TbContact
            (
                companyid: 1963987389,
                contactName: "bac3cc2957fc4a33a56e09d00a390d90981f3b14939a4015b9776bb4e718a7d3d409e8d53bb740b484e882fca0a72d1715b9c3f5c71a447fb6dff9889da4473ca855a0333a4846e9ba8590",
                contactDept: "97046d60e6284ef2bd324d3bedf956b798937d3ee5674239bc69a4b955d2e18c83b0c85f8ced45f69811081dd802dda8f3e776e761c5417595a82099a43942adea9d334fe1ee4f8792ddce",
                contactPosition: "56568688dc0647098b6b6d1d7fbcc4ad43af688e88ce4954a024d323bd27117b123c1ace3eb344fc89762391ed6eb7ab92dff59efab14920af537e586400979031a263d7efb94dd2b6f27b",
                contactEmail: "660598a56c064dfcb86c7393c869a9071f155e4ca64b466bb0721b4cbe1d435c72e50818cc3e4513aba6a428b8f705f9daf57a539a3c48959bb64bd8244ff4242dfb939afa9e40a2b4dae5",
                contactPhone: "7cb303a9fef5449e9e9ce9ddee38bc0a163db1ab6a71468ebd",
                note: "db71cca7910c4b1fb798a587e60657eadaced6fb0fe3425eae14c81884aead52ac9838f616114aec9f63e33585e39d870a1f6265c4a448fb99b6ed5d6ed49e9c23f6178efb6c427eb8589c6d000f68dad8a1190270064648b245d59dc31b20e45b6f5c6305df4f1ca70a02de9f7fe4761696f71decb24f839136bdbd55",
                docStatus: 32,
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}