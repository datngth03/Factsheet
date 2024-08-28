using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps
{
    public class TbBreweryDeliveryVolumeTempsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbBreweryDeliveryVolumeTempRepository _tbBreweryDeliveryVolumeTempRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbBreweryDeliveryVolumeTempsDataSeedContributor(ITbBreweryDeliveryVolumeTempRepository tbBreweryDeliveryVolumeTempRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbBreweryDeliveryVolumeTempRepository = tbBreweryDeliveryVolumeTempRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbBreweryDeliveryVolumeTempRepository.InsertAsync(new TbBreweryDeliveryVolumeTemp
            (
                idBreweryDeliveryVolume: 1680536482,
                breweryId: 877709209,
                breweryCode: "5cc52628d93e4cd999d3",
                year: 127513005,
                deliveryVolume: 13831364,
                isActive: true
            ));

            await _tbBreweryDeliveryVolumeTempRepository.InsertAsync(new TbBreweryDeliveryVolumeTemp
            (
                idBreweryDeliveryVolume: 1901927480,
                breweryId: 1673886698,
                breweryCode: "ec42b415f32045339520",
                year: 257138004,
                deliveryVolume: 1191440592,
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}