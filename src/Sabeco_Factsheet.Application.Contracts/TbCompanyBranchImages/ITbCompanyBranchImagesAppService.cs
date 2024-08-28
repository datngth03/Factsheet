using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBranchImages
{
    public partial interface ITbCompanyBranchImagesAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyBranchImageDto>> GetListAsync(GetTbCompanyBranchImagesInput input);

        Task<TbCompanyBranchImageDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyBranchImageDto> CreateAsync(TbCompanyBranchImageCreateDto input);

        Task<TbCompanyBranchImageDto> UpdateAsync(int id, TbCompanyBranchImageUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBranchImageExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanybranchimageIds);

        Task DeleteAllAsync(GetTbCompanyBranchImagesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}