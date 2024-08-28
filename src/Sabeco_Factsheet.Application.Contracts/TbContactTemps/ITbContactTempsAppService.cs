using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbContactTemps
{
    public partial interface ITbContactTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbContactTempDto>> GetListAsync(GetTbContactTempsInput input);

        Task<TbContactTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbContactTempDto> CreateAsync(TbContactTempCreateDto input);

        Task<TbContactTempDto> UpdateAsync(int id, TbContactTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbContactTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcontacttempIds);

        Task DeleteAllAsync(GetTbContactTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}