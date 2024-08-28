using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogSyncUats
{
    public partial interface ITbLogSyncUatsAppService : IApplicationService
    {

        Task<PagedResultDto<TbLogSyncUatDto>> GetListAsync(GetTbLogSyncUatsInput input);

        Task<TbLogSyncUatDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbLogSyncUatDto> CreateAsync(TbLogSyncUatCreateDto input);

        Task<TbLogSyncUatDto> UpdateAsync(int id, TbLogSyncUatUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogSyncUatExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tblogsyncuatIds);

        Task DeleteAllAsync(GetTbLogSyncUatsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}