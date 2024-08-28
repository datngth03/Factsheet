using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbNationalities
{
    public abstract class TbNationalityManagerBase : DomainService
    {
        public ITbNationalityRepository _tbNationalityRepository;

        public TbNationalityManagerBase(ITbNationalityRepository tbNationalityRepository)
        {
            _tbNationalityRepository = tbNationalityRepository;
        }

        public virtual async Task<TbNationality> CreateAsync(
        string? code = null, string? code2 = null, string? name_en = null, string? name_vn = null, bool? isActive = null)
        {
            Check.Length(code, nameof(code), TbNationalityConsts.CodeMaxLength);
            Check.Length(code2, nameof(code2), TbNationalityConsts.Code2MaxLength);
            Check.Length(name_en, nameof(name_en), TbNationalityConsts.Name_enMaxLength);
            Check.Length(name_vn, nameof(name_vn), TbNationalityConsts.Name_vnMaxLength);

            var tbNationality = new TbNationality(

             code, code2, name_en, name_vn, isActive
             );

            return await _tbNationalityRepository.InsertAsync(tbNationality);
        }

        public virtual async Task<TbNationality> UpdateAsync(
            int id,
            string? code = null, string? code2 = null, string? name_en = null, string? name_vn = null, bool? isActive = null
        )
        {
            Check.Length(code, nameof(code), TbNationalityConsts.CodeMaxLength);
            Check.Length(code2, nameof(code2), TbNationalityConsts.Code2MaxLength);
            Check.Length(name_en, nameof(name_en), TbNationalityConsts.Name_enMaxLength);
            Check.Length(name_vn, nameof(name_vn), TbNationalityConsts.Name_vnMaxLength);

            var tbNationality = await _tbNationalityRepository.GetAsync(id);

            tbNationality.Code = code;
            tbNationality.Code2 = code2;
            tbNationality.Name_en = name_en;
            tbNationality.Name_vn = name_vn;
            tbNationality.IsActive = isActive;

            return await _tbNationalityRepository.UpdateAsync(tbNationality);
        }

    }
}