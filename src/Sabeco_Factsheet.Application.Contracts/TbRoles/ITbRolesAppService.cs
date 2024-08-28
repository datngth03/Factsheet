using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Sabeco_Factsheet.Shared;

namespace Sabeco_Factsheet.TbRoles
{
    public partial interface ITbRolesAppService : IApplicationService
    {

        Task<PagedResultDto<TbRoleDto>> GetListAsync(GetTbRolesInput input);

        Task<TbRoleDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<TbRoleDto> CreateAsync(TbRoleCreateDto input);

        Task<TbRoleDto> UpdateAsync(int id, TbRoleUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TbRoleExcelDownloadDto input, string fileName);
        Task DeleteByIdsAsync(List<int> tbroleIds);

        Task DeleteAllAsync(GetTbRolesInput input);
        Task<Sabeco_Factsheet.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}