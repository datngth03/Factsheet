using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbBrewerySkuTemps;

namespace Sabeco_Factsheet.TbBrewerySkuTemps
{
    public class TbBrewerySkuTempsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbBrewerySkuTempRepository _tbBrewerySkuTempRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbBrewerySkuTempsDataSeedContributor(ITbBrewerySkuTempRepository tbBrewerySkuTempRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbBrewerySkuTempRepository = tbBrewerySkuTempRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbBrewerySkuTempRepository.InsertAsync(new TbBrewerySkuTemp
            (
                idBrewerySKU: 864909998,
                year: 1732447044,
                breweryCode: "f05d6bd7962542ce9c1a",
                sKUCode: "c689f85d00fb4670",
                productionVolume: 324718562,
                docStatus: 11,
                isActive: true,
                breweryId: 7534701,
                sKUId: 1104943050
            ));

            await _tbBrewerySkuTempRepository.InsertAsync(new TbBrewerySkuTemp
            (
                idBrewerySKU: 1497795924,
                year: 1985283496,
                breweryCode: "85d93e58cb2f4befa11b",
                sKUCode: "c52fdd641bd240a6",
                productionVolume: 75176819,
                docStatus: 68,
                isActive: true,
                breweryId: 1082048084,
                sKUId: 967184766
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}