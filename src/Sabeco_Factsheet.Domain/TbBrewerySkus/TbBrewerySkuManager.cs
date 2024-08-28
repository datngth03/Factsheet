using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbBrewerySkus
{
    public abstract class TbBrewerySkuManagerBase : DomainService
    {
        public ITbBrewerySkuRepository _tbBrewerySkuRepository;

        public TbBrewerySkuManagerBase(ITbBrewerySkuRepository tbBrewerySkuRepository)
        {
            _tbBrewerySkuRepository = tbBrewerySkuRepository;
        }

        public virtual async Task<TbBrewerySku> CreateAsync(
        int? year = null, string? breweryCode = null, string? sKUCode = null, decimal? productionVolume = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? breweryId = null, int? sKUId = null)
        {
            Check.Length(breweryCode, nameof(breweryCode), TbBrewerySkuConsts.BreweryCodeMaxLength);
            Check.Length(sKUCode, nameof(sKUCode), TbBrewerySkuConsts.SKUCodeMaxLength);

            var tbBrewerySku = new TbBrewerySku(

             year, breweryCode, sKUCode, productionVolume, docStatus, isActive, crt_date, crt_user, mod_date, mod_user, breweryId, sKUId
             );

            return await _tbBrewerySkuRepository.InsertAsync(tbBrewerySku);
        }

        public virtual async Task<TbBrewerySku> UpdateAsync(
            int id,
            int? year = null, string? breweryCode = null, string? sKUCode = null, decimal? productionVolume = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? breweryId = null, int? sKUId = null
        )
        {
            Check.Length(breweryCode, nameof(breweryCode), TbBrewerySkuConsts.BreweryCodeMaxLength);
            Check.Length(sKUCode, nameof(sKUCode), TbBrewerySkuConsts.SKUCodeMaxLength);

            var tbBrewerySku = await _tbBrewerySkuRepository.GetAsync(id);

            tbBrewerySku.Year = year;
            tbBrewerySku.BreweryCode = breweryCode;
            tbBrewerySku.SKUCode = sKUCode;
            tbBrewerySku.ProductionVolume = productionVolume;
            tbBrewerySku.DocStatus = docStatus;
            tbBrewerySku.IsActive = isActive;
            tbBrewerySku.crt_date = crt_date;
            tbBrewerySku.crt_user = crt_user;
            tbBrewerySku.mod_date = mod_date;
            tbBrewerySku.mod_user = mod_user;
            tbBrewerySku.BreweryId = breweryId;
            tbBrewerySku.SKUId = sKUId;

            return await _tbBrewerySkuRepository.UpdateAsync(tbBrewerySku);
        }

    }
}