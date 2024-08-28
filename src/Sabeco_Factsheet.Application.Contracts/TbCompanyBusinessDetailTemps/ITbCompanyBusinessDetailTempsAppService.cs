using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBusinessDetailTemps
{
    public partial interface ITbCompanyBusinessDetailTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyBusinessDetailTempDto>> GetListAsync(GetTbCompanyBusinessDetailTempsInput input);

        Task<TbCompanyBusinessDetailTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyBusinessDetailTempDto> CreateAsync(TbCompanyBusinessDetailTempCreateDto input);

        Task<TbCompanyBusinessDetailTempDto> UpdateAsync(int id, TbCompanyBusinessDetailTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBusinessDetailTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanybusinessdetailtempIds);

        Task DeleteAllAsync(GetTbCompanyBusinessDetailTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}