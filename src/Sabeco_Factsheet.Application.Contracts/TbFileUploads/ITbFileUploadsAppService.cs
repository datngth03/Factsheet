using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbFileUploads
{
    public partial interface ITbFileUploadsAppService : IApplicationService
    {

        Task<PagedResultDto<TbFileUploadDto>> GetListAsync(GetTbFileUploadsInput input);

        Task<TbFileUploadDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbFileUploadDto> CreateAsync(TbFileUploadCreateDto input);

        Task<TbFileUploadDto> UpdateAsync(int id, TbFileUploadUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbFileUploadExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbfileuploadIds);

        Task DeleteAllAsync(GetTbFileUploadsInput input);

        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}