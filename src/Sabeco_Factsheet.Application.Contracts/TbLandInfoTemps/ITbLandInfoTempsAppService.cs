using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLandInfoTemps
{
    public partial interface ITbLandInfoTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbLandInfoTempDto>> GetListAsync(GetTbLandInfoTempsInput input);

        Task<TbLandInfoTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbLandInfoTempDto> CreateAsync(TbLandInfoTempCreateDto input);

        Task<TbLandInfoTempDto> UpdateAsync(int id, TbLandInfoTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLandInfoTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tblandinfotempIds);

        Task DeleteAllAsync(GetTbLandInfoTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}