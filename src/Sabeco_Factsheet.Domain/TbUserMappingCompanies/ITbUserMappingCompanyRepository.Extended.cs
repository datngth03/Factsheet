using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public partial interface ITbUserMappingCompanyRepository
    {
        //HQSOFT's generated code:
        Task<List<TbUserMappingCompany>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? useridMin = null,
                    int? useridMax = null,
                    int? companyidMin = null,
                    int? companyidMax = null,
                    bool? isActive = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}