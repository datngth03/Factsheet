using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public partial interface ITbLogSendEmailRetirementRepository : IRepository<TbLogSendEmailRetirement, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? idPersonMin = null,
            int? idPersonMax = null,
            bool? isSendEmail = null,
            DateTime? dateSendEmailMin = null,
            DateTime? dateSendEmailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbLogSendEmailRetirement>> GetListAsync(
                    string? filterText = null,
                    int? idCompanyMin = null,
                    int? idCompanyMax = null,
                    int? idPersonMin = null,
                    int? idPersonMax = null,
                    bool? isSendEmail = null,
                    DateTime? dateSendEmailMin = null,
                    DateTime? dateSendEmailMax = null,
                    int? typeMin = null,
                    int? typeMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? idCompanyMin = null,
            int? idCompanyMax = null,
            int? idPersonMin = null,
            int? idPersonMax = null,
            bool? isSendEmail = null,
            DateTime? dateSendEmailMin = null,
            DateTime? dateSendEmailMax = null,
            int? typeMin = null,
            int? typeMax = null,
            CancellationToken cancellationToken = default);
    }
}