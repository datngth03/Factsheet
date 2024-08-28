using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBranchTemps
{
    public partial interface ITbCompanyBranchTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyBranchTempDto>> GetListAsync(GetTbCompanyBranchTempsInput input);

        Task<TbCompanyBranchTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyBranchTempDto> CreateAsync(TbCompanyBranchTempCreateDto input);

        Task<TbCompanyBranchTempDto> UpdateAsync(int id, TbCompanyBranchTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBranchTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanybranchtempIds);

        Task DeleteAllAsync(GetTbCompanyBranchTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}