using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public abstract class TbLogSendEmailManagerBase : DomainService
    {
        public ITbLogSendEmailRepository _tbLogSendEmailRepository;

        public TbLogSendEmailManagerBase(ITbLogSendEmailRepository tbLogSendEmailRepository)
        {
            _tbLogSendEmailRepository = tbLogSendEmailRepository;
        }

        public virtual async Task<TbLogSendEmail> CreateAsync(
        DateTime timeSend, bool isSuccess, string? userSend = null, string? typeEmail = null, string? failedReason = null)
        {
            Check.NotNull(timeSend, nameof(timeSend));

            var tbLogSendEmail = new TbLogSendEmail(

             timeSend, isSuccess, userSend, typeEmail, failedReason
             );

            return await _tbLogSendEmailRepository.InsertAsync(tbLogSendEmail);
        }

        public virtual async Task<TbLogSendEmail> UpdateAsync(
            int id,
            DateTime timeSend, bool isSuccess, string? userSend = null, string? typeEmail = null, string? failedReason = null
        )
        {
            Check.NotNull(timeSend, nameof(timeSend));

            var tbLogSendEmail = await _tbLogSendEmailRepository.GetAsync(id);

            tbLogSendEmail.TimeSend = timeSend;
            tbLogSendEmail.IsSuccess = isSuccess;
            tbLogSendEmail.UserSend = userSend;
            tbLogSendEmail.TypeEmail = typeEmail;
            tbLogSendEmail.FailedReason = failedReason;

            return await _tbLogSendEmailRepository.UpdateAsync(tbLogSendEmail);
        }

    }
}