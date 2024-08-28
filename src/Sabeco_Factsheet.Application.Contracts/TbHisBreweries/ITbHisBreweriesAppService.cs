using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisBreweries
{
    public partial interface ITbHisBreweriesAppService : IApplicationService
    {

        Task<PagedResultDto<TbHisBreweryDto>> GetListAsync(GetTbHisBreweriesInput input);

        Task<TbHisBreweryDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbHisBreweryDto> CreateAsync(TbHisBreweryCreateDto input);

        Task<TbHisBreweryDto> UpdateAsync(int id, TbHisBreweryUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisBreweryExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbhisbreweryIds);

        Task DeleteAllAsync(GetTbHisBreweriesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}