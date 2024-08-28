using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{
    public partial interface ITbCompanyBusinessDetailsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyBusinessDetailDto>> GetListAsync(GetTbCompanyBusinessDetailsInput input);

        Task<TbCompanyBusinessDetailDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyBusinessDetailDto> CreateAsync(TbCompanyBusinessDetailCreateDto input);

        Task<TbCompanyBusinessDetailDto> UpdateAsync(int id, TbCompanyBusinessDetailUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBusinessDetailExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanybusinessdetailIds);

        Task DeleteAllAsync(GetTbCompanyBusinessDetailsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}