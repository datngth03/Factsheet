using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisLogPrintings
{
    public partial interface ITbHisLogPrintingsAppService : IApplicationService
    {

        Task<PagedResultDto<TbHisLogPrintingDto>> GetListAsync(GetTbHisLogPrintingsInput input);

        Task<TbHisLogPrintingDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbHisLogPrintingDto> CreateAsync(TbHisLogPrintingCreateDto input);

        Task<TbHisLogPrintingDto> UpdateAsync(int id, TbHisLogPrintingUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisLogPrintingExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbhislogprintingIds);

        Task DeleteAllAsync(GetTbHisLogPrintingsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}