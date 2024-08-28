using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyMemberCouncilTerms;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public class TbCompanyMemberCouncilTermsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyMemberCouncilTermRepository _tbCompanyMemberCouncilTermRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyMemberCouncilTermsDataSeedContributor(ITbCompanyMemberCouncilTermRepository tbCompanyMemberCouncilTermRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyMemberCouncilTermRepository = tbCompanyMemberCouncilTermRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyMemberCouncilTermRepository.InsertAsync(new TbCompanyMemberCouncilTerm
            (
                companyId: 1032710736,
                termFrom: 687432318,
                termEnd: 431080890
            ));

            await _tbCompanyMemberCouncilTermRepository.InsertAsync(new TbCompanyMemberCouncilTerm
            (
                companyId: 423804900,
                termFrom: 165693981,
                termEnd: 973143185
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}