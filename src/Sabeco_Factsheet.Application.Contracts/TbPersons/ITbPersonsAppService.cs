using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbPersons
{
    public partial interface ITbPersonsAppService : IApplicationService
    {

        Task<PagedResultDto<TbPersonDto>> GetListAsync(GetTbPersonsInput input);

        Task<TbPersonDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbPersonDto> CreateAsync(TbPersonCreateDto input);

        Task<TbPersonDto> UpdateAsync(int id, TbPersonUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbPersonExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbpersonIds);

        Task DeleteAllAsync(GetTbPersonsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}