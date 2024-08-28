using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumeTemps
{
    public partial interface ITbBreweryDeliveryVolumeTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbBreweryDeliveryVolumeTempDto>> GetListAsync(GetTbBreweryDeliveryVolumeTempsInput input);

        Task<TbBreweryDeliveryVolumeTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbBreweryDeliveryVolumeTempDto> CreateAsync(TbBreweryDeliveryVolumeTempCreateDto input);

        Task<TbBreweryDeliveryVolumeTempDto> UpdateAsync(int id, TbBreweryDeliveryVolumeTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBreweryDeliveryVolumeTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbbrewerydeliveryvolumetempIds);

        Task DeleteAllAsync(GetTbBreweryDeliveryVolumeTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}