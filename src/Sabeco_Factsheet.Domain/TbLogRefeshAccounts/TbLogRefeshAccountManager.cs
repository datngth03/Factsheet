using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public abstract class TbLogRefeshAccountManagerBase : DomainService
    {
        public ITbLogRefeshAccountRepository _tbLogRefeshAccountRepository;

        public TbLogRefeshAccountManagerBase(ITbLogRefeshAccountRepository tbLogRefeshAccountRepository)
        {
            _tbLogRefeshAccountRepository = tbLogRefeshAccountRepository;
        }

        public virtual async Task<TbLogRefeshAccount> CreateAsync(
        string accessToken, DateTime timeRefesh, bool isSuccess, string? useRefesh = null, string? failedReason = null)
        {
            Check.NotNullOrWhiteSpace(accessToken, nameof(accessToken));
            Check.NotNull(timeRefesh, nameof(timeRefesh));

            var tbLogRefeshAccount = new TbLogRefeshAccount(

             accessToken, timeRefesh, isSuccess, useRefesh, failedReason
             );

            return await _tbLogRefeshAccountRepository.InsertAsync(tbLogRefeshAccount);
        }

        public virtual async Task<TbLogRefeshAccount> UpdateAsync(
            int id,
            string accessToken, DateTime timeRefesh, bool isSuccess, string? useRefesh = null, string? failedReason = null
        )
        {
            Check.NotNullOrWhiteSpace(accessToken, nameof(accessToken));
            Check.NotNull(timeRefesh, nameof(timeRefesh));

            var tbLogRefeshAccount = await _tbLogRefeshAccountRepository.GetAsync(id);

            tbLogRefeshAccount.AccessToken = accessToken;
            tbLogRefeshAccount.TimeRefesh = timeRefesh;
            tbLogRefeshAccount.IsSuccess = isSuccess;
            tbLogRefeshAccount.UseRefesh = useRefesh;
            tbLogRefeshAccount.FailedReason = failedReason;

            return await _tbLogRefeshAccountRepository.UpdateAsync(tbLogRefeshAccount);
        }

    }
}