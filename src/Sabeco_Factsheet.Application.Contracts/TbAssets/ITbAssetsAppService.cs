using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbAssets
{
    public partial interface ITbAssetsAppService : IApplicationService
    {

        Task<PagedResultDto<TbAssetDto>> GetListAsync(GetTbAssetsInput input);

        Task<TbAssetDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbAssetDto> CreateAsync(TbAssetCreateDto input);

        Task<TbAssetDto> UpdateAsync(int id, TbAssetUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbAssetExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbassetIds);

        Task DeleteAllAsync(GetTbAssetsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}