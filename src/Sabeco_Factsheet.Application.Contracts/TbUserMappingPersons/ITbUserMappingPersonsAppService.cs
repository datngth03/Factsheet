using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbUserMappingPersons
{
    public partial interface ITbUserMappingPersonsAppService : IApplicationService
    {

        Task<PagedResultDto<TbUserMappingPersonDto>> GetListAsync(GetTbUserMappingPersonsInput input);

        Task<TbUserMappingPersonDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbUserMappingPersonDto> CreateAsync(TbUserMappingPersonCreateDto input);

        Task<TbUserMappingPersonDto> UpdateAsync(int id, TbUserMappingPersonUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbUserMappingPersonExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbusermappingpersonIds);

        Task DeleteAllAsync(GetTbUserMappingPersonsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}