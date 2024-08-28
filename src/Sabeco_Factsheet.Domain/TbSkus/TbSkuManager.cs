using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbSkus
{
    public abstract class TbSkuManagerBase : DomainService
    {
        public ITbSkuRepository _tbSkuRepository;

        public TbSkuManagerBase(ITbSkuRepository tbSkuRepository)
        {
            _tbSkuRepository = tbSkuRepository;
        }

        public virtual async Task<TbSku> CreateAsync(
        string? code = null, string? name = null, string? name_EN = null, string? brandCode = null, string? unit = null, string? itemBaseType = null, decimal? packSize = null, int? packQuantity = null, decimal? weight = null, int? expiryDate = null, bool? isActive = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null)
        {
            Check.Length(code, nameof(code), TbSkuConsts.CodeMaxLength);
            Check.Length(name, nameof(name), TbSkuConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TbSkuConsts.Name_ENMaxLength);
            Check.Length(brandCode, nameof(brandCode), TbSkuConsts.BrandCodeMaxLength);
            Check.Length(unit, nameof(unit), TbSkuConsts.UnitMaxLength);
            Check.Length(itemBaseType, nameof(itemBaseType), TbSkuConsts.ItemBaseTypeMaxLength);

            var tbSku = new TbSku(

             code, name, name_EN, brandCode, unit, itemBaseType, packSize, packQuantity, weight, expiryDate, isActive, crt_user, crt_date, mod_user, mod_date
             );

            return await _tbSkuRepository.InsertAsync(tbSku);
        }

        public virtual async Task<TbSku> UpdateAsync(
            int id,
            string? code = null, string? name = null, string? name_EN = null, string? brandCode = null, string? unit = null, string? itemBaseType = null, decimal? packSize = null, int? packQuantity = null, decimal? weight = null, int? expiryDate = null, bool? isActive = null, int? crt_user = null, DateTime? crt_date = null, int? mod_user = null, DateTime? mod_date = null
        )
        {
            Check.Length(code, nameof(code), TbSkuConsts.CodeMaxLength);
            Check.Length(name, nameof(name), TbSkuConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TbSkuConsts.Name_ENMaxLength);
            Check.Length(brandCode, nameof(brandCode), TbSkuConsts.BrandCodeMaxLength);
            Check.Length(unit, nameof(unit), TbSkuConsts.UnitMaxLength);
            Check.Length(itemBaseType, nameof(itemBaseType), TbSkuConsts.ItemBaseTypeMaxLength);

            var tbSku = await _tbSkuRepository.GetAsync(id);

            tbSku.Code = code;
            tbSku.Name = name;
            tbSku.Name_EN = name_EN;
            tbSku.BrandCode = brandCode;
            tbSku.Unit = unit;
            tbSku.ItemBaseType = itemBaseType;
            tbSku.PackSize = packSize;
            tbSku.PackQuantity = packQuantity;
            tbSku.Weight = weight;
            tbSku.ExpiryDate = expiryDate;
            tbSku.IsActive = isActive;
            tbSku.crt_user = crt_user;
            tbSku.crt_date = crt_date;
            tbSku.mod_user = mod_user;
            tbSku.mod_date = mod_date;

            return await _tbSkuRepository.UpdateAsync(tbSku);
        }

    }
}