using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMajorTemps
{
    public partial interface ITbCompanyMajorTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyMajorTempDto>> GetListAsync(GetTbCompanyMajorTempsInput input);

        Task<TbCompanyMajorTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyMajorTempDto> CreateAsync(TbCompanyMajorTempCreateDto input);

        Task<TbCompanyMajorTempDto> UpdateAsync(int id, TbCompanyMajorTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyMajorTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanymajortempIds);

        Task DeleteAllAsync(GetTbCompanyMajorTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}