using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public partial interface ITbConfigRetirementTimesAppService : IApplicationService
    {

        Task<PagedResultDto<TbConfigRetirementTimeDto>> GetListAsync(GetTbConfigRetirementTimesInput input);

        Task<TbConfigRetirementTimeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbConfigRetirementTimeDto> CreateAsync(TbConfigRetirementTimeCreateDto input);

        Task<TbConfigRetirementTimeDto> UpdateAsync(int id, TbConfigRetirementTimeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbConfigRetirementTimeExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbconfigretirementtimeIds);

        Task DeleteAllAsync(GetTbConfigRetirementTimesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}