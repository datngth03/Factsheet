using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbLogExportDatas
{
    public partial interface ITbLogExportDataRepository : IRepository<TbLogExportData, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            DateTime? timeExportMin = null,
            DateTime? timeExportMax = null,
            bool? isSuccess = null,
            int? userExportMin = null,
            int? userExportMax = null,
            string? tableName = null,
            string? reasonExportFailed = null,
            CancellationToken cancellationToken = default);
        Task<List<TbLogExportData>> GetListAsync(
                    string? filterText = null,
                    DateTime? timeExportMin = null,
                    DateTime? timeExportMax = null,
                    bool? isSuccess = null,
                    int? userExportMin = null,
                    int? userExportMax = null,
                    string? tableName = null,
                    string? reasonExportFailed = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            DateTime? timeExportMin = null,
            DateTime? timeExportMax = null,
            bool? isSuccess = null,
            int? userExportMin = null,
            int? userExportMax = null,
            string? tableName = null,
            string? reasonExportFailed = null,
            CancellationToken cancellationToken = default);
    }
}