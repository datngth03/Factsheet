using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Sabeco_Factsheet.TbLogExportDatas
{
    public abstract class TbLogExportDataManagerBase : DomainService
    {
        public ITbLogExportDataRepository _tbLogExportDataRepository;

        public TbLogExportDataManagerBase(ITbLogExportDataRepository tbLogExportDataRepository)
        {
            _tbLogExportDataRepository = tbLogExportDataRepository;
        }

        public virtual async Task<TbLogExportData> CreateAsync(
        DateTime timeExport, bool isSuccess, int userExport, string? tableName = null, string? reasonExportFailed = null)
        {
            Check.NotNull(timeExport, nameof(timeExport));

            var tbLogExportData = new TbLogExportData(

             timeExport, isSuccess, userExport, tableName, reasonExportFailed
             );

            return await _tbLogExportDataRepository.InsertAsync(tbLogExportData);
        }

        public virtual async Task<TbLogExportData> UpdateAsync(
            int id,
            DateTime timeExport, bool isSuccess, int userExport, string? tableName = null, string? reasonExportFailed = null
        )
        {
            Check.NotNull(timeExport, nameof(timeExport));

            var tbLogExportData = await _tbLogExportDataRepository.GetAsync(id);

            tbLogExportData.TimeExport = timeExport;
            tbLogExportData.IsSuccess = isSuccess;
            tbLogExportData.UserExport = userExport;
            tbLogExportData.TableName = tableName;
            tbLogExportData.ReasonExportFailed = reasonExportFailed;

            return await _tbLogExportDataRepository.UpdateAsync(tbLogExportData);
        }

    }
}