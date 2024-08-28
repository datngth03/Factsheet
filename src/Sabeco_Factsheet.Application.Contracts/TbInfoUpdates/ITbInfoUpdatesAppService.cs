using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbInfoUpdates
{
    public partial interface ITbInfoUpdatesAppService : IApplicationService
    {

        Task<PagedResultDto<TbInfoUpdateDto>> GetListAsync(GetTbInfoUpdatesInput input);

        Task<TbInfoUpdateDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbInfoUpdateDto> CreateAsync(TbInfoUpdateCreateDto input);

        Task<TbInfoUpdateDto> UpdateAsync(int id, TbInfoUpdateUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbInfoUpdateExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbinfoupdateIds);

        Task DeleteAllAsync(GetTbInfoUpdatesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}