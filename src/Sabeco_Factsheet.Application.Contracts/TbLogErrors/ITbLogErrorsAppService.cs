using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogErrors
{
    public partial interface ITbLogErrorsAppService : IApplicationService
    {

        Task<PagedResultDto<TbLogErrorDto>> GetListAsync(GetTbLogErrorsInput input);

        Task<TbLogErrorDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbLogErrorDto> CreateAsync(TbLogErrorCreateDto input);

        Task<TbLogErrorDto> UpdateAsync(int id, TbLogErrorUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogErrorExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tblogerrorIds);

        Task DeleteAllAsync(GetTbLogErrorsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}