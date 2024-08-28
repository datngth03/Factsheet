using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisPersons
{
    public partial interface ITbHisPersonsAppService : IApplicationService
    {

        Task<PagedResultDto<TbHisPersonDto>> GetListAsync(GetTbHisPersonsInput input);

        Task<TbHisPersonDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbHisPersonDto> CreateAsync(TbHisPersonCreateDto input);

        Task<TbHisPersonDto> UpdateAsync(int id, TbHisPersonUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisPersonExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbhispersonIds);

        Task DeleteAllAsync(GetTbHisPersonsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}