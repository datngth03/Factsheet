using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbAdditionInfos
{
    public partial interface ITbAdditionInfosAppService : IApplicationService
    {

        Task<PagedResultDto<TbAdditionInfoDto>> GetListAsync(GetTbAdditionInfosInput input);

        Task<TbAdditionInfoDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbAdditionInfoDto> CreateAsync(TbAdditionInfoCreateDto input);

        Task<TbAdditionInfoDto> UpdateAsync(int id, TbAdditionInfoUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbAdditionInfoExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbadditioninfoIds);

        Task DeleteAllAsync(GetTbAdditionInfosInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}