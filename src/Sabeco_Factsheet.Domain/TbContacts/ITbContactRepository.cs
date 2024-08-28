using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbContacts
{
    public partial interface ITbContactRepository : IRepository<TbContact, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            int? companyidMin = null,
            int? companyidMax = null,
            string? contactName = null,
            string? contactDept = null,
            string? contactPosition = null,
            string? contactEmail = null,
            string? contactPhone = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default);
        Task<List<TbContact>> GetListAsync(
                    string? filterText = null,
                    int? companyidMin = null,
                    int? companyidMax = null,
                    string? contactName = null,
                    string? contactDept = null,
                    string? contactPosition = null,
                    string? contactEmail = null,
                    string? contactPhone = null,
                    string? note = null,
                    byte? docStatusMin = null,
                    byte? docStatusMax = null,
                    bool? isActive = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    bool? isDeleted = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? companyidMin = null,
            int? companyidMax = null,
            string? contactName = null,
            string? contactDept = null,
            string? contactPosition = null,
            string? contactEmail = null,
            string? contactPhone = null,
            string? note = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            bool? isDeleted = null,
            CancellationToken cancellationToken = default);
    }
}