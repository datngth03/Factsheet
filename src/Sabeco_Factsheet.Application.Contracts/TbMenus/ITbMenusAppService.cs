using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbMenus
{
    public partial interface ITbMenusAppService : IApplicationService
    {

        Task<PagedResultDto<TbMenuDto>> GetListAsync(GetTbMenusInput input);

        Task<TbMenuDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbMenuDto> CreateAsync(TbMenuCreateDto input);

        Task<TbMenuDto> UpdateAsync(int id, TbMenuUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbMenuExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbmenuIds);

        Task DeleteAllAsync(GetTbMenusInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}