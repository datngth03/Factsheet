using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMappingTemps
{
    public partial interface ITbCompanyMappingTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyMappingTempDto>> GetListAsync(GetTbCompanyMappingTempsInput input);

        Task<TbCompanyMappingTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyMappingTempDto> CreateAsync(TbCompanyMappingTempCreateDto input);

        Task<TbCompanyMappingTempDto> UpdateAsync(int id, TbCompanyMappingTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyMappingTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanymappingtempIds);

        Task DeleteAllAsync(GetTbCompanyMappingTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}