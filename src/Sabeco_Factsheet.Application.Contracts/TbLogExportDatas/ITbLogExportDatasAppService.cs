using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogExportDatas
{
    public partial interface ITbLogExportDatasAppService : IApplicationService
    {

        Task<PagedResultDto<TbLogExportDataDto>> GetListAsync(GetTbLogExportDatasInput input);

        Task<TbLogExportDataDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbLogExportDataDto> CreateAsync(TbLogExportDataCreateDto input);

        Task<TbLogExportDataDto> UpdateAsync(int id, TbLogExportDataUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogExportDataExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tblogexportdataIds);

        Task DeleteAllAsync(GetTbLogExportDatasInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}