using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweries
{
    public partial interface ITbBreweriesAppService : IApplicationService
    {

        Task<PagedResultDto<TbBreweryDto>> GetListAsync(GetTbBreweriesInput input);

        Task<TbBreweryDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbBreweryDto> CreateAsync(TbBreweryCreateDto input);

        Task<TbBreweryDto> UpdateAsync(int id, TbBreweryUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBreweryExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbbreweryIds);

        Task DeleteAllAsync(GetTbBreweriesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}