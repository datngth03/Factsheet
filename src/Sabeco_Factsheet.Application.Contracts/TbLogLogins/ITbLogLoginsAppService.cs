using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbLogLogins
{
    public partial interface ITbLogLoginsAppService : IApplicationService
    {

        Task<PagedResultDto<TbLogLoginDto>> GetListAsync(GetTbLogLoginsInput input);

        Task<TbLogLoginDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbLogLoginDto> CreateAsync(TbLogLoginCreateDto input);

        Task<TbLogLoginDto> UpdateAsync(int id, TbLogLoginUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbLogLoginExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tblogloginIds);

        Task DeleteAllAsync(GetTbLogLoginsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}