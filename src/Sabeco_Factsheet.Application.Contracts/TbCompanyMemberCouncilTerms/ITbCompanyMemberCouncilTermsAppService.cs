using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMemberCouncilTerms
{
    public partial interface ITbCompanyMemberCouncilTermsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyMemberCouncilTermDto>> GetListAsync(GetTbCompanyMemberCouncilTermsInput input);

        Task<TbCompanyMemberCouncilTermDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyMemberCouncilTermDto> CreateAsync(TbCompanyMemberCouncilTermCreateDto input);

        Task<TbCompanyMemberCouncilTermDto> UpdateAsync(int id, TbCompanyMemberCouncilTermUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyMemberCouncilTermExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanymembercounciltermIds);

        Task DeleteAllAsync(GetTbCompanyMemberCouncilTermsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}