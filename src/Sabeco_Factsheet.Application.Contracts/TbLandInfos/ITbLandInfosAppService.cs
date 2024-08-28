using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLandInfos
{
    public partial interface ITbLandInfosAppService : IApplicationService
    {

        Task<PagedResultDto<TbLandInfoDto>> GetListAsync(GetTbLandInfosInput input);

        Task<TbLandInfoDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbLandInfoDto> CreateAsync(TbLandInfoCreateDto input);

        Task<TbLandInfoDto> UpdateAsync(int id, TbLandInfoUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLandInfoExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tblandinfoIds);

        Task DeleteAllAsync(GetTbLandInfosInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}