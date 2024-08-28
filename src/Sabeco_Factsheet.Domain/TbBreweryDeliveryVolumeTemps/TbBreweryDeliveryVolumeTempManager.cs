using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps
{
    public abstract class TbBreweryDeliveryVolumeTempManagerBase : DomainService
    {
        public ITbBreweryDeliveryVolumeTempRepository _tbBreweryDeliveryVolumeTempRepository;

        public TbBreweryDeliveryVolumeTempManagerBase(ITbBreweryDeliveryVolumeTempRepository tbBreweryDeliveryVolumeTempRepository)
        {
            _tbBreweryDeliveryVolumeTempRepository = tbBreweryDeliveryVolumeTempRepository;
        }

        public virtual async Task<TbBreweryDeliveryVolumeTemp> CreateAsync(
        int? idBreweryDeliveryVolume = null, int? breweryId = null, string? breweryCode = null, int? year = null, decimal? deliveryVolume = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.Length(breweryCode, nameof(breweryCode), TbBreweryDeliveryVolumeTempConsts.BreweryCodeMaxLength);

            var tbBreweryDeliveryVolumeTemp = new TbBreweryDeliveryVolumeTemp(

             idBreweryDeliveryVolume, breweryId, breweryCode, year, deliveryVolume, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbBreweryDeliveryVolumeTempRepository.InsertAsync(tbBreweryDeliveryVolumeTemp);
        }

        public virtual async Task<TbBreweryDeliveryVolumeTemp> UpdateAsync(
            int id,
            int? idBreweryDeliveryVolume = null, int? breweryId = null, string? breweryCode = null, int? year = null, decimal? deliveryVolume = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.Length(breweryCode, nameof(breweryCode), TbBreweryDeliveryVolumeTempConsts.BreweryCodeMaxLength);

            var tbBreweryDeliveryVolumeTemp = await _tbBreweryDeliveryVolumeTempRepository.GetAsync(id);

            tbBreweryDeliveryVolumeTemp.idBreweryDeliveryVolume = idBreweryDeliveryVolume;
            tbBreweryDeliveryVolumeTemp.BreweryId = breweryId;
            tbBreweryDeliveryVolumeTemp.BreweryCode = breweryCode;
            tbBreweryDeliveryVolumeTemp.Year = year;
            tbBreweryDeliveryVolumeTemp.DeliveryVolume = deliveryVolume;
            tbBreweryDeliveryVolumeTemp.isActive = isActive;
            tbBreweryDeliveryVolumeTemp.create_user = create_user;
            tbBreweryDeliveryVolumeTemp.create_date = create_date;
            tbBreweryDeliveryVolumeTemp.mod_user = mod_user;
            tbBreweryDeliveryVolumeTemp.mod_date = mod_date;

            return await _tbBreweryDeliveryVolumeTempRepository.UpdateAsync(tbBreweryDeliveryVolumeTemp);
        }

    }
}