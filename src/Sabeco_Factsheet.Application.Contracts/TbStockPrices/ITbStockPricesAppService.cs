using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbStockPrices
{
    public partial interface ITbStockPricesAppService : IApplicationService
    {

        Task<PagedResultDto<TbStockPriceDto>> GetListAsync(GetTbStockPricesInput input);

        Task<TbStockPriceDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbStockPriceDto> CreateAsync(TbStockPriceCreateDto input);

        Task<TbStockPriceDto> UpdateAsync(int id, TbStockPriceUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbStockPriceExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbstockpriceIds);

        Task DeleteAllAsync(GetTbStockPricesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}