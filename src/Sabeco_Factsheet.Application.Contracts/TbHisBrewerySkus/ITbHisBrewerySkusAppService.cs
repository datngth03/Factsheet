using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisBrewerySkus
{
    public partial interface ITbHisBrewerySkusAppService : IApplicationService
    {

        Task<PagedResultDto<TbHisBrewerySkuDto>> GetListAsync(GetTbHisBrewerySkusInput input);

        Task<TbHisBrewerySkuDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbHisBrewerySkuDto> CreateAsync(TbHisBrewerySkuCreateDto input);

        Task<TbHisBrewerySkuDto> UpdateAsync(int id, TbHisBrewerySkuUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisBrewerySkuExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbhisbreweryskuIds);

        Task DeleteAllAsync(GetTbHisBrewerySkusInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}