using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyInvestTemps
{
    public partial interface ITbCompanyInvestTempsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyInvestTempDto>> GetListAsync(GetTbCompanyInvestTempsInput input);

        Task<TbCompanyInvestTempDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyInvestTempDto> CreateAsync(TbCompanyInvestTempCreateDto input);

        Task<TbCompanyInvestTempDto> UpdateAsync(int id, TbCompanyInvestTempUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyInvestTempExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanyinvesttempIds);

        Task DeleteAllAsync(GetTbCompanyInvestTempsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}