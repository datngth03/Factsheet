using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbFileUploadTemps
{
    public partial interface ITbFileUploadTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbFileUploadTempDto>> GetListAsync(GetTbFileUploadTempsInput input);

        Task<TbFileUploadTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbFileUploadTempDto> CreateAsync(TbFileUploadTempCreateDto input);

        Task<TbFileUploadTempDto> UpdateAsync(int id, TbFileUploadTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbFileUploadTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbfileuploadtempIds);

        Task DeleteAllAsync(GetTbFileUploadTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}