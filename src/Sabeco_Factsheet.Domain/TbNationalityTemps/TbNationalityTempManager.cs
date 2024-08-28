using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbNationalityTemps
{
    public abstract class TbNationalityTempManagerBase : DomainService
    {
        public ITbNationalityTempRepository _tbNationalityTempRepository;

        public TbNationalityTempManagerBase(ITbNationalityTempRepository tbNationalityTempRepository)
        {
            _tbNationalityTempRepository = tbNationalityTempRepository;
        }

        public virtual async Task<TbNationalityTemp> CreateAsync(
        string? code = null, string? code2 = null, string? name_en = null, string? name_vn = null, bool? isActive = null)
        {
            Check.Length(code, nameof(code), TbNationalityTempConsts.CodeMaxLength);
            Check.Length(code2, nameof(code2), TbNationalityTempConsts.Code2MaxLength);
            Check.Length(name_en, nameof(name_en), TbNationalityTempConsts.Name_enMaxLength);
            Check.Length(name_vn, nameof(name_vn), TbNationalityTempConsts.Name_vnMaxLength);

            var tbNationalityTemp = new TbNationalityTemp(

             code, code2, name_en, name_vn, isActive
             );

            return await _tbNationalityTempRepository.InsertAsync(tbNationalityTemp);
        }

        public virtual async Task<TbNationalityTemp> UpdateAsync(
            int id,
            string? code = null, string? code2 = null, string? name_en = null, string? name_vn = null, bool? isActive = null
        )
        {
            Check.Length(code, nameof(code), TbNationalityTempConsts.CodeMaxLength);
            Check.Length(code2, nameof(code2), TbNationalityTempConsts.Code2MaxLength);
            Check.Length(name_en, nameof(name_en), TbNationalityTempConsts.Name_enMaxLength);
            Check.Length(name_vn, nameof(name_vn), TbNationalityTempConsts.Name_vnMaxLength);

            var tbNationalityTemp = await _tbNationalityTempRepository.GetAsync(id);

            tbNationalityTemp.Code = code;
            tbNationalityTemp.Code2 = code2;
            tbNationalityTemp.Name_en = name_en;
            tbNationalityTemp.Name_vn = name_vn;
            tbNationalityTemp.IsActive = isActive;

            return await _tbNationalityTempRepository.UpdateAsync(tbNationalityTemp);
        }

    }
}