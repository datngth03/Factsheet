using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public partial interface ITbHisLogPrintingRepository : IRepository<TbHisLogPrinting, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            CancellationToken cancellationToken = default);
        Task<List<TbHisLogPrinting>> GetListAsync(
                    string? filterText = null,
                    bool? isSendMail = null,
                    DateTime? dateSendMailMin = null,
                    DateTime? dateSendMailMax = null,
                    int? typeMin = null,
                    int? typeMax = null,
                    DateTime? insertDateMin = null,
                    DateTime? insertDateMax = null,
                    string? userName = null,
                    string? companyCode = null,
                    string? fileLanguage = null,
                    bool? isPrinting = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            bool? isSendMail = null,
            DateTime? dateSendMailMin = null,
            DateTime? dateSendMailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            DateTime? insertDateMin = null,
            DateTime? insertDateMax = null,
            string? userName = null,
            string? companyCode = null,
            string? fileLanguage = null,
            bool? isPrinting = null,
            CancellationToken cancellationToken = default);
    }
}