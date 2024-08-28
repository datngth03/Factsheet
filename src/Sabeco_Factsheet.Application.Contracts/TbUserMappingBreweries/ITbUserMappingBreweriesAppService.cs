using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbUserMappingBreweries
{
    public partial interface ITbUserMappingBreweriesAppService : IApplicationService
    {

        Task<PagedResultDto<TbUserMappingBreweryDto>> GetListAsync(GetTbUserMappingBreweriesInput input);

        Task<TbUserMappingBreweryDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbUserMappingBreweryDto> CreateAsync(TbUserMappingBreweryCreateDto input);

        Task<TbUserMappingBreweryDto> UpdateAsync(int id, TbUserMappingBreweryUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbUserMappingBreweryExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbusermappingbreweryIds);

        Task DeleteAllAsync(GetTbUserMappingBreweriesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}