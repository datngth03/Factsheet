using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbLogPrintings
{
    public partial interface ITbLogPrintingRepository : IRepository<TbLogPrinting, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            DateTime? printTimeMin = null,
            DateTime? printTimeMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbLogPrinting>> GetListAsync(
                    string? filterText = null,
                    string? userName = null,
                    string? companyCode = null,
                    string? fileLanguage = null,
                    bool? isPrinting = null,
                    DateTime? printTimeMin = null,
                    DateTime? printTimeMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            DateTime? printTimeMin = null,
            DateTime? printTimeMax = null,
            CancellationToken cancellationToken = default);
    }
}