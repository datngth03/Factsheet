using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbUserMappingBreweries;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public class TbUserMappingBreweriesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbUserMappingBreweryRepository _tbUserMappingBreweryRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbUserMappingBreweriesDataSeedContributor(ITbUserMappingBreweryRepository tbUserMappingBreweryRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbUserMappingBreweryRepository = tbUserMappingBreweryRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbUserMappingBreweryRepository.InsertAsync(new TbUserMappingBrewery
            (
                userid: 1340976894,
                breweryid: 2084506181,
                isActive: true
            ));

            await _tbUserMappingBreweryRepository.InsertAsync(new TbUserMappingBrewery
            (
                userid: 1061800336,
                breweryid: 358462575,
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}