using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisCompanies
{
    public partial interface ITbHisCompaniesAppService : IApplicationService
    {

        Task<PagedResultDto<TbHisCompanyDto>> GetListAsync(GetTbHisCompaniesInput input);

        Task<TbHisCompanyDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbHisCompanyDto> CreateAsync(TbHisCompanyCreateDto input);

        Task<TbHisCompanyDto> UpdateAsync(int id, TbHisCompanyUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisCompanyExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbhiscompanyIds);

        Task DeleteAllAsync(GetTbHisCompaniesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}