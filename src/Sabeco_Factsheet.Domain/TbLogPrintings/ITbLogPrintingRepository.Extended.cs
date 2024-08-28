using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbLogPrintings
{
    public partial interface ITbLogPrintingRepository
    {
        //HQSOFT's generated code:
        Task<List<TbLogPrinting>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? userName = null,
                    string? companyCode = null,
                    string? fileLanguage = null,
                    bool? isPrinting = null,
                    DateTime? printTimeMin = null,
                    DateTime? printTimeMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}