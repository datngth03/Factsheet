using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBranchs
{
    public partial interface ITbCompanyBranchsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyBranchDto>> GetListAsync(GetTbCompanyBranchsInput input);

        Task<TbCompanyBranchDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyBranchDto> CreateAsync(TbCompanyBranchCreateDto input);

        Task<TbCompanyBranchDto> UpdateAsync(int id, TbCompanyBranchUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBranchExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanybranchIds);

        Task DeleteAllAsync(GetTbCompanyBranchsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}