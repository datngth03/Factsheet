using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbBrewerySkuTemps
{
    public abstract class TbBrewerySkuTempManagerBase : DomainService
    {
        public ITbBrewerySkuTempRepository _tbBrewerySkuTempRepository;

        public TbBrewerySkuTempManagerBase(ITbBrewerySkuTempRepository tbBrewerySkuTempRepository)
        {
            _tbBrewerySkuTempRepository = tbBrewerySkuTempRepository;
        }

        public virtual async Task<TbBrewerySkuTemp> CreateAsync(
        int? idBrewerySKU = null, int? year = null, string? breweryCode = null, string? sKUCode = null, decimal? productionVolume = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? breweryId = null, int? sKUId = null)
        {
            Check.Length(breweryCode, nameof(breweryCode), TbBrewerySkuTempConsts.BreweryCodeMaxLength);
            Check.Length(sKUCode, nameof(sKUCode), TbBrewerySkuTempConsts.SKUCodeMaxLength);

            var tbBrewerySkuTemp = new TbBrewerySkuTemp(

             idBrewerySKU, year, breweryCode, sKUCode, productionVolume, docStatus, isActive, crt_date, crt_user, mod_date, mod_user, breweryId, sKUId
             );

            return await _tbBrewerySkuTempRepository.InsertAsync(tbBrewerySkuTemp);
        }

        public virtual async Task<TbBrewerySkuTemp> UpdateAsync(
            int id,
            int? idBrewerySKU = null, int? year = null, string? breweryCode = null, string? sKUCode = null, decimal? productionVolume = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? breweryId = null, int? sKUId = null
        )
        {
            Check.Length(breweryCode, nameof(breweryCode), TbBrewerySkuTempConsts.BreweryCodeMaxLength);
            Check.Length(sKUCode, nameof(sKUCode), TbBrewerySkuTempConsts.SKUCodeMaxLength);

            var tbBrewerySkuTemp = await _tbBrewerySkuTempRepository.GetAsync(id);

            tbBrewerySkuTemp.idBrewerySKU = idBrewerySKU;
            tbBrewerySkuTemp.Year = year;
            tbBrewerySkuTemp.BreweryCode = breweryCode;
            tbBrewerySkuTemp.SKUCode = sKUCode;
            tbBrewerySkuTemp.ProductionVolume = productionVolume;
            tbBrewerySkuTemp.DocStatus = docStatus;
            tbBrewerySkuTemp.IsActive = isActive;
            tbBrewerySkuTemp.crt_date = crt_date;
            tbBrewerySkuTemp.crt_user = crt_user;
            tbBrewerySkuTemp.mod_date = mod_date;
            tbBrewerySkuTemp.mod_user = mod_user;
            tbBrewerySkuTemp.BreweryId = breweryId;
            tbBrewerySkuTemp.SKUId = sKUId;

            return await _tbBrewerySkuTempRepository.UpdateAsync(tbBrewerySkuTemp);
        }

    }
}