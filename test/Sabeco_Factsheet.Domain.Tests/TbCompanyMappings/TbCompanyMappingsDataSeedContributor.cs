using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyMappings;

namespace Sabeco_Factsheet.TbCompanyMappings
{
    public class TbCompanyMappingsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyMappingRepository _tbCompanyMappingRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyMappingsDataSeedContributor(ITbCompanyMappingRepository tbCompanyMappingRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyMappingRepository = tbCompanyMappingRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyMappingRepository.InsertAsync(new TbCompanyMapping
            (
                companyId: 657274971,
                companyTypeShareholdingCode: "8398cc18f29a4e7ebfcb83929b3eef7dc03fff3082a1491",
                companyTypesCode: "2906405d9ddb44d3a26b4f675346349f83b8dedb644b4b6881b356c8e599617165d77c7bb7df425593063ce385dfeff",
                note: "35622fe207e74951bcf188451cb2bbff2a4c495fede1415ab9761f71b42e8e381a0",
                idCompanyTypeShareholdingCode: 479892129,
                idCompanyTypesCode: 959773656
            ));

            await _tbCompanyMappingRepository.InsertAsync(new TbCompanyMapping
            (
                companyId: 1806590300,
                companyTypeShareholdingCode: "372b2c8b56224494a341875dfa122274888c9222f",
                companyTypesCode: "93a5e4a6991d488787ca665e96c5c7c9c",
                note: "6fec5efad8e646a5bd6c4ab62aada718c7229cbe1c394ef4806a892eb44e7d123bd283936",
                idCompanyTypeShareholdingCode: 615510934,
                idCompanyTypesCode: 1061730810
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}