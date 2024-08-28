using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbHisCompanyPersons
{
    public partial interface ITbHisCompanyPersonsAppService : IApplicationService
    {

        Task<PagedResultDto<TbHisCompanyPersonDto>> GetListAsync(GetTbHisCompanyPersonsInput input);

        Task<TbHisCompanyPersonDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbHisCompanyPersonDto> CreateAsync(TbHisCompanyPersonCreateDto input);

        Task<TbHisCompanyPersonDto> UpdateAsync(int id, TbHisCompanyPersonUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbHisCompanyPersonExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbhiscompanypersonIds);

        Task DeleteAllAsync(GetTbHisCompanyPersonsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}