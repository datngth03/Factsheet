using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbNationalities
{
    public partial interface ITbNationalitiesAppService : IApplicationService
    {

        Task<PagedResultDto<TbNationalityDto>> GetListAsync(GetTbNationalitiesInput input);

        Task<TbNationalityDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbNationalityDto> CreateAsync(TbNationalityCreateDto input);

        Task<TbNationalityDto> UpdateAsync(int id, TbNationalityUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbNationalityExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbnationalityIds);

        Task DeleteAllAsync(GetTbNationalitiesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}