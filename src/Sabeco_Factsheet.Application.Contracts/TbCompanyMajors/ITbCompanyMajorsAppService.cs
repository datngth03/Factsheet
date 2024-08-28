using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyMajors
{
    public partial interface ITbCompanyMajorsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyMajorDto>> GetListAsync(GetTbCompanyMajorsInput input);

        Task<TbCompanyMajorDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyMajorDto> CreateAsync(TbCompanyMajorCreateDto input);

        Task<TbCompanyMajorDto> UpdateAsync(int id, TbCompanyMajorUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyMajorExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanymajorIds);

        Task DeleteAllAsync(GetTbCompanyMajorsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}