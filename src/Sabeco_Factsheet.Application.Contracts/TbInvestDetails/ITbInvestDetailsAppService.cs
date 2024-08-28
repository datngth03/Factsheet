using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbInvestDetails
{
    public partial interface ITbInvestDetailsAppService : IApplicationService
    {

        Task<PagedResultDto<TbInvestDetailDto>> GetListAsync(GetTbInvestDetailsInput input);

        Task<TbInvestDetailDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbInvestDetailDto> CreateAsync(TbInvestDetailCreateDto input);

        Task<TbInvestDetailDto> UpdateAsync(int id, TbInvestDetailUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbInvestDetailExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbinvestdetailIds);

        Task DeleteAllAsync(GetTbInvestDetailsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}