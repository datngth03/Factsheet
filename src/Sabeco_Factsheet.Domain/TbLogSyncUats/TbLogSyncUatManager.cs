using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbLogSyncUats
{
    public abstract class TbLogSyncUatManagerBase : DomainService
    {
        public ITbLogSyncUatRepository _tbLogSyncUatRepository;

        public TbLogSyncUatManagerBase(ITbLogSyncUatRepository tbLogSyncUatRepository)
        {
            _tbLogSyncUatRepository = tbLogSyncUatRepository;
        }

        public virtual async Task<TbLogSyncUat> CreateAsync(
        DateTime timeExport, bool isSuccess, int userExport, string? reasonExportFailed = null)
        {
            Check.NotNull(timeExport, nameof(timeExport));

            var tbLogSyncUat = new TbLogSyncUat(

             timeExport, isSuccess, userExport, reasonExportFailed
             );

            return await _tbLogSyncUatRepository.InsertAsync(tbLogSyncUat);
        }

        public virtual async Task<TbLogSyncUat> UpdateAsync(
            int id,
            DateTime timeExport, bool isSuccess, int userExport, string? reasonExportFailed = null
        )
        {
            Check.NotNull(timeExport, nameof(timeExport));

            var tbLogSyncUat = await _tbLogSyncUatRepository.GetAsync(id);

            tbLogSyncUat.TimeExport = timeExport;
            tbLogSyncUat.IsSuccess = isSuccess;
            tbLogSyncUat.UserExport = userExport;
            tbLogSyncUat.ReasonExportFailed = reasonExportFailed;

            return await _tbLogSyncUatRepository.UpdateAsync(tbLogSyncUat);
        }

    }
}