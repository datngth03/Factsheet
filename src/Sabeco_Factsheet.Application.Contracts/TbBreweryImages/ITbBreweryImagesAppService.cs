using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbBreweryImages
{
    public partial interface ITbBreweryImagesAppService : IApplicationService
    {

        Task<PagedResultDto<TbBreweryImageDto>> GetListAsync(GetTbBreweryImagesInput input);

        Task<TbBreweryImageDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbBreweryImageDto> CreateAsync(TbBreweryImageCreateDto input);

        Task<TbBreweryImageDto> UpdateAsync(int id, TbBreweryImageUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbBreweryImageExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbbreweryimageIds);

        Task DeleteAllAsync(GetTbBreweryImagesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}