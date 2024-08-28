using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbHisBreweryDeliveryVolumes
{
    public abstract class TbHisBreweryDeliveryVolumeManagerBase : DomainService
    {
        public ITbHisBreweryDeliveryVolumeRepository _tbHisBreweryDeliveryVolumeRepository;

        public TbHisBreweryDeliveryVolumeManagerBase(ITbHisBreweryDeliveryVolumeRepository tbHisBreweryDeliveryVolumeRepository)
        {
            _tbHisBreweryDeliveryVolumeRepository = tbHisBreweryDeliveryVolumeRepository;
        }

        public virtual async Task<TbHisBreweryDeliveryVolume> CreateAsync(
        int type, int idBreweryDeliveryVolume, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, int? breweryId = null, string? breweryCode = null, int? year = null, decimal? deliveryVolume = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.Length(breweryCode, nameof(breweryCode), TbHisBreweryDeliveryVolumeConsts.BreweryCodeMaxLength);

            var tbHisBreweryDeliveryVolume = new TbHisBreweryDeliveryVolume(

             type, idBreweryDeliveryVolume, isSendMail, dateSendMail, insertDate, breweryId, breweryCode, year, deliveryVolume, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbHisBreweryDeliveryVolumeRepository.InsertAsync(tbHisBreweryDeliveryVolume);
        }

        public virtual async Task<TbHisBreweryDeliveryVolume> UpdateAsync(
            int id,
            int type, int idBreweryDeliveryVolume, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, int? breweryId = null, string? breweryCode = null, int? year = null, decimal? deliveryVolume = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.Length(breweryCode, nameof(breweryCode), TbHisBreweryDeliveryVolumeConsts.BreweryCodeMaxLength);

            var tbHisBreweryDeliveryVolume = await _tbHisBreweryDeliveryVolumeRepository.GetAsync(id);

            tbHisBreweryDeliveryVolume.Type = type;
            tbHisBreweryDeliveryVolume.IdBreweryDeliveryVolume = idBreweryDeliveryVolume;
            tbHisBreweryDeliveryVolume.IsSendMail = isSendMail;
            tbHisBreweryDeliveryVolume.DateSendMail = dateSendMail;
            tbHisBreweryDeliveryVolume.InsertDate = insertDate;
            tbHisBreweryDeliveryVolume.BreweryId = breweryId;
            tbHisBreweryDeliveryVolume.BreweryCode = breweryCode;
            tbHisBreweryDeliveryVolume.Year = year;
            tbHisBreweryDeliveryVolume.DeliveryVolume = deliveryVolume;
            tbHisBreweryDeliveryVolume.isActive = isActive;
            tbHisBreweryDeliveryVolume.create_user = create_user;
            tbHisBreweryDeliveryVolume.create_date = create_date;
            tbHisBreweryDeliveryVolume.mod_user = mod_user;
            tbHisBreweryDeliveryVolume.mod_date = mod_date;

            return await _tbHisBreweryDeliveryVolumeRepository.UpdateAsync(tbHisBreweryDeliveryVolume);
        }

    }
}