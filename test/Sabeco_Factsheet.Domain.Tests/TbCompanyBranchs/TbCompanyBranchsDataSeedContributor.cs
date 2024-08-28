using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyBranchs;

namespace Sabeco_Factsheet.TbCompanyBranchs
{
    public class TbCompanyBranchsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyBranchRepository _tbCompanyBranchRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyBranchsDataSeedContributor(ITbCompanyBranchRepository tbCompanyBranchRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyBranchRepository = tbCompanyBranchRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyBranchRepository.InsertAsync(new TbCompanyBranch
            (
                companyId: 1959364962,
                branchName: "faca48658e564dbbb953bc7dadf4d34ace70f2e481af45959ed46419d955fe67c701ce17450544a08f",
                branchAddress: "a27fe88f88cc4ca588ff9e4b671d41771ef66ca",
                branchCode: "5c6ee064775c4f28bda3ed7b1d5bcbd359c28fde3f8e4f29870a06cef5abd0b398ee623a4ef442d5ba2c517177a49a",
                contactPerson: "bfc99a6d",
                contactPhone: "ba233157a6a64398867af2ccc9",
                email: "47c0dbe1e8b54b79ab17e91a9fe74",
                isActive: true
            ));

            await _tbCompanyBranchRepository.InsertAsync(new TbCompanyBranch
            (
                companyId: 1883655491,
                branchName: "5b276ce77cdd4a1f99815b04670e2d65a0279faf75cd451a9b51e75e378417b",
                branchAddress: "aabe5a12103e4ac18a319352fd65baf8382f",
                branchCode: "a7665df4a63347f6bcdd39d5c700ec9100a8b0fa6287466cb147fa36aa858b01a",
                contactPerson: "88f604666879439584973bde5f5c2e8f51219ffd2535",
                contactPhone: "e344bc5ca3274faab5cfae9f76e2384870f58f9dde2e4",
                email: "5e585a8356ec4ef181468f0354db3251463beb4ccc924f939df4a",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}