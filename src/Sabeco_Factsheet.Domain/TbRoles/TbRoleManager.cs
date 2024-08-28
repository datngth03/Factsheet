using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbRoles
{
    public abstract class TbRoleManagerBase : DomainService
    {
        public ITbRoleRepository _tbRoleRepository;

        public TbRoleManagerBase(ITbRoleRepository tbRoleRepository)
        {
            _tbRoleRepository = tbRoleRepository;
        }

        public virtual async Task<TbRole> CreateAsync(
        string code, string name, string? description = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbRoleConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbRoleConsts.NameMaxLength);
            Check.Length(description, nameof(description), TbRoleConsts.DescriptionMaxLength);

            var tbRole = new TbRole(

             code, name, description, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbRoleRepository.InsertAsync(tbRole);
        }

        public virtual async Task<TbRole> UpdateAsync(
            int id,
            string code, string name, string? description = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), TbRoleConsts.CodeMaxLength);
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TbRoleConsts.NameMaxLength);
            Check.Length(description, nameof(description), TbRoleConsts.DescriptionMaxLength);

            var tbRole = await _tbRoleRepository.GetAsync(id);

            tbRole.Code = code;
            tbRole.Name = name;
            tbRole.Description = description;
            tbRole.IsActive = isActive;
            tbRole.crt_date = crt_date;
            tbRole.crt_user = crt_user;
            tbRole.mod_date = mod_date;
            tbRole.mod_user = mod_user;

            return await _tbRoleRepository.UpdateAsync(tbRole);
        }

    }
}