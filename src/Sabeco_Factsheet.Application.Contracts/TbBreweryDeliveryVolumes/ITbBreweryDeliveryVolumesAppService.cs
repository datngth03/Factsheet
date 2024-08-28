using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweryDeliveryVolumes
{
    public partial interface ITbBreweryDeliveryVolumesAppService : IApplicationService
    {

        Task<PagedResultDto<TbBreweryDeliveryVolumeDto>> GetListAsync(GetTbBreweryDeliveryVolumesInput input);

        Task<TbBreweryDeliveryVolumeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbBreweryDeliveryVolumeDto> CreateAsync(TbBreweryDeliveryVolumeCreateDto input);

        Task<TbBreweryDeliveryVolumeDto> UpdateAsync(int id, TbBreweryDeliveryVolumeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBreweryDeliveryVolumeExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbbrewerydeliveryvolumeIds);

        Task DeleteAllAsync(GetTbBreweryDeliveryVolumesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}