using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbUserMappingCompanies;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public class TbUserMappingCompaniesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbUserMappingCompanyRepository _tbUserMappingCompanyRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbUserMappingCompaniesDataSeedContributor(ITbUserMappingCompanyRepository tbUserMappingCompanyRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbUserMappingCompanyRepository = tbUserMappingCompanyRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbUserMappingCompanyRepository.InsertAsync(new TbUserMappingCompany
            (
                userid: 1971982339,
                companyid: 511886567,
                isActive: true
            ));

            await _tbUserMappingCompanyRepository.InsertAsync(new TbUserMappingCompany
            (
                userid: 982643427,
                companyid: 1796905491,
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}