using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweryTemps
{
    public partial interface ITbBreweryTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbBreweryTempDto>> GetListAsync(GetTbBreweryTempsInput input);

        Task<TbBreweryTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbBreweryTempDto> CreateAsync(TbBreweryTempCreateDto input);

        Task<TbBreweryTempDto> UpdateAsync(int id, TbBreweryTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBreweryTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbbrewerytempIds);

        Task DeleteAllAsync(GetTbBreweryTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}