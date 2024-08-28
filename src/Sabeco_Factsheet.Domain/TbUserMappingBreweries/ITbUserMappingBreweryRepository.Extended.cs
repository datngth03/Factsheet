using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public partial interface ITbUserMappingBreweryRepository
    {
        //HQSOFT's generated code:
        Task<List<TbUserMappingBrewery>> GetListNoPagedAsync(
                    string? filterText = null,
                    int? useridMin = null,
                    int? useridMax = null,
                    int? breweryidMin = null,
                    int? breweryidMax = null,
                    bool? isActive = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}