using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbUserMappingPersons;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public class TbUserMappingPersonsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbUserMappingPersonRepository _tbUserMappingPersonRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbUserMappingPersonsDataSeedContributor(ITbUserMappingPersonRepository tbUserMappingPersonRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbUserMappingPersonRepository = tbUserMappingPersonRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbUserMappingPersonRepository.InsertAsync(new TbUserMappingPerson
            (
                userid: 441401511,
                personid: 893588670,
                isActive: true
            ));

            await _tbUserMappingPersonRepository.InsertAsync(new TbUserMappingPerson
            (
                userid: 314119130,
                personid: 194815462,
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}