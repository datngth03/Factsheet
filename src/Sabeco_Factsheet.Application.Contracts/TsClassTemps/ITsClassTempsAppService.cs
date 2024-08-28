using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TsClassTemps
{
    public partial interface ITsClassTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TsClassTempDto>> GetListAsync(GetTsClassTempsInput input);

        Task<TsClassTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TsClassTempDto> CreateAsync(TsClassTempCreateDto input);

        Task<TsClassTempDto> UpdateAsync(int id, TsClassTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TsClassTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tsclasstempIds);

        Task DeleteAllAsync(GetTsClassTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}