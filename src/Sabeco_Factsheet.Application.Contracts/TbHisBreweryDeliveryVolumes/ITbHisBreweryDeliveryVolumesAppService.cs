using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisBreweryDeliveryVolumes
{
    public partial interface ITbHisBreweryDeliveryVolumesAppService : IApplicationService
    {

        Task<PagedResultDto<TbHisBreweryDeliveryVolumeDto>> GetListAsync(GetTbHisBreweryDeliveryVolumesInput input);

        Task<TbHisBreweryDeliveryVolumeDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbHisBreweryDeliveryVolumeDto> CreateAsync(TbHisBreweryDeliveryVolumeCreateDto input);

        Task<TbHisBreweryDeliveryVolumeDto> UpdateAsync(int id, TbHisBreweryDeliveryVolumeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisBreweryDeliveryVolumeExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbhisbrewerydeliveryvolumeIds);

        Task DeleteAllAsync(GetTbHisBreweryDeliveryVolumesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}