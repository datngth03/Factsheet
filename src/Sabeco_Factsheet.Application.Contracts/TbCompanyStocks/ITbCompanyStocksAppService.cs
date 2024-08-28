using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyStocks
{
    public partial interface ITbCompanyStocksAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyStockDto>> GetListAsync(GetTbCompanyStocksInput input);

        Task<TbCompanyStockDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyStockDto> CreateAsync(TbCompanyStockCreateDto input);

        Task<TbCompanyStockDto> UpdateAsync(int id, TbCompanyStockUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyStockExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanystockIds);

        Task DeleteAllAsync(GetTbCompanyStocksInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}