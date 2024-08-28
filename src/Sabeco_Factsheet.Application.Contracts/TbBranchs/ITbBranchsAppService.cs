using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBranchs
{
    public partial interface ITbBranchsAppService : IApplicationService
    {

        Task<PagedResultDto<TbBranchDto>> GetListAsync(GetTbBranchsInput input);

        Task<TbBranchDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbBranchDto> CreateAsync(TbBranchCreateDto input);

        Task<TbBranchDto> UpdateAsync(int id, TbBranchUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBranchExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbbranchIds);

        Task DeleteAllAsync(GetTbBranchsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}