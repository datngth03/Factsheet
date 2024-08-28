using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyTemps
{
    public partial interface ITbCompanyTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyTempDto>> GetListAsync(GetTbCompanyTempsInput input);

        Task<TbCompanyTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyTempDto> CreateAsync(TbCompanyTempCreateDto input);

        Task<TbCompanyTempDto> UpdateAsync(int id, TbCompanyTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanytempIds);

        Task DeleteAllAsync(GetTbCompanyTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}