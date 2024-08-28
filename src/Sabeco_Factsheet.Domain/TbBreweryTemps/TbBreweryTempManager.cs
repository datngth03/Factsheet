using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbBreweryTemps
{
    public abstract class TbBreweryTempManagerBase : DomainService
    {
        public ITbBreweryTempRepository _tbBreweryTempRepository;

        public TbBreweryTempManagerBase(ITbBreweryTempRepository tbBreweryTempRepository)
        {
            _tbBreweryTempRepository = tbBreweryTempRepository;
        }

        public virtual async Task<TbBreweryTemp> CreateAsync(
        int idBrewery, string breweryCode, string breweryName, int companyId, string? breweryName_EN = null, string? briefName = null, string? breweryAdress = null, decimal? capacityVolume = null, decimal? deliveryVolume = null, string? note = null, byte? docStatus = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.NotNullOrWhiteSpace(breweryCode, nameof(breweryCode));
            Check.Length(breweryCode, nameof(breweryCode), TbBreweryTempConsts.BreweryCodeMaxLength);
            Check.NotNullOrWhiteSpace(breweryName, nameof(breweryName));
            Check.Length(breweryName, nameof(breweryName), TbBreweryTempConsts.BreweryNameMaxLength);
            Check.Length(breweryName_EN, nameof(breweryName_EN), TbBreweryTempConsts.BreweryName_ENMaxLength);

            var tbBreweryTemp = new TbBreweryTemp(

             idBrewery, breweryCode, breweryName, companyId, breweryName_EN, briefName, breweryAdress, capacityVolume, deliveryVolume, note, docStatus, isActive, create_user, create_date, mod_user, mod_date
             );

            return await _tbBreweryTempRepository.InsertAsync(tbBreweryTemp);
        }

        public virtual async Task<TbBreweryTemp> UpdateAsync(
            int id,
            int idBrewery, string breweryCode, string breweryName, int companyId, string? breweryName_EN = null, string? briefName = null, string? breweryAdress = null, decimal? capacityVolume = null, decimal? deliveryVolume = null, string? note = null, byte? docStatus = null, bool? isActive = null, int? create_user = null, DateTime? create_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.NotNullOrWhiteSpace(breweryCode, nameof(breweryCode));
            Check.Length(breweryCode, nameof(breweryCode), TbBreweryTempConsts.BreweryCodeMaxLength);
            Check.NotNullOrWhiteSpace(breweryName, nameof(breweryName));
            Check.Length(breweryName, nameof(breweryName), TbBreweryTempConsts.BreweryNameMaxLength);
            Check.Length(breweryName_EN, nameof(breweryName_EN), TbBreweryTempConsts.BreweryName_ENMaxLength);

            var tbBreweryTemp = await _tbBreweryTempRepository.GetAsync(id);

            tbBreweryTemp.idBrewery = idBrewery;
            tbBreweryTemp.BreweryCode = breweryCode;
            tbBreweryTemp.BreweryName = breweryName;
            tbBreweryTemp.CompanyId = companyId;
            tbBreweryTemp.BreweryName_EN = breweryName_EN;
            tbBreweryTemp.BriefName = briefName;
            tbBreweryTemp.BreweryAdress = breweryAdress;
            tbBreweryTemp.CapacityVolume = capacityVolume;
            tbBreweryTemp.DeliveryVolume = deliveryVolume;
            tbBreweryTemp.Note = note;
            tbBreweryTemp.DocStatus = docStatus;
            tbBreweryTemp.isActive = isActive;
            tbBreweryTemp.create_user = create_user;
            tbBreweryTemp.create_date = create_date;
            tbBreweryTemp.mod_user = mod_user;
            tbBreweryTemp.mod_date = mod_date;

            return await _tbBreweryTempRepository.UpdateAsync(tbBreweryTemp);
        }

    }
}