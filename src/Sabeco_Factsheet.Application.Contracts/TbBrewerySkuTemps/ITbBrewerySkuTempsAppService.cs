using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBrewerySkuTemps
{
    public partial interface ITbBrewerySkuTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbBrewerySkuTempDto>> GetListAsync(GetTbBrewerySkuTempsInput input);

        Task<TbBrewerySkuTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbBrewerySkuTempDto> CreateAsync(TbBrewerySkuTempCreateDto input);

        Task<TbBrewerySkuTempDto> UpdateAsync(int id, TbBrewerySkuTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBrewerySkuTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbbreweryskutempIds);

        Task DeleteAllAsync(GetTbBrewerySkuTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}