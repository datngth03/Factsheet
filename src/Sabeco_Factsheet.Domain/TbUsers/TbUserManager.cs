using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbUsers
{
    public abstract class TbUserManagerBase : DomainService
    {
        public ITbUserRepository _tbUserRepository;

        public TbUserManagerBase(ITbUserRepository tbUserRepository)
        {
            _tbUserRepository = tbUserRepository;
        }

        public virtual async Task<TbUser> CreateAsync(
        string userPrincipalName, string userName, string fullName, bool isActive, string? email = null, int? companyId = null, byte? docStatus = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, Guid? abpUserId = null)
        {
            Check.NotNullOrWhiteSpace(userPrincipalName, nameof(userPrincipalName));
            Check.Length(userPrincipalName, nameof(userPrincipalName), TbUserConsts.UserPrincipalNameMaxLength);
            Check.NotNullOrWhiteSpace(userName, nameof(userName));
            Check.Length(userName, nameof(userName), TbUserConsts.UserNameMaxLength);
            Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            Check.Length(fullName, nameof(fullName), TbUserConsts.FullNameMaxLength);
            Check.Length(email, nameof(email), TbUserConsts.EmailMaxLength);

            var tbUser = new TbUser(

             userPrincipalName, userName, fullName, isActive, email, companyId, docStatus, crt_date, crt_user, mod_date, mod_user, abpUserId
             );

            return await _tbUserRepository.InsertAsync(tbUser);
        }

        public virtual async Task<TbUser> UpdateAsync(
            int id,
            string userPrincipalName, string userName, string fullName, bool isActive, string? email = null, int? companyId = null, byte? docStatus = null, DateTime? crt_date = null, int? crt_user = null, DateTime? mod_date = null, int? mod_user = null, Guid? abpUserId = null
        )
        {
            Check.NotNullOrWhiteSpace(userPrincipalName, nameof(userPrincipalName));
            Check.Length(userPrincipalName, nameof(userPrincipalName), TbUserConsts.UserPrincipalNameMaxLength);
            Check.NotNullOrWhiteSpace(userName, nameof(userName));
            Check.Length(userName, nameof(userName), TbUserConsts.UserNameMaxLength);
            Check.NotNullOrWhiteSpace(fullName, nameof(fullName));
            Check.Length(fullName, nameof(fullName), TbUserConsts.FullNameMaxLength);
            Check.Length(email, nameof(email), TbUserConsts.EmailMaxLength);

            var tbUser = await _tbUserRepository.GetAsync(id);

            tbUser.UserPrincipalName = userPrincipalName;
            tbUser.UserName = userName;
            tbUser.FullName = fullName;
            tbUser.IsActive = isActive;
            tbUser.Email = email;
            tbUser.CompanyId = companyId;
            tbUser.DocStatus = docStatus;
            tbUser.crt_date = crt_date;
            tbUser.crt_user = crt_user;
            tbUser.mod_date = mod_date;
            tbUser.mod_user = mod_user;
            tbUser.AbpUserId = abpUserId;

            return await _tbUserRepository.UpdateAsync(tbUser);
        }

    }
}