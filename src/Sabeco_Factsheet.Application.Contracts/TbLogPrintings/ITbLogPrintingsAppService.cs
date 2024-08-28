using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogPrintings
{
    public partial interface ITbLogPrintingsAppService : IApplicationService
    {

        Task<PagedResultDto<TbLogPrintingDto>> GetListAsync(GetTbLogPrintingsInput input);

        Task<TbLogPrintingDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbLogPrintingDto> CreateAsync(TbLogPrintingCreateDto input);

        Task<TbLogPrintingDto> UpdateAsync(int id, TbLogPrintingUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogPrintingExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tblogprintingIds);

        Task DeleteAllAsync(GetTbLogPrintingsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}