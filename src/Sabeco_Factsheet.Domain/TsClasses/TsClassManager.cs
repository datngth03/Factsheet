using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TsClasses
{
    public abstract class TsClassManagerBase : DomainService
    {
        public ITsClassRepository _tsClassRepository;

        public TsClassManagerBase(ITsClassRepository tsClassRepository)
        {
            _tsClassRepository = tsClassRepository;
        }

        public virtual async Task<TsClass> CreateAsync(
        string parentCode, string code, string? name = null, string? name_EN = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? code_Type = null)
        {
            Check.NotNullOrWhiteSpace(parentCode, nameof(parentCode));
            Check.Length(parentCode, nameof(parentCode), TsClassConsts.ParentCodeMaxLength);
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TsClassConsts.CodeMaxLength);
            Check.Length(name, nameof(name), TsClassConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TsClassConsts.Name_ENMaxLength);
            Check.Length(code_Type, nameof(code_Type), TsClassConsts.Code_TypeMaxLength);

            var tsClass = new TsClass(

             parentCode, code, name, name_EN, isActive, crt_date, crt_user, mod_date, mod_user, code_Type
             );

            return await _tsClassRepository.InsertAsync(tsClass);
        }

        public virtual async Task<TsClass> UpdateAsync(
            int id,
            string parentCode, string code, string? name = null, string? name_EN = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, string? code_Type = null
        )
        {
            Check.NotNullOrWhiteSpace(parentCode, nameof(parentCode));
            Check.Length(parentCode, nameof(parentCode), TsClassConsts.ParentCodeMaxLength);
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TsClassConsts.CodeMaxLength);
            Check.Length(name, nameof(name), TsClassConsts.NameMaxLength);
            Check.Length(name_EN, nameof(name_EN), TsClassConsts.Name_ENMaxLength);
            Check.Length(code_Type, nameof(code_Type), TsClassConsts.Code_TypeMaxLength);

            var tsClass = await _tsClassRepository.GetAsync(id);

            tsClass.ParentCode = parentCode;
            tsClass.Code = code;
            tsClass.Name = name;
            tsClass.Name_EN = name_EN;
            tsClass.IsActive = isActive;
            tsClass.crt_date = crt_date;
            tsClass.crt_user = crt_user;
            tsClass.mod_date = mod_date;
            tsClass.mod_user = mod_user;
            tsClass.Code_Type = code_Type;

            return await _tsClassRepository.UpdateAsync(tsClass);
        }

    }
}