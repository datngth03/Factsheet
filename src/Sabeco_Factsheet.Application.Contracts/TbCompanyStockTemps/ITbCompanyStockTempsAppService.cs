using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyStockTemps
{
    public partial interface ITbCompanyStockTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyStockTempDto>> GetListAsync(GetTbCompanyStockTempsInput input);

        Task<TbCompanyStockTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyStockTempDto> CreateAsync(TbCompanyStockTempCreateDto input);

        Task<TbCompanyStockTempDto> UpdateAsync(int id, TbCompanyStockTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyStockTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanystocktempIds);

        Task DeleteAllAsync(GetTbCompanyStockTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}