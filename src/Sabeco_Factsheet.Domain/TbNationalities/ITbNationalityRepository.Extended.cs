using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbNationalities
{
    public partial interface ITbNationalityRepository
    {
        //HQSOFT's generated code:
        Task<List<TbNationality>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? code = null,
                    string? code2 = null,
                    string? name_en = null,
                    string? name_vn = null,
                    bool? isActive = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}