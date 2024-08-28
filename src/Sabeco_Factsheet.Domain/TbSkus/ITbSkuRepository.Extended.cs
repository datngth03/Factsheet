using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
namespace Sabeco_Factsheet.TbSkus
{
    public partial interface ITbSkuRepository
    {
        //HQSOFT's generated code:
        Task<List<TbSku>> GetListNoPagedAsync(
                    string? filterText = null,
                    string? code = null,
                    string? name = null,
                    string? name_EN = null,
                    string? brandCode = null,
                    string? unit = null,
                    string? itemBaseType = null,
                    decimal? packSizeMin = null,
                    decimal? packSizeMax = null,
                    int? packQuantityMin = null,
                    int? packQuantityMax = null,
                    decimal? weightMin = null,
                    decimal? weightMax = null,
                    int? expiryDateMin = null,
                    int? expiryDateMax = null,
                    bool? isActive = null,
                    int? crt_userMin = null,
                    int? crt_userMax = null,
                    DateTime? crt_dateMin = null,
                    DateTime? crt_dateMax = null,
                    int? mod_userMin = null,
                    int? mod_userMax = null,
                    DateTime? mod_dateMin = null,
                    DateTime? mod_dateMax = null,
                    string? sorting = null,
            CancellationToken cancellationToken = default
        );
        //Write your custom code here...
    }
}