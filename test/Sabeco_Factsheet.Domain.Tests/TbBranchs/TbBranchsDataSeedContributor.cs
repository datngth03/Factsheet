using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbBranchs;

namespace Sabeco_Factsheet.TbBranchs
{
    public class TbBranchsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbBranchRepository _tbBranchRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbBranchsDataSeedContributor(ITbBranchRepository tbBranchRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbBranchRepository = tbBranchRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbBranchRepository.InsertAsync(new TbBranch
            (
                code: "e09ebdc8ab",
                briefName: "2da093da85604b24bbe2353632995e614a2244f1f81b4e579d",
                name: "f40e5ebde6034238b7bdd1e864e25e8c258ccb37398f4293b452bb1816870f6264c3337cb13a4034bf7cb869cb1b3d6591ee0bba4f644c2bbb68208dd804fe61eb9721b693984eb7aca95fbce9c3feadf5f1bb5521d34663841ed2e91feccd3b7fbdba22f77c4e7a95e6c91aff041be6fba3e33c1d74402cbe2747d375",
                name_EN: "e14dcb97df1943bcae5ff29a4ce7edadb6aba2c92c7b4e90bc9d8ed64bb6a33e077c2a90a3b2457492aefbb4374cb4f58879e87405974b82a9898957a872c34206b20b02e0e440878d76fe35c541f754f3f0ce4edf9b48c28d52d4722be425503f5b47e6e96745f1b655dc4a7205b579e9ef30ff09834ba18d51620134",
                companyCode: "55ba2ebd00fb4b4e8e2a",
                description: "44a439be924a4067ac23b2364e70a4a07bba1fd097004d6da5faea04b0caa7166faed3ccd0f342a79dc61f255d8eb74b47c76ace097c4caa8e63c9ba97f2142c08e53cef45ff4699b0b56510f055330b197889beb7e340b8bd3951dd59153820c5531f6bb4f5498998e19b8c16fd09db76d15e83814541af976f7f0625",
                isActive: true,
                crt_Date: new DateTime(2003, 7, 14)
            ));

            await _tbBranchRepository.InsertAsync(new TbBranch
            (
                code: "9d22ca9234",
                briefName: "525a189f5e664015ad9288f8626e7fec401b76d5d6484b5f83",
                name: "0bdb2c127a6d47bbb722e53b63daa6fa90c0dec148ca48d2bcb001a23631a7dc3c8ac17e2a7c40ffae3f08b383c785dd8f68de7f34f14323a75e70a7a39729ef2acc2b8b9acf40aab0e0b37cc07fd919d5d3815cdbab4d40a21eef0485dc4e718a7779f34c6c46e099de57df0554d096ec5a1978381f4b4abe369efb8c",
                name_EN: "d5b3cd7a5a234ae992c6e5ab67ab22a9d1d94387e7f442809987d245d8fb9d80a5a47cc377124884ad726c21f941896cad8cefb7d91347478db844ffb2d4a08e7fd368ab2f5247d3ab1f54149120d2b6c88e7bb69ffd4e84b3f3359099026c56589474c3a3294fc6a4030a5a115964a0131c2fc83abf451c9d751e6058",
                companyCode: "62f82e0ad3c94ad6a428",
                description: "159e95842f1d47e89ce3189ffa2d4a806bd220931ff5407cbe79dca6240c89850eee30fe3316465f82026281f6c9996e48241f7c5d634007a87c8caf956d1e05827e472bc408438989dab81c6038f5ef20378df4eeeb456bbc355e4f3e7f81bd581687e7932149eaa56d0f66c43a37bcb43bb45d1219431b946d0615b5",
                isActive: true,
                crt_Date: new DateTime(2021, 9, 18)
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}