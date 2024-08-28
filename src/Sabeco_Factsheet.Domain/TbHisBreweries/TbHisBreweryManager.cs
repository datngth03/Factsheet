using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbHisBreweries
{
    public abstract class TbHisBreweryManagerBase : DomainService
    {
        public ITbHisBreweryRepository _tbHisBreweryRepository;

        public TbHisBreweryManagerBase(ITbHisBreweryRepository tbHisBreweryRepository)
        {
            _tbHisBreweryRepository = tbHisBreweryRepository;
        }

        public virtual async Task<TbHisBrewery> CreateAsync(
        DateTime insertDate, int type, int idBrewery, string breweryName, int companyId, bool? isSendMail = null, DateTime? dateSendMail = null, string? breweryName_EN = null, string? breweryAdress = null, string? briefName = null, decimal? capacityVolume = null, decimal? deliveryVolume = null, string? note = null, byte? docStatus = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.NotNull(insertDate, nameof(insertDate));
            Check.NotNullOrWhiteSpace(breweryName, nameof(breweryName));
            Check.Length(breweryName, nameof(breweryName), TbHisBreweryConsts.BreweryNameMaxLength);
            Check.Length(breweryName_EN, nameof(breweryName_EN), TbHisBreweryConsts.BreweryName_ENMaxLength);

            var tbHisBrewery = new TbHisBrewery(

             insertDate, type, idBrewery, breweryName, companyId, isSendMail, dateSendMail, breweryName_EN, breweryAdress, briefName, capacityVolume, deliveryVolume, note, docStatus, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbHisBreweryRepository.InsertAsync(tbHisBrewery);
        }

        public virtual async Task<TbHisBrewery> UpdateAsync(
            int id,
            DateTime insertDate, int type, int idBrewery, string breweryName, int companyId, bool? isSendMail = null, DateTime? dateSendMail = null, string? breweryName_EN = null, string? breweryAdress = null, string? briefName = null, decimal? capacityVolume = null, decimal? deliveryVolume = null, string? note = null, byte? docStatus = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.NotNull(insertDate, nameof(insertDate));
            Check.NotNullOrWhiteSpace(breweryName, nameof(breweryName));
            Check.Length(breweryName, nameof(breweryName), TbHisBreweryConsts.BreweryNameMaxLength);
            Check.Length(breweryName_EN, nameof(breweryName_EN), TbHisBreweryConsts.BreweryName_ENMaxLength);

            var tbHisBrewery = await _tbHisBreweryRepository.GetAsync(id);

            tbHisBrewery.InsertDate = insertDate;
            tbHisBrewery.Type = type;
            tbHisBrewery.IdBrewery = idBrewery;
            tbHisBrewery.BreweryName = breweryName;
            tbHisBrewery.CompanyId = companyId;
            tbHisBrewery.IsSendMail = isSendMail;
            tbHisBrewery.DateSendMail = dateSendMail;
            tbHisBrewery.BreweryName_EN = breweryName_EN;
            tbHisBrewery.BreweryAdress = breweryAdress;
            tbHisBrewery.BriefName = briefName;
            tbHisBrewery.CapacityVolume = capacityVolume;
            tbHisBrewery.DeliveryVolume = deliveryVolume;
            tbHisBrewery.Note = note;
            tbHisBrewery.DocStatus = docStatus;
            tbHisBrewery.IsActive = isActive;
            tbHisBrewery.create_user = create_user;
            tbHisBrewery.create_date = create_date;
            tbHisBrewery.mod_user = mod_user;
            tbHisBrewery.mod_date = mod_date;

            return await _tbHisBreweryRepository.UpdateAsync(tbHisBrewery);
        }

    }
}