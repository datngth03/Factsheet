using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyPersonTemps
{
    public partial interface ITbCompanyPersonTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyPersonTempDto>> GetListAsync(GetTbCompanyPersonTempsInput input);

        Task<TbCompanyPersonTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyPersonTempDto> CreateAsync(TbCompanyPersonTempCreateDto input);

        Task<TbCompanyPersonTempDto> UpdateAsync(int id, TbCompanyPersonTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyPersonTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanypersontempIds);

        Task DeleteAllAsync(GetTbCompanyPersonTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}