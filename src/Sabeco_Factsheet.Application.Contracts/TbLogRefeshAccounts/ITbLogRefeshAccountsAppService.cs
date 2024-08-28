using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogRefeshAccounts
{
    public partial interface ITbLogRefeshAccountsAppService : IApplicationService
    {

        Task<PagedResultDto<TbLogRefeshAccountDto>> GetListAsync(GetTbLogRefeshAccountsInput input);

        Task<TbLogRefeshAccountDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbLogRefeshAccountDto> CreateAsync(TbLogRefeshAccountCreateDto input);

        Task<TbLogRefeshAccountDto> UpdateAsync(int id, TbLogRefeshAccountUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogRefeshAccountExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tblogrefeshaccountIds);

        Task DeleteAllAsync(GetTbLogRefeshAccountsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}