using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyInvests
{
    public partial interface ITbCompanyInvestsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyInvestDto>> GetListAsync(GetTbCompanyInvestsInput input);

        Task<TbCompanyInvestDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyInvestDto> CreateAsync(TbCompanyInvestCreateDto input);

        Task<TbCompanyInvestDto> UpdateAsync(int id, TbCompanyInvestUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyInvestExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanyinvestIds);

        Task DeleteAllAsync(GetTbCompanyInvestsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}