using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public partial interface ITbUserMappingPersonRepository
    {
        //HQSOFT's generated code:
        Task<List<TbUserMappingPerson>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? useridMin = null,
                    int? useridMax = null,
                    int? personidMin = null,
                    int? personidMax = null,
                    bool? isActive = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}