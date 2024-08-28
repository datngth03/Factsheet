using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public partial interface ITbHisLogPrintingRepository
    {
        //HQSOFT's generated code:
        Task<List<TbHisLogPrinting>> GetListNoPagedAsync(
                    string? filterText = null,
                    bool? isSendMail = null,
                    DateTime? dateSendMailMin = null,
                    DateTime? dateSendMailMax = null,
                    int? typeMin = null,
                    int? typeMax = null,
                    DateTime? insertDateMin = null,
                    DateTime? insertDateMax = null,
                    string? userName = null,
                    string? companyCode = null,
                    string? fileLanguage = null,
                    bool? isPrinting = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}