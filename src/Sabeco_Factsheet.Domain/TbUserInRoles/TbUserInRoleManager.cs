using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbUserInRoles
{
    public abstract class TbUserInRoleManagerBase : DomainService
    {
        public ITbUserInRoleRepository _tbUserInRoleRepository;

        public TbUserInRoleManagerBase(ITbUserInRoleRepository tbUserInRoleRepository)
        {
            _tbUserInRoleRepository = tbUserInRoleRepository;
        }

        public virtual async Task<TbUserInRole> CreateAsync(
        int roleId, int userId, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null)
        {

            var tbUserInRole = new TbUserInRole(

             roleId, userId, isActive, crt_date, crt_user, mod_date, mod_user
             );

            return await _tbUserInRoleRepository.InsertAsync(tbUserInRole);
        }

        public virtual async Task<TbUserInRole> UpdateAsync(
            int id,
            int roleId, int userId, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null
        )
        {

            var tbUserInRole = await _tbUserInRoleRepository.GetAsync(id);

            tbUserInRole.RoleId = roleId;
            tbUserInRole.UserId = userId;
            tbUserInRole.IsActive = isActive;
            tbUserInRole.crt_date = crt_date;
            tbUserInRole.crt_user = crt_user;
            tbUserInRole.mod_date = mod_date;
            tbUserInRole.mod_user = mod_user;

            return await _tbUserInRoleRepository.UpdateAsync(tbUserInRole);
        }

    }
}