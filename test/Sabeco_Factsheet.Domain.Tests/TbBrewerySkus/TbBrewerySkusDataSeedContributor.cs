using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbBrewerySkus;

namespace Sabeco_Factsheet.TbBrewerySkus
{
    public class TbBrewerySkusDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbBrewerySkuRepository _tbBrewerySkuRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbBrewerySkusDataSeedContributor(ITbBrewerySkuRepository tbBrewerySkuRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbBrewerySkuRepository = tbBrewerySkuRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbBrewerySkuRepository.InsertAsync(new TbBrewerySku
            (
                year: 830133244,
                breweryCode: "e5fbd0c96fe942d3b5ad",
                sKUCode: "b1caf89d6738454a",
                productionVolume: 653412074,
                docStatus: 21,
                isActive: true,
                breweryId: 1416201066,
                sKUId: 11361351
            ));

            await _tbBrewerySkuRepository.InsertAsync(new TbBrewerySku
            (
                year: 1841927926,
                breweryCode: "192a96c32ac5472f90ad",
                sKUCode: "47a2517d22724399",
                productionVolume: 259560218,
                docStatus: 95,
                isActive: true,
                breweryId: 1289184752,
                sKUId: 395417505
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}