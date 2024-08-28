using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbPositions
{
    public partial interface ITbPositionsAppService : IApplicationService
    {

        Task<PagedResultDto<TbPositionDto>> GetListAsync(GetTbPositionsInput input);

        Task<TbPositionDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbPositionDto> CreateAsync(TbPositionCreateDto input);

        Task<TbPositionDto> UpdateAsync(int id, TbPositionUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbPositionExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbpositionIds);

        Task DeleteAllAsync(GetTbPositionsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}