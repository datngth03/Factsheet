using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogSendEmailRetirements
{
    public partial interface ITbLogSendEmailRetirementsAppService : IApplicationService
    {

        Task<PagedResultDto<TbLogSendEmailRetirementDto>> GetListAsync(GetTbLogSendEmailRetirementsInput input);

        Task<TbLogSendEmailRetirementDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbLogSendEmailRetirementDto> CreateAsync(TbLogSendEmailRetirementCreateDto input);

        Task<TbLogSendEmailRetirementDto> UpdateAsync(int id, TbLogSendEmailRetirementUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogSendEmailRetirementExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tblogsendemailretirementIds);

        Task DeleteAllAsync(GetTbLogSendEmailRetirementsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}