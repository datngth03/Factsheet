using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogSendEmails
{
    public partial interface ITbLogSendEmailsAppService : IApplicationService
    {

        Task<PagedResultDto<TbLogSendEmailDto>> GetListAsync(GetTbLogSendEmailsInput input);

        Task<TbLogSendEmailDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbLogSendEmailDto> CreateAsync(TbLogSendEmailCreateDto input);

        Task<TbLogSendEmailDto> UpdateAsync(int id, TbLogSendEmailUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogSendEmailExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tblogsendemailIds);

        Task DeleteAllAsync(GetTbLogSendEmailsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}