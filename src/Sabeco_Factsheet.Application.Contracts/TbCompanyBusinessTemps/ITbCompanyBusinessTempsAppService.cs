using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBusinessTemps
{
    public partial interface ITbCompanyBusinessTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyBusinessTempDto>> GetListAsync(GetTbCompanyBusinessTempsInput input);

        Task<TbCompanyBusinessTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyBusinessTempDto> CreateAsync(TbCompanyBusinessTempCreateDto input);

        Task<TbCompanyBusinessTempDto> UpdateAsync(int id, TbCompanyBusinessTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBusinessTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanybusinesstempIds);

        Task DeleteAllAsync(GetTbCompanyBusinessTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}