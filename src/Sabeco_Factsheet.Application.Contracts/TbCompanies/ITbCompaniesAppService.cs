using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanies
{
    public partial interface ITbCompaniesAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyDto>> GetListAsync(GetTbCompaniesInput input);

        Task<TbCompanyDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyDto> CreateAsync(TbCompanyCreateDto input);

        Task<TbCompanyDto> UpdateAsync(int id, TbCompanyUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanyIds);

        Task DeleteAllAsync(GetTbCompaniesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}