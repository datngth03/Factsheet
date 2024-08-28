using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyInvests;

namespace Sabeco_Factsheet.TbCompanyInvests
{
    public class TbCompanyInvestsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyInvestRepository _tbCompanyInvestRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyInvestsDataSeedContributor(ITbCompanyInvestRepository tbCompanyInvestRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyInvestRepository = tbCompanyInvestRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyInvestRepository.InsertAsync(new TbCompanyInvest
            (
                companyId: 1503253470,
                companyName: "77f9153b2d714373873d0545fce35c75afd2cd78db3a455cb8b19d70fc442bc",
                shares: 1960864816,
                holding: 1807282490,
                isActive: true
            ));

            await _tbCompanyInvestRepository.InsertAsync(new TbCompanyInvest
            (
                companyId: 333025019,
                companyName: "2c3473a944e54802aabf7e953af7a99d484d7fa9bfb541e5aafab",
                shares: 88856068,
                holding: 885302666,
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}