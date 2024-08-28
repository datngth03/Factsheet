using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbTimeScripts
{
    public partial interface ITbTimeScriptsAppService : IApplicationService
    {

        Task<PagedResultDto<TbTimeScriptDto>> GetListAsync(GetTbTimeScriptsInput input);

        Task<TbTimeScriptDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbTimeScriptDto> CreateAsync(TbTimeScriptCreateDto input);

        Task<TbTimeScriptDto> UpdateAsync(int id, TbTimeScriptUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbTimeScriptExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbtimescriptIds);

        Task DeleteAllAsync(GetTbTimeScriptsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}