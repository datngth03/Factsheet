using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbHisBrewerySkus
{
    public abstract class TbHisBrewerySkuManagerBase : DomainService
    {
        public ITbHisBrewerySkuRepository _tbHisBrewerySkuRepository;

        public TbHisBrewerySkuManagerBase(ITbHisBrewerySkuRepository tbHisBrewerySkuRepository)
        {
            _tbHisBrewerySkuRepository = tbHisBrewerySkuRepository;
        }

        public virtual async Task<TbHisBrewerySku> CreateAsync(
        int type, int idBrewerySKU, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, int? year = null, string? breweryCode = null, string? sKUCode = null, decimal? productionVolume = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? breweryId = null, int? sKUId = null)
        {
            Check.Length(breweryCode, nameof(breweryCode), TbHisBrewerySkuConsts.BreweryCodeMaxLength);
            Check.Length(sKUCode, nameof(sKUCode), TbHisBrewerySkuConsts.SKUCodeMaxLength);

            var tbHisBrewerySku = new TbHisBrewerySku(

             type, idBrewerySKU, isSendMail, dateSendMail, insertDate, year, breweryCode, sKUCode, productionVolume, docStatus, isActive, crt_date, crt_user, mod_date, mod_user, breweryId, sKUId
             );

            return await _tbHisBrewerySkuRepository.InsertAsync(tbHisBrewerySku);
        }

        public virtual async Task<TbHisBrewerySku> UpdateAsync(
            int id,
            int type, int idBrewerySKU, bool? isSendMail = null, DateTime? dateSendMail = null, DateTime? insertDate = null, int? year = null, string? breweryCode = null, string? sKUCode = null, decimal? productionVolume = null, byte? docStatus = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, int? breweryId = null, int? sKUId = null
        )
        {
            Check.Length(breweryCode, nameof(breweryCode), TbHisBrewerySkuConsts.BreweryCodeMaxLength);
            Check.Length(sKUCode, nameof(sKUCode), TbHisBrewerySkuConsts.SKUCodeMaxLength);

            var tbHisBrewerySku = await _tbHisBrewerySkuRepository.GetAsync(id);

            tbHisBrewerySku.Type = type;
            tbHisBrewerySku.IdBrewerySKU = idBrewerySKU;
            tbHisBrewerySku.IsSendMail = isSendMail;
            tbHisBrewerySku.DateSendMail = dateSendMail;
            tbHisBrewerySku.InsertDate = insertDate;
            tbHisBrewerySku.Year = year;
            tbHisBrewerySku.BreweryCode = breweryCode;
            tbHisBrewerySku.SKUCode = sKUCode;
            tbHisBrewerySku.ProductionVolume = productionVolume;
            tbHisBrewerySku.DocStatus = docStatus;
            tbHisBrewerySku.IsActive = isActive;
            tbHisBrewerySku.crt_date = crt_date;
            tbHisBrewerySku.crt_user = crt_user;
            tbHisBrewerySku.mod_date = mod_date;
            tbHisBrewerySku.mod_user = mod_user;
            tbHisBrewerySku.BreweryId = breweryId;
            tbHisBrewerySku.SKUId = sKUId;

            return await _tbHisBrewerySkuRepository.UpdateAsync(tbHisBrewerySku);
        }

    }
}