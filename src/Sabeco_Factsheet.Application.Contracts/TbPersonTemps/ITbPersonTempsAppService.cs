using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbPersonTemps
{
    public partial interface ITbPersonTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbPersonTempDto>> GetListAsync(GetTbPersonTempsInput input);

        Task<TbPersonTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbPersonTempDto> CreateAsync(TbPersonTempCreateDto input);

        Task<TbPersonTempDto> UpdateAsync(int id, TbPersonTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbPersonTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbpersontempIds);

        Task DeleteAllAsync(GetTbPersonTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}