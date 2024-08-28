using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbInvestPersons
{
    public partial interface ITbInvestPersonsAppService : IApplicationService
    {

        Task<PagedResultDto<TbInvestPersonDto>> GetListAsync(GetTbInvestPersonsInput input);

        Task<TbInvestPersonDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbInvestPersonDto> CreateAsync(TbInvestPersonCreateDto input);

        Task<TbInvestPersonDto> UpdateAsync(int id, TbInvestPersonUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbInvestPersonExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbinvestpersonIds);

        Task DeleteAllAsync(GetTbInvestPersonsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}