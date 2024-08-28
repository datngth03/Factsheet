using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbTerms
{
    public partial interface ITbTermsAppService : IApplicationService
    {

        Task<PagedResultDto<TbTermDto>> GetListAsync(GetTbTermsInput input);

        Task<TbTermDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbTermDto> CreateAsync(TbTermCreateDto input);

        Task<TbTermDto> UpdateAsync(int id, TbTermUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbTermExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbtermIds);

        Task DeleteAllAsync(GetTbTermsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}