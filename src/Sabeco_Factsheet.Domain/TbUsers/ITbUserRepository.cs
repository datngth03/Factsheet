using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sabeco_Factsheet.TbUsers
{
    public partial interface ITbUserRepository : IRepository<TbUser, int>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? userPrincipalName = null,
            string? userName = null,
            string? fullName = null,
            string? email = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            Guid? abpUserId = null,
            CancellationToken cancellationToken = default);
        Task<List<TbUser>> GetListAsync(
                    string? filterText = null,
                    string? userPrincipalName = null,
                    string? userName = null,
                    string? fullName = null,
                    string? email = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    byte? docStatusMin = null,
                    byte? docStatusMax = null,
                    bool? isActive = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    Guid? abpUserId = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? userPrincipalName = null,
            string? userName = null,
            string? fullName = null,
            string? email = null,
            int? companyIdMin = null,
            int? companyIdMax = null,
            byte? docStatusMin = null,
            byte? docStatusMax = null,
            bool? isActive = null,
            DateTime? crt_dateMin = null,
            DateTime? crt_dateMax = null,
            int? crt_userMin = null,
            int? crt_userMax = null,
            DateTime? mod_dateMin = null,
            DateTime? mod_dateMax = null,
            int? mod_userMin = null,
            int? mod_userMax = null,
            Guid? abpUserId = null,
            CancellationToken cancellationToken = default);
    }
}