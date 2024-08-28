using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMappings
{
    public partial interface ITbCompanyMappingsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyMappingDto>> GetListAsync(GetTbCompanyMappingsInput input);

        Task<TbCompanyMappingDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyMappingDto> CreateAsync(TbCompanyMappingCreateDto input);

        Task<TbCompanyMappingDto> UpdateAsync(int id, TbCompanyMappingUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyMappingExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanymappingIds);

        Task DeleteAllAsync(GetTbCompanyMappingsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}