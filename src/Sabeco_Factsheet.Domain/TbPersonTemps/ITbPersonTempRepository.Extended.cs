using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbPersonTemps
{
    public partial interface ITbPersonTempRepository
    {
        //HQSOFT's generated code:
        Task<List<TbPersonTemp>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? idPersonMin = null,
                    int? idPersonMax = null,
                    string? code = null,
                    int? companyIdMin = null,
                    int? companyIdMax = null,
                    string? fullName = null,
                    DateTime? birthDateMin = null,
                    DateTime? birthDateMax = null,
                    string? birthPlace = null,
                    string? address = null,
                    string? iDCardNo = null,
                    DateTime? iDCardDateMin = null,
                    DateTime? iDCardDateMax = null,
                    string? idCardIssuePlace = null,
                    string? ethnicity = null,
                    string? religion = null,
                    string? nationalityCode = null,
                    string? gender = null,
                    string? phone = null,
                    string? email = null,
                    string? note = null,
                    string? image = null,
                    bool? isActive = null,
                    byte? docStatusMin = null,
                    byte? docStatusMax = null,
                    bool? isCheckRetirement = null,
                    bool? isCheckTermEnd = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    string? oldCode = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}