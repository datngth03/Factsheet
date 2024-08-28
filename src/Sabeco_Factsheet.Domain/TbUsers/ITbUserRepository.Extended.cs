using Sabeco_Factsheet.TbCompanyPersons;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbUsers
{
    public partial interface ITbUserRepository
    {
        //HQSOFT's generated code:
        Task<List<TbUser>> GetListNoPagedAsync(
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
            CancellationToken cancellationToken = default
        );


        //Write your custom code here...
        Task<List<TbUser>> GetListByAbpUserId(
                    Guid? abpUserId = null,
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
                    string? sorting = null,
                   CancellationToken cancellationToken = default
       );

        Task<TbUser?> GetByAbpUserIdAsync(Guid? userName, CancellationToken cancellationToken = default);
    }
}