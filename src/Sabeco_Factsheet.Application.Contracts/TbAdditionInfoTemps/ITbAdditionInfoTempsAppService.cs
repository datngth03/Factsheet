using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbAdditionInfoTemps
{
    public partial interface ITbAdditionInfoTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbAdditionInfoTempDto>> GetListAsync(GetTbAdditionInfoTempsInput input);

        Task<TbAdditionInfoTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbAdditionInfoTempDto> CreateAsync(TbAdditionInfoTempCreateDto input);

        Task<TbAdditionInfoTempDto> UpdateAsync(int id, TbAdditionInfoTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbAdditionInfoTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbadditioninfotempIds);

        Task DeleteAllAsync(GetTbAdditionInfoTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}