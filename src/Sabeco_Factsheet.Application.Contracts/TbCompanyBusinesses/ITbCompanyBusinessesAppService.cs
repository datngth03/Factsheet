using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBusinesses
{
    public partial interface ITbCompanyBusinessesAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyBusinessDto>> GetListAsync(GetTbCompanyBusinessesInput input);

        Task<TbCompanyBusinessDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyBusinessDto> CreateAsync(TbCompanyBusinessCreateDto input);

        Task<TbCompanyBusinessDto> UpdateAsync(int id, TbCompanyBusinessUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBusinessExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanybusinessIds);

        Task DeleteAllAsync(GetTbCompanyBusinessesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}