using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{
    public abstract class TbBreweryDeliveryVolumeManagerBase : DomainService
    {
        public ITbBreweryDeliveryVolumeRepository _tbBreweryDeliveryVolumeRepository;

        public TbBreweryDeliveryVolumeManagerBase(ITbBreweryDeliveryVolumeRepository tbBreweryDeliveryVolumeRepository)
        {
            _tbBreweryDeliveryVolumeRepository = tbBreweryDeliveryVolumeRepository;
        }

        public virtual async Task<TbBreweryDeliveryVolume> CreateAsync(
        int? breweryId = null, string? breweryCode = null, int? year = null, decimal? deliveryVolume = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.Length(breweryCode, nameof(breweryCode), TbBreweryDeliveryVolumeConsts.BreweryCodeMaxLength);

            var tbBreweryDeliveryVolume = new TbBreweryDeliveryVolume(

             breweryId, breweryCode, year, deliveryVolume, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbBreweryDeliveryVolumeRepository.InsertAsync(tbBreweryDeliveryVolume);
        }

        public virtual async Task<TbBreweryDeliveryVolume> UpdateAsync(
            int id,
            int? breweryId = null, string? breweryCode = null, int? year = null, decimal? deliveryVolume = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.Length(breweryCode, nameof(breweryCode), TbBreweryDeliveryVolumeConsts.BreweryCodeMaxLength);

            var tbBreweryDeliveryVolume = await _tbBreweryDeliveryVolumeRepository.GetAsync(id);

            tbBreweryDeliveryVolume.BreweryId = breweryId;
            tbBreweryDeliveryVolume.BreweryCode = breweryCode;
            tbBreweryDeliveryVolume.Year = year;
            tbBreweryDeliveryVolume.DeliveryVolume = deliveryVolume;
            tbBreweryDeliveryVolume.isActive = isActive;
            tbBreweryDeliveryVolume.create_user = create_user;
            tbBreweryDeliveryVolume.create_date = create_date;
            tbBreweryDeliveryVolume.mod_user = mod_user;
            tbBreweryDeliveryVolume.mod_date = mod_date;

            return await _tbBreweryDeliveryVolumeRepository.UpdateAsync(tbBreweryDeliveryVolume);
        }

    }
}