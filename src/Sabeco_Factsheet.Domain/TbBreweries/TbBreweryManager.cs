using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbBreweries
{
    public abstract class TbBreweryManagerBase : DomainService
    {
        public ITbBreweryRepository _tbBreweryRepository;

        public TbBreweryManagerBase(ITbBreweryRepository tbBreweryRepository)
        {
            _tbBreweryRepository = tbBreweryRepository;
        }

        public virtual async Task<TbBrewery> CreateAsync(
        string breweryCode, string breweryName, int companyId, string? breweryName_EN = null, string? briefName = null, string? breweryAdress = null, decimal? capacityVolume = null, decimal? deliveryVolume = null, string? note = null, byte? docStatus = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.NotNullOrWhiteSpace(breweryCode, nameof(breweryCode));
            Check.Length(breweryCode, nameof(breweryCode), TbBreweryConsts.BreweryCodeMaxLength);
            Check.NotNullOrWhiteSpace(breweryName, nameof(breweryName));
            Check.Length(breweryName, nameof(breweryName), TbBreweryConsts.BreweryNameMaxLength);
            Check.Length(breweryName_EN, nameof(breweryName_EN), TbBreweryConsts.BreweryName_ENMaxLength);

            var tbBrewery = new TbBrewery(

             breweryCode, breweryName, companyId, breweryName_EN, briefName, breweryAdress, capacityVolume, deliveryVolume, note, docStatus, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbBreweryRepository.InsertAsync(tbBrewery);
        }

        public virtual async Task<TbBrewery> UpdateAsync(
            int id,
            string breweryCode, string breweryName, int companyId, string? breweryName_EN = null, string? briefName = null, string? breweryAdress = null, decimal? capacityVolume = null, decimal? deliveryVolume = null, string? note = null, byte? docStatus = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.NotNullOrWhiteSpace(breweryCode, nameof(breweryCode));
            Check.Length(breweryCode, nameof(breweryCode), TbBreweryConsts.BreweryCodeMaxLength);
            Check.NotNullOrWhiteSpace(breweryName, nameof(breweryName));
            Check.Length(breweryName, nameof(breweryName), TbBreweryConsts.BreweryNameMaxLength);
            Check.Length(breweryName_EN, nameof(breweryName_EN), TbBreweryConsts.BreweryName_ENMaxLength);

            var tbBrewery = await _tbBreweryRepository.GetAsync(id);

            tbBrewery.BreweryCode = breweryCode;
            tbBrewery.BreweryName = breweryName;
            tbBrewery.CompanyId = companyId;
            tbBrewery.BreweryName_EN = breweryName_EN;
            tbBrewery.BriefName = briefName;
            tbBrewery.BreweryAdress = breweryAdress;
            tbBrewery.CapacityVolume = capacityVolume;
            tbBrewery.DeliveryVolume = deliveryVolume;
            tbBrewery.Note = note;
            tbBrewery.DocStatus = docStatus;
            tbBrewery.isActive = isActive;
            tbBrewery.create_user = create_user;
            tbBrewery.create_date = create_date;
            tbBrewery.mod_user = mod_user;
            tbBrewery.mod_date = mod_date;

            return await _tbBreweryRepository.UpdateAsync(tbBrewery);
        }

    }
}