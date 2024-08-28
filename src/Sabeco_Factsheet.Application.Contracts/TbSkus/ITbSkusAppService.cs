using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbSkus
{
    public partial interface ITbSkusAppService : IApplicationService
    {

        Task<PagedResultDto<TbSkuDto>> GetListAsync(GetTbSkusInput input);

        Task<TbSkuDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbSkuDto> CreateAsync(TbSkuCreateDto input);

        Task<TbSkuDto> UpdateAsync(int id, TbSkuUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbSkuExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbskuIds);

        Task DeleteAllAsync(GetTbSkusInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}