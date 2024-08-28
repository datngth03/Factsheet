using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbBreweryDeliveryVolumes;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{
    public class TbBreweryDeliveryVolumesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbBreweryDeliveryVolumeRepository _tbBreweryDeliveryVolumeRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbBreweryDeliveryVolumesDataSeedContributor(ITbBreweryDeliveryVolumeRepository tbBreweryDeliveryVolumeRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbBreweryDeliveryVolumeRepository = tbBreweryDeliveryVolumeRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbBreweryDeliveryVolumeRepository.InsertAsync(new TbBreweryDeliveryVolume
            (
                breweryId: 1183940172,
                breweryCode: "ec07a9ecda204227b695",
                year: 1279136856,
                deliveryVolume: 1739533493,
                isActive: true
            ));

            await _tbBreweryDeliveryVolumeRepository.InsertAsync(new TbBreweryDeliveryVolume
            (
                breweryId: 505165994,
                breweryCode: "fcd519eb07854a34a66d",
                year: 2007766299,
                deliveryVolume: 1776784424,
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}