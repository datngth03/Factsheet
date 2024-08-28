using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyPersons
{
    public partial interface ITbCompanyPersonsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyPersonDto>> GetListAsync(GetTbCompanyPersonsInput input);

        Task<TbCompanyPersonDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyPersonDto> CreateAsync(TbCompanyPersonCreateDto input);

        Task<TbCompanyPersonDto> UpdateAsync(int id, TbCompanyPersonUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyPersonExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanypersonIds);

        Task DeleteAllAsync(GetTbCompanyPersonsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}