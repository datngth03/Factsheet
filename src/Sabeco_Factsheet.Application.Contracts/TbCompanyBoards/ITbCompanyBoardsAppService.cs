using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbCompanyBoards
{
    public partial interface ITbCompanyBoardsAppService : IApplicationService
    {

        Task<PagedResultDto<TbCompanyBoardDto>> GetListAsync(GetTbCompanyBoardsInput input);

        Task<TbCompanyBoardDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbCompanyBoardDto> CreateAsync(TbCompanyBoardCreateDto input);

        Task<TbCompanyBoardDto> UpdateAsync(int id, TbCompanyBoardUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbCompanyBoardExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbcompanyboardIds);

        Task DeleteAllAsync(GetTbCompanyBoardsInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}