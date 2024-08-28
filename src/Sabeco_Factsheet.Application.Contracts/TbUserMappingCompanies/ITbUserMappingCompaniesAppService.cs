using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbUserMappingCompanies
{
    public partial interface ITbUserMappingCompaniesAppService : IApplicationService
    {

        Task<PagedResultDto<TbUserMappingCompanyDto>> GetListAsync(GetTbUserMappingCompaniesInput input);

        Task<TbUserMappingCompanyDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbUserMappingCompanyDto> CreateAsync(TbUserMappingCompanyCreateDto input);

        Task<TbUserMappingCompanyDto> UpdateAsync(int id, TbUserMappingCompanyUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbUserMappingCompanyExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbusermappingcompanyIds);

        Task DeleteAllAsync(GetTbUserMappingCompaniesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}