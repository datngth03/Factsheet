using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbCompanyMappings
{
    public partial interface ITbCompanyMappingRepository : IRepository<TbCompanyMapping, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyTypeShareholdingCode = null,
            string? companyTypesCode = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? idCompanyTypeShareholdingCodeMin = null,
            int? idCompanyTypeShareholdingCodeMax = null,
            int? idCompanyTypesCodeMin = null,
            int? idCompanyTypesCodeMax = null,
            CancellationToken cancellationToken = default);
        Task<List<TbCompanyMapping>> GetListAsync(
                    string? filterText = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? companyTypeShareholdingCode = null,
                    string? companyTypesCode = null,
                    string? note = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    int? idCompanyTypeShareholdingCodeMin = null,
                    int? idCompanyTypeShareholdingCodeMax = null,
                    int? idCompanyTypesCodeMin = null,
                    int? idCompanyTypesCodeMax = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            string? companyTypeShareholdingCode = null,
            string? companyTypesCode = null,
            string? note = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            int? idCompanyTypeShareholdingCodeMin = null,
            int? idCompanyTypeShareholdingCodeMax = null,
            int? idCompanyTypesCodeMin = null,
            int? idCompanyTypesCodeMax = null,
            CancellationToken cancellationToken = default);
    }
}