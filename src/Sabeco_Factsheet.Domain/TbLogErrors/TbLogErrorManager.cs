using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbLogErrors
{
    public abstract class TbLogErrorManagerBase : DomainService
    {
        public ITbLogErrorRepository _tbLogErrorRepository;

        public TbLogErrorManagerBase(ITbLogErrorRepository tbLogErrorRepository)
        {
            _tbLogErrorRepository = tbLogErrorRepository;
        }

        public virtual async Task<TbLogError> CreateAsync(
        DateTime timeLog, int userLog, string functionLog, string reasonFailed, string? iPAddress = null, string? classLog = null)
        {
            Check.NotNull(timeLog, nameof(timeLog));
            Check.NotNullOrWhiteSpace(functionLog, nameof(functionLog));
            Check.NotNullOrWhiteSpace(reasonFailed, nameof(reasonFailed));

            var tbLogError = new TbLogError(

             timeLog, userLog, functionLog, reasonFailed, iPAddress, classLog
             );

            return await _tbLogErrorRepository.InsertAsync(tbLogError);
        }

        public virtual async Task<TbLogError> UpdateAsync(
            int id,
            DateTime timeLog, int userLog, string functionLog, string reasonFailed, string? iPAddress = null, string? classLog = null
        )
        {
            Check.NotNull(timeLog, nameof(timeLog));
            Check.NotNullOrWhiteSpace(functionLog, nameof(functionLog));
            Check.NotNullOrWhiteSpace(reasonFailed, nameof(reasonFailed));

            var tbLogError = await _tbLogErrorRepository.GetAsync(id);

            tbLogError.TimeLog = timeLog;
            tbLogError.UserLog = userLog;
            tbLogError.FunctionLog = functionLog;
            tbLogError.ReasonFailed = reasonFailed;
            tbLogError.IPAddress = iPAddress;
            tbLogError.ClassLog = classLog;

            return await _tbLogErrorRepository.UpdateAsync(tbLogError);
        }

    }
}