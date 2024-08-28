using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbInvests
{
    public partial interface ITbInvestsAppService : IApplicationService
    {

        Task<PagedResultDto<TbInvestDto>> GetListAsync(GetTbInvestsInput input);

        Task<TbInvestDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbInvestDto> CreateAsync(TbInvestCreateDto input);

        Task<TbInvestDto> UpdateAsync(int id, TbInvestUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbInvestExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbinvestIds);

        Task DeleteAllAsync(GetTbInvestsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}