using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TsClassTemps
{
    public abstract class TsClassTempManagerBase : DomainService
    {
        public ITsClassTempRepository _tsClassTempRepository;

        public TsClassTempManagerBase(ITsClassTempRepository tsClassTempRepository)
        {
            _tsClassTempRepository = tsClassTempRepository;
        }

        public virtual async Task<TsClassTemp> CreateAsync(
        string parentCode, string code, string? name = null, string? name_EN = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? code_Type = null)
        {
            Check.NotNullOrWhiteSpace(parentCode, nameof(parentCode));
            Check.Length(parentCode, nameof(parentCode), TsClassTempConsts.ParentCodeMaxLength);
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TsClassTempConsts.CodeMaxLength);
            Check.Length(name, nameof(name), TsClassTempConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TsClassTempConsts.Name_ENMaxLength);
            Check.Length(code_Type, nameof(code_Type), TsClassTempConsts.Code_TypeMaxLength);

            var tsClassTemp = new TsClassTemp(

             parentCode, code, name, name_EN, isActive, crt_date, crt_user, mod_date, mod_user, code_Type
             );

            return await _tsClassTempRepository.InsertAsync(tsClassTemp);
        }

        public virtual async Task<TsClassTemp> UpdateAsync(
            int id,
            string parentCode, string code, string? name = null, string? name_EN = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? code_Type = null
        )
        {
            Check.NotNullOrWhiteSpace(parentCode, nameof(parentCode));
            Check.Length(parentCode, nameof(parentCode), TsClassTempConsts.ParentCodeMaxLength);
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TsClassTempConsts.CodeMaxLength);
            Check.Length(name, nameof(name), TsClassTempConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TsClassTempConsts.Name_ENMaxLength);
            Check.Length(code_Type, nameof(code_Type), TsClassTempConsts.Code_TypeMaxLength);

            var tsClassTemp = await _tsClassTempRepository.GetAsync(id);

            tsClassTemp.ParentCode = parentCode;
            tsClassTemp.Code = code;
            tsClassTemp.Name = name;
            tsClassTemp.Name_EN = name_EN;
            tsClassTemp.IsActive = isActive;
            tsClassTemp.crt_date = crt_date;
            tsClassTemp.crt_user = crt_user;
            tsClassTemp.mod_date = mod_date;
            tsClassTemp.mod_user = mod_user;
            tsClassTemp.Code_Type = code_Type;

            return await _tsClassTempRepository.UpdateAsync(tsClassTemp);
        }

    }
}