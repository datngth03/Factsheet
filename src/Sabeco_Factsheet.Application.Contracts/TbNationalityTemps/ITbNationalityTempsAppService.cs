using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbNationalityTemps
{
    public partial interface ITbNationalityTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbNationalityTempDto>> GetListAsync(GetTbNationalityTempsInput input);

        Task<TbNationalityTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbNationalityTempDto> CreateAsync(TbNationalityTempCreateDto input);

        Task<TbNationalityTempDto> UpdateAsync(int id, TbNationalityTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbNationalityTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbnationalitytempIds);

        Task DeleteAllAsync(GetTbNationalityTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}