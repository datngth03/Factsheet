using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBrewerySkus
{
    public partial interface ITbBrewerySkusAppService : IApplicationService
    {

        Task<PagedResultDto<TbBrewerySkuDto>> GetListAsync(GetTbBrewerySkusInput input);

        Task<TbBrewerySkuDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbBrewerySkuDto> CreateAsync(TbBrewerySkuCreateDto input);

        Task<TbBrewerySkuDto> UpdateAsync(int id, TbBrewerySkuUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBrewerySkuExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbbreweryskuIds);

        Task DeleteAllAsync(GetTbBrewerySkusInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}