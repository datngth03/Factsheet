using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TsClasses
{
    public partial interface ITsClassesAppService : IApplicationService
    {

        Task<PagedResultDto<TsClassDto>> GetListAsync(GetTsClassesInput input);

        Task<TsClassDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TsClassDto> CreateAsync(TsClassCreateDto input);

        Task<TsClassDto> UpdateAsync(int id, TsClassUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TsClassExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tsclassIds);

        Task DeleteAllAsync(GetTsClassesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}